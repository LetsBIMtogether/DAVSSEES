// MainWindowForm.cs

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using winForm = System.Windows.Forms;

namespace AG_DAVSSEES.xForm
{
    public partial class MainWindowForm : winForm.Form
    {
        int _lastListViewWidth;

        ExternalEvent _mainWindowExternalEvent;
        MainWindowExHandler _mainWindowEventHandler;

        List<AG.U2.KeyedValue<DrawingInfo>> _formPairs;
        string _filterString;
        List<int> _visibleIndices;

        public MainWindowForm(Document doc, MainWindowExHandler e)
        {
            InitializeComponent();

            Globals.Doc = doc;

            this.Resize += MainWindowForm_Resize;
            this.textBox_FilterKeyword.TextChanged += textBox_FilterKeyword_TextChanged;

            this._mainWindowEventHandler = e;
            this._mainWindowExternalEvent = ExternalEvent.Create(_mainWindowEventHandler);
            this.Icon = AG.U.GetWinFormsIcon(Globals.Icon);

            Globals.Drawings.Clear();
            List<ElementId> dwgIds = AG.U.GetAllDrawingsEId(Globals.Doc);

            foreach (ElementId id in dwgIds)
            {
                var dwg = new DrawingInfo();
                Element elem = Globals.Doc.GetElement(id);

                if (elem is ViewSheet sht)
                    dwg.Name = sht.SheetNumber + ": " + sht.Name;

                else
                    dwg.Name = elem.Name;

                dwg.DrawingKind = AG.U.GetDrawingKind(Globals.Doc, id);
                dwg.Id = id;

                Globals.Drawings.Add(dwg);
            }

            Globals.Drawings = Globals.Drawings
                .OrderBy(d => d.DrawingKind)
                .ThenBy(d => d.Name)
                .ToList();

            if (Globals.Debug)
            {
                Globals.SuccessLog.Clear();

                foreach (DrawingInfo d in Globals.Drawings)
                    Globals.SuccessLog.Add(d.KeyString);

                winForm.MessageBox.Show(Globals.SuccessLog.Full, "Drawings Found");
            }

            this._visibleIndices = new List<int>();

            for (int i = 0; i < Globals.Drawings.Count; i++)
                _visibleIndices.Add(i);

            List<string> keys = Globals.Drawings
                .Select(d => d.KeyString)
                .ToList();

            this._formPairs = AG.U2.CombineAsFormPairs(keys, Globals.Drawings);

            LoadShownItems();
        }

        private void LoadShownItems()
        {
            foreach (var pair in this._formPairs)
            {
                if (pair.Visible)
                {
                    var listViewItem = new winForm.ListViewItem(pair.ItemValue.Name);
                    listViewItem.SubItems.Add(pair.ItemValue.DrawingKind);
                    listViewItem.Checked = pair.Checked;
                    listView_Drawings.Items.Add(listViewItem);
                }
            }
        }

