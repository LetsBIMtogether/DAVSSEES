#region Namespaces
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
#endregion

namespace AG_DAVSSEES.xForm
{
    public partial class FormLinkMessage : Form
    {
        // Overload for single link
        public FormLinkMessage(string message, string linkText = null, string url = null, string title = "") : this(
            message,
            (!string.IsNullOrWhiteSpace(linkText) && !string.IsNullOrWhiteSpace(url)) ? new[] { (linkText, url) } : null,
            title)
        {
        }

        public FormLinkMessage(string message, (string linkText, string url)[] links = null, string title = "")
        {
            InitializeComponent();

            this.Icon = AG.U.GetWinFormsIcon(Globals.Icon);
            this.Text = title;

            linkLabel_Message.Text = message ?? "";
            linkLabel_Message.Links.Clear();

            if (links == null || links.Length == 0)
                return;

            /*
            foreach ((string linkText, string url) link in links)
            {
                string linkText = link.linkText;
                string url = link.url;
            * * *
            foreach (ValueTuple<string, string> link in links)
            {
                string linkText = link.Item1;
                string url = link.Item2;
            */

            foreach (var (linkText, url) in links)
            {
                if (string.IsNullOrWhiteSpace(linkText) || string.IsNullOrWhiteSpace(url))
                    continue;

                int searchStart = 0;

                // Add a link for every occurrence of linkText inside message
                while (true)
                {
                    int start = linkLabel_Message.Text.IndexOf(linkText, searchStart, StringComparison.Ordinal);

                    if (start < 0)
                        break;

                    linkLabel_Message.Links.Add(start, linkText.Length, url);
                    searchStart = start + linkText.Length;
                }
            }
        }

        private void linkLabel_Message_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var target = e.Link.LinkData as string;

            if (string.IsNullOrWhiteSpace(target))
                return;

            try
            {
                Process.Start(new ProcessStartInfo(target) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open link:\n" + ex.Message, "Error");
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Runs after InitializeComponent()
        // After InitializeComponent() these may be incomlete: DPI scaling, layout passes, anchoring, autosizing...
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //linkLabel_Message.AutoSize = false;

            // Title bar + borders
            int nonClientHeight = this.Height - this.ClientSize.Height;

            // Client area does not include title bar + borders.
            int clientHeightWithoutMessage = this.ClientSize.Height - linkLabel_Message.Height;

            int neededH = TextRenderer.MeasureText(
                linkLabel_Message.Text ?? "",
                linkLabel_Message.Font,
                new Size(linkLabel_Message.Width, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl).Height;

            this.Height = nonClientHeight + clientHeightWithoutMessage + neededH + 5;
        }

    }
}