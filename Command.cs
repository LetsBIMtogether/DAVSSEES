// Command.cs

#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using AG_DAVSSEES.xForm;
#endregion

namespace AG_DAVSSEES
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        static MainWindowForm _f = null;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (_f == null || _f.IsDisposed)
            {
                Document d = commandData.Application.ActiveUIDocument.Document;
                MainWindowExHandler e = new MainWindowExHandler();
                _f = new MainWindowForm(d,e);
                _f.Show();
            }

            else
                _f.BringToFront();

            return Result.Succeeded;
        }
    }
}