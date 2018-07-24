namespace Check_Transmission_OutlookAddIn
{
    partial class FormTransmissionStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.timerCheckStatus = new System.Windows.Forms.Timer(this.components);
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelComment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerCheckStatus
            // 
            this.timerCheckStatus.Tick += new System.EventHandler(this.TimerCheckStatus_Tick);
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStatus.Location = new System.Drawing.Point(13, 14);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(225, 32);
            this.labelStatus.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(75, 94);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(98, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelComment
            // 
            this.labelComment.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelComment.Location = new System.Drawing.Point(13, 56);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(225, 23);
            this.labelComment.TabIndex = 1;
            // 
            // FormTransmissionStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 125);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelComment);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormTransmissionStatus";
            this.Text = "Transmission Status";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTransmissionStatus_Load);
            this.Shown += new System.EventHandler(this.FormTransmissionStatus_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerCheckStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelComment;
    }
}