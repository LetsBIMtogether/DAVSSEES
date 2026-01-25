#region Namespaces
using System;
using System.Windows.Forms;
using System.IO;
#endregion

namespace AG_DAVSSEES.xForm
{
    public partial class FormLog : Form
    {
        public FormLog(string log, string title)
        {
            InitializeComponent();

            this.Icon = AG.U.GetWinFormsIcon(Globals.Icon);
            this.Text = title;

            textBox_Log.Text = log;
        }

        public void Update(string log)
        {
            textBox_Log.Text = log;
            Application.DoEvents();
        }
        private void button_SaveToDesktop_Click(object sender, EventArgs e)
        {
            string title = this.Text ?? "Log";
            string date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = title + " - " + date + ".txt";

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(desktop, fileName);

            try
            {
                File.WriteAllText(fullPath, textBox_Log.Text);
                MessageBox.Show("Log saved to Desktop.", "Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save log:\n" + ex.Message, "Error");
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}