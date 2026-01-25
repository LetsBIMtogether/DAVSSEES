// FormProgress.cs
#region Namespaces
using System;
using System.Windows.Forms;
#endregion

namespace AG_DAVSSEES.xForm
{
    public partial class FormProgress : Form
    {
        string _taskName = "";

        public FormProgress(string taskName, string startMessage = "", int pbTotal = 100)
        {
            InitializeComponent();

            this.Icon = AG.U.GetWinFormsIcon(Globals.Icon);

            progressBar_Progress.Minimum = 0;
            progressBar_Progress.Maximum = Math.Max(1, pbTotal);
            progressBar_Progress.Value = 0;
            this._taskName = taskName;

            if(startMessage != "")
                Label_Task.Text = startMessage;
        }

        public void SetTotal(int total)
        {
            progressBar_Progress.Maximum = Math.Max(1, total);
        }

        public void SetStep(int current)
        {
            int v = Math.Max(0, Math.Min(this.progressBar_Progress.Maximum, current));
            this.progressBar_Progress.Value = v;

            // Fix for ProgressBar lag
            if (v > 0)
            {
                int back = Math.Max(0, v - 1);
                this.progressBar_Progress.Value = back;
                this.progressBar_Progress.Value = v;
            }

            Label_Task.Text = this._taskName + " " + v + " of " + progressBar_Progress.Maximum;

            Application.DoEvents();
        }

        public void SetMessage(string message)
        {
            Label_Task.Text = message ?? "";
            Application.DoEvents();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Globals.CancelFlag.Stop = true;
            button_Cancel.Enabled = false;
            Label_Task.Text = "Cancelling...";
        }

        // Event handler to catch escape press.
        // protected = accessible only within this class and its subclasses
        // override  = replaces a virtual method from the base class with custom behavior
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // If we meet the requirements on key entries
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                // Don’t close immediately, just request stop.
                Globals.CancelFlag.Stop = true;
                return true;
            }

            // Otherwise process the key normally
            return base.ProcessDialogKey(keyData);
        }

    }
}