        private void UpdateCheckedValues()
        {
            for (int i = 0; i < this.listView_Drawings.Items.Count; i++)
            {
                int pairIndex = this._visibleIndices[i];
                winForm.ListViewItem listViewItem = this.listView_Drawings.Items[i];

                this._formPairs[pairIndex].Checked = listViewItem.Checked;
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (Globals.Debug)
                winForm.MessageBox.Show("button_Delete_Click");

            ViewType vt = Globals.Doc.ActiveView.ViewType;

            if (vt == ViewType.Detail || vt==ViewType.Section)
            {
                winForm.MessageBox.Show(
                    "You are currently in a Section or Detail view.\n\n" +
                    "If this view becomes the last remaining view during deletion, Revit will block the operation.\n" +
                    "Please switch to another view type (Drafting View, Floor Plan, etc.) before proceeding.", "Error");

                return;
            }

            UpdateCheckedValues();

            this._mainWindowEventHandler.DrawingDeleteList.Clear();
            Globals.SuccessLog.Clear();
            Globals.ErrorLog.Clear();
            Globals.CancelFlag.Stop = false;

            ElementId activeId = Globals.Doc.ActiveView.Id;
            bool triedToDeleteActive = _formPairs.Any(p => !p.Checked && p.ItemValue.Id == activeId);

            if (triedToDeleteActive)
            {
                Globals.ErrorLog.Add("Active view was removed from the delete list:");
                Globals.ErrorLog.Add(" - " + AG.U.GetDrawingKind(Globals.Doc, Globals.Doc.ActiveView.Id) + ": " + Globals.Doc.ActiveView.Name, true);
            }

            foreach (var pair in this._formPairs)
                if (!pair.Checked && pair.ItemValue.Id != activeId)
                    _mainWindowEventHandler.DrawingDeleteList.Add(pair.ItemValue);

            Globals.DeleteProgressForm = new FormProgress("Deleting drawings:", startMessage: "Starting deletion...");

            //Globals.DeleteProgressForm.StartPosition = FormStartPosition.Manual;
            Globals.DeleteProgressForm.Location = this.Location;
            Globals.DeleteProgressForm.Show();

            Globals.ErrorLogForm = new FormLog("", "Failed to Delete");
            //Globals.ErrorLogForm.StartPosition = FormStartPosition.Manual;
            Globals.ErrorLogForm.Location = this.Location;

            Globals.SuccessLogForm = new FormLog("", "Successfully Deleted");
            //Globals.SuccessLogForm.StartPosition = FormStartPosition.Manual;
            Globals.SuccessLogForm.Location = new System.Drawing.Point(this.Location.X - 100, this.Location.Y + 100);

            this._mainWindowExternalEvent.Raise();
            this.Close();
        }

        private void button_CheckAll_Click(object sender, EventArgs e)
        {
            foreach (winForm.ListViewItem item in listView_Drawings.Items)
                item.Checked = true;
        }

        private void button_UncheckAll_Click(object sender, EventArgs e)
        {
            foreach (winForm.ListViewItem item in listView_Drawings.Items)
                item.Checked = false;
        }

        private void button_About_Click(object sender, EventArgs e)
        {
            var fLM = new FormLinkMessage(
                "Version 1.0\n\nPlugin by www.LetsBIMtogether.com\n\nCheck out LetsBIMtogether YouTube channel :)",
                links: new[]
                {
                    ("www.LetsBIMtogether.com", "https://letsbimtogether.com"),
                    ("LetsBIMtogether YouTube channel", "https://www.youtube.com/@letsbimtogether/playlists")
                },
                title: "About AG DAVSSEES");

            //fLM.StartPosition = FormStartPosition.Manual;
            fLM.Location = this.Location;
            fLM.ShowDialog();
        }

        private void MainWindowForm_Resize(object sender, EventArgs e)
        {
            int current = listView_Drawings.ClientSize.Width;
            int delta = current - _lastListViewWidth;

            if (_lastListViewWidth != 0 && delta != 0)
            {
                var col = listView_Drawings.Columns[0];
                col.Width = Math.Max(50, col.Width + delta);
            }

            _lastListViewWidth = current;
        }

        private void textBox_FilterKeyword_TextChanged(object sender, EventArgs e)
        {
            listView_Drawings.BeginUpdate();
            listView_Drawings.Items.Clear();
            listView_Drawings.EndUpdate();

            this._filterString = textBox_FilterKeyword.Text.ToLower();
            this._visibleIndices = new List<int>();

            foreach (var pair in this._formPairs)
            {
                bool passesFilter = PassesTextFilter(pair.ItemKey);
                pair.Visible = passesFilter;

                if (passesFilter)
                    this._visibleIndices.Add(pair.ItemIndex);
            }

            LoadShownItems();
        }

        private bool PassesTextFilter(string text)
        {
            if (string.IsNullOrEmpty(this._filterString))
                return true;

            return text.ToLower().Contains(this._filterString);
        }

    }
}
