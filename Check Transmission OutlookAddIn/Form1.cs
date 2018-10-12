using Outlook = Microsoft.Office.Interop.Outlook;
using System;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace Check_Transmission_OutlookAddIn {
    public partial class FormTransmissionStatus : Form {
        private Outlook.MailItem myMail;
        private string myMailIndex;
        private Outlook.MAPIFolder saveSentFolder;
        private Outlook.MAPIFolder outBox;
        private int tickCount;
        private int waitingTime;
        
        private enum MODE { Ready, Wait, Transmit, Success, Fail };

        public FormTransmissionStatus(Outlook.MailItem myMail) {
            InitializeComponent();
            this.myMail = myMail;
            myMailIndex = myMail.ConversationIndex;
            saveSentFolder = myMail.SaveSentMessageFolder;
            outBox = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderOutbox);
            tickCount = 0;
            waitingTime = (int)Properties.Settings.Default.WaitingTime;
        }

        private void FormTransmissionStatus_Load(object sender, EventArgs e) {
            labelStatus.ForeColor = Color.Black;
            labelStatus.Text = "Ready";
            buttonClose.Text = "Quit";
        }

        private void FormTransmissionStatus_Shown(object sender, EventArgs e) {
            timerCheckStatus.Enabled = true;
        }

        private void TimerCheckStatus_Tick(object sender, EventArgs e) {
            timerCheckStatus.Enabled = false;

            if (FindMail(myMailIndex, saveSentFolder) != null) {
                ShowStatus("Successfully sent", Color.Green);
                WaitClosing(waitingTime);
                Close();
                Dispose();
            } else {
                tickCount += timerCheckStatus.Interval;
                ShowStatus("Waiting " + (tickCount / 1000) + "s", Color.Black);
                timerCheckStatus.Enabled = true;
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e) {
            timerCheckStatus.Enabled = false;
            buttonClose.Enabled = false;

            try {
                myMail.Display();
                Close();
                Dispose();
                return;
            } catch (Exception) {
                myMail = FindMail(myMailIndex, outBox);
            }

            try {
                myMail.Display();
            } catch (Exception) {
                ShowStatus("Transmission failure", Color.Red);
                ShowComment("Check the OutBox.", Color.Black);
                WaitClosing(5);
            } finally {
                Close();
                Dispose();
            }
        }

        private Outlook.MailItem FindMail(string mailIndex, Outlook.MAPIFolder folder) {
            Outlook.Items items = folder.Items;
            int count = 0;
            for (Outlook.MailItem mailItem = items.GetLast(); count++ < 10 && mailItem != null; mailItem = items.GetPrevious()) {
                if (mailItem.ConversationIndex.Equals(mailIndex)) {
                    return mailItem;
                }
            }
            return null;
        }

        private void WaitClosing(int sec) {
            for (int i = sec; i > 0; i--) {
                buttonClose.Text = "Closing in " + i + "s";
                Update();
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void ShowStatus(string s, Color color) {
            labelStatus.ForeColor = color;
            labelStatus.Text = s;
            Update();
        }

        private void ShowComment(string s, Color color) {
            labelComment.ForeColor = color;
            labelComment.Text = s;
            Update();
        }
    }
}