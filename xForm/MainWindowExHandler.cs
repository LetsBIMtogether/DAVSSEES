// MainWindowExHandler.cs

#region Namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using winForm = System.Windows.Forms;
#endregion

namespace AG_DAVSSEES.xForm
{
    public class MainWindowExHandler : IExternalEventHandler
    {
        // For AU's journal & debug?
        public string GetName() { return "AG DAVSSEES"; }

        public List<DrawingInfo> DrawingDeleteList {  get; set; } = new List<DrawingInfo>();

        public void Execute(UIApplication a)
        {
            if (!DrawingDeleteList.Any())
            {
                winForm.MessageBox.Show("Error: No elements to delete.");

                Globals.DeleteProgressForm?.Close();
                Globals.DeleteProgressForm = null;
                
                return;
            }

            if (Globals.DeleteProgressForm == null)
            {
                winForm.MessageBox.Show("Error: Delete Progress Form never started.");
                return;
            }

            Globals.Doc = a.ActiveUIDocument.Document;

            // 2 second pause to allow Cancel prior to execution.
            var start = DateTime.Now;

            while ((DateTime.Now - start).TotalMilliseconds < 2000)
            {
                if (Globals.CancelFlag.Stop)
                {
                    Globals.DeleteProgressForm.Close();
                    Globals.DeleteProgressForm = null;

                    return;
                }

                winForm.Application.DoEvents();
                System.Threading.Thread.Sleep(50);
            }

            List<ElementId> eIdDeleteList = DrawingDeleteList
                .Select(d => d.Id)
                .Where(id => id != ElementId.InvalidElementId)
                .Distinct()
                .ToList();

            Globals.DeleteProgressForm.SetTotal(eIdDeleteList.Count);

            var successEIds = new List<ElementId>();
            var failedEIds = new List<ElementId>();

            using (var tg = new TransactionGroup(Globals.Doc, "DAVSSEES (Delete All ...)"))
            {
                tg.Start();

                (successEIds, failedEIds) = AG.U.DeleteElements(
                    Globals.Doc, eIdDeleteList, Globals.CancelFlag,
                    cur =>
                    {
                        Globals.DeleteProgressForm.SetStep(cur);
                    });

                Globals.DeleteProgressForm.SetMessage("Finalizing changes...");

                // 2 second pause to allow Cancel after execution.
                var end = DateTime.Now;

                while ((DateTime.Now - end).TotalMilliseconds < 2000)
                {
                    if (Globals.CancelFlag.Stop)
                    {
                        Globals.DeleteProgressForm.Close();
                        Globals.DeleteProgressForm = null;

                        return;
                    }

                    winForm.Application.DoEvents();
                    System.Threading.Thread.Sleep(50);
                }

                if (!Globals.CancelFlag.Stop)
                    tg.Assimilate();

                else
                    tg.RollBack();
            }

            Globals.DeleteProgressForm.Close();
            Globals.DeleteProgressForm = null;

            Dictionary<ElementId,DrawingInfo> infoById = DrawingDeleteList
                .Where(d => d.Id != ElementId.InvalidElementId)
                .GroupBy(d => d.Id)
                .ToDictionary(g => g.Key, g => g.First());

            if (successEIds.Any())
            {
                Globals.SuccessLog.Add("Deleted " + successEIds.Count + " items:");

                foreach (ElementId id in successEIds)
                    if (infoById.TryGetValue(id, out DrawingInfo info))
                        Globals.SuccessLog.Add(" - " + info.DrawingKind + ": " + info.Name, true);
            }

            if (failedEIds.Any())
            {
                Globals.ErrorLog.Add($"Failed to delete " + failedEIds.Count + " items:");

                foreach (var id in failedEIds)
                    if (infoById.TryGetValue(id, out DrawingInfo info))
                        Globals.ErrorLog.Add(" - " + info.DrawingKind + ": " + info.Name, true);
            }

            if (Globals.SuccessLog.Full != string.Empty)
            {
                Globals.SuccessLogForm.Update(Globals.SuccessLog.Full);
                Globals.SuccessLogForm.Show();
            }

            if (Globals.ErrorLog.Full != string.Empty)
            {
                Globals.ErrorLogForm.Update(Globals.ErrorLog.Full);
                Globals.ErrorLogForm.Show();
            }
        }

    }
}