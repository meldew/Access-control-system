namespace CardReaderGUI
{
    partial class CardReader_GUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CardReaderInformation = new System.Windows.Forms.Label();
            this.CardReader_AccessButton = new System.Windows.Forms.Button();
            this.CardReader_txtCardID = new System.Windows.Forms.TextBox();
            this.Kortleser_DørLukket = new System.Windows.Forms.PictureBox();
            this.Kortleser_DørÅpen = new System.Windows.Forms.PictureBox();
            this.Kortleser_Alarm = new System.Windows.Forms.PictureBox();
            this.Kortleser_TimeLeft = new System.Windows.Forms.Label();
            this.CardReaderDoorClosed = new System.Windows.Forms.Label();
            this.CardReaderDoorOpen = new System.Windows.Forms.Label();
            this.CardReaderAlarm = new System.Windows.Forms.Label();
            this.CardReader_ResetButton = new System.Windows.Forms.Button();
            this.Kortleser_TekstPINkode = new System.Windows.Forms.TextBox();
            this.CardReader_CardIDtxt = new System.Windows.Forms.Label();
            this.CardReader_PinCodetxt = new System.Windows.Forms.Label();
            this.CardReader_LoginButton = new System.Windows.Forms.Button();
            this.CardReader_TimeLeftTimer = new System.Windows.Forms.Timer(this.components);
            this.CounterLabel = new System.Windows.Forms.Label();
            this.bwSeriellKommunikasjon = new System.ComponentModel.BackgroundWorker();
            this.bwSerialCommunication = new System.ComponentModel.BackgroundWorker();
            this.InformationListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.Kortleser_DørLukket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kortleser_DørÅpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kortleser_Alarm)).BeginInit();
            this.SuspendLayout();
            // 
            // CardReaderInformation, test
            // 
            this.CardReaderInformation.AutoSize = true;
            this.CardReaderInformation.Location = new System.Drawing.Point(12, 9);
            this.CardReaderInformation.Name = "CardReaderInformation";
            this.CardReaderInformation.Size = new System.Drawing.Size(72, 15);
            this.CardReaderInformation.TabIndex = 1;
            
            this.CardReaderInformation.Text = "Information:";
            // 
            // CardReader_AccessButton
            // 
            this.CardReader_AccessButton.Location = new System.Drawing.Point(12, 308);
            this.CardReader_AccessButton.Name = "CardReader_AccessButton";
            this.CardReader_AccessButton.Size = new System.Drawing.Size(198, 66);
            this.CardReader_AccessButton.TabIndex = 2;
            this.CardReader_AccessButton.Text = "Access control";
            this.CardReader_AccessButton.UseVisualStyleBackColor = true;
            this.CardReader_AccessButton.Click += new System.EventHandler(this.CardReader_AccessButton_Click);
            // 
            // CardReader_txtCardID
            // 
            this.CardReader_txtCardID.Location = new System.Drawing.Point(12, 408);
            this.CardReader_txtCardID.Name = "CardReader_txtCardID";
            this.CardReader_txtCardID.Size = new System.Drawing.Size(417, 21);
            this.CardReader_txtCardID.TabIndex = 3;
            // 
            // Kortleser_DørLukket
            // 
            this.Kortleser_DørLukket.BackColor = System.Drawing.Color.Lime;
            this.Kortleser_DørLukket.Location = new System.Drawing.Point(12, 243);
            this.Kortleser_DørLukket.Name = "Kortleser_DørLukket";
            this.Kortleser_DørLukket.Size = new System.Drawing.Size(121, 50);
            this.Kortleser_DørLukket.TabIndex = 4;
            this.Kortleser_DørLukket.TabStop = false;
            // 
            // Kortleser_DørÅpen
            // 
            this.Kortleser_DørÅpen.BackColor = System.Drawing.Color.Yellow;
            this.Kortleser_DørÅpen.Location = new System.Drawing.Point(164, 243);
            this.Kortleser_DørÅpen.Name = "Kortleser_DørÅpen";
            this.Kortleser_DørÅpen.Size = new System.Drawing.Size(121, 50);
            this.Kortleser_DørÅpen.TabIndex = 5;
            this.Kortleser_DørÅpen.TabStop = false;
            // 
            // Kortleser_Alarm
            // 
            this.Kortleser_Alarm.BackColor = System.Drawing.Color.Red;
            this.Kortleser_Alarm.Location = new System.Drawing.Point(308, 243);
            this.Kortleser_Alarm.Name = "Kortleser_Alarm";
            this.Kortleser_Alarm.Size = new System.Drawing.Size(121, 50);
            this.Kortleser_Alarm.TabIndex = 6;
            this.Kortleser_Alarm.TabStop = false;
            // 
            // Kortleser_TimeLeft
            // 
            this.Kortleser_TimeLeft.AutoSize = true;
            this.Kortleser_TimeLeft.Location = new System.Drawing.Point(323, 9);
            this.Kortleser_TimeLeft.Name = "Kortleser_TimeLeft";
            this.Kortleser_TimeLeft.Size = new System.Drawing.Size(61, 15);
            this.Kortleser_TimeLeft.TabIndex = 7;
            this.Kortleser_TimeLeft.Text = "Time Left:";
            // 
            // CardReaderDoorClosed
            // 
            this.CardReaderDoorClosed.AutoSize = true;
            this.CardReaderDoorClosed.Location = new System.Drawing.Point(12, 225);
            this.CardReaderDoorClosed.Name = "CardReaderDoorClosed";
            this.CardReaderDoorClosed.Size = new System.Drawing.Size(73, 15);
            this.CardReaderDoorClosed.TabIndex = 8;
            this.CardReaderDoorClosed.Text = "Door closed";
            // 
            // CardReaderDoorOpen
            // 
            this.CardReaderDoorOpen.AutoSize = true;
            this.CardReaderDoorOpen.Location = new System.Drawing.Point(164, 225);
            this.CardReaderDoorOpen.Name = "CardReaderDoorOpen";
            this.CardReaderDoorOpen.Size = new System.Drawing.Size(65, 15);
            this.CardReaderDoorOpen.TabIndex = 9;
            this.CardReaderDoorOpen.Text = "Door open";
            // 
            // CardReaderAlarm
            // 
            this.CardReaderAlarm.AutoSize = true;
            this.CardReaderAlarm.Location = new System.Drawing.Point(308, 225);
            this.CardReaderAlarm.Name = "CardReaderAlarm";
            this.CardReaderAlarm.Size = new System.Drawing.Size(39, 15);
            this.CardReaderAlarm.TabIndex = 10;
            this.CardReaderAlarm.Text = "Alarm";
            // 
            // CardReader_ResetButton
            // 
            this.CardReader_ResetButton.Location = new System.Drawing.Point(232, 308);
            this.CardReader_ResetButton.Name = "CardReader_ResetButton";
            this.CardReader_ResetButton.Size = new System.Drawing.Size(197, 66);
            this.CardReader_ResetButton.TabIndex = 11;
            this.CardReader_ResetButton.Text = "Reset";
            this.CardReader_ResetButton.UseVisualStyleBackColor = true;
            this.CardReader_ResetButton.Click += new System.EventHandler(this.CardReader_ResetButton_Click);
            // 
            // Kortleser_TekstPINkode
            // 
            this.Kortleser_TekstPINkode.Location = new System.Drawing.Point(12, 450);
            this.Kortleser_TekstPINkode.Name = "Kortleser_TekstPINkode";
            this.Kortleser_TekstPINkode.Size = new System.Drawing.Size(417, 21);
            this.Kortleser_TekstPINkode.TabIndex = 12;
            // 
            // CardReader_CardIDtxt
            // 
            this.CardReader_CardIDtxt.AutoSize = true;
            this.CardReader_CardIDtxt.Location = new System.Drawing.Point(12, 390);
            this.CardReader_CardIDtxt.Name = "CardReader_CardIDtxt";
            this.CardReader_CardIDtxt.Size = new System.Drawing.Size(49, 15);
            this.CardReader_CardIDtxt.TabIndex = 13;
            this.CardReader_CardIDtxt.Text = "Card-ID";
            // 
            // CardReader_PinCodetxt
            // 
            this.CardReader_PinCodetxt.AutoSize = true;
            this.CardReader_PinCodetxt.Location = new System.Drawing.Point(12, 432);
            this.CardReader_PinCodetxt.Name = "CardReader_PinCodetxt";
            this.CardReader_PinCodetxt.Size = new System.Drawing.Size(58, 15);
            this.CardReader_PinCodetxt.TabIndex = 14;
            this.CardReader_PinCodetxt.Text = "PIN-code";
            // 
            // CardReader_LoginButton
            // 
            this.CardReader_LoginButton.Location = new System.Drawing.Point(125, 490);
            this.CardReader_LoginButton.Name = "CardReader_LoginButton";
            this.CardReader_LoginButton.Size = new System.Drawing.Size(197, 39);
            this.CardReader_LoginButton.TabIndex = 15;
            this.CardReader_LoginButton.Text = "Login";
            this.CardReader_LoginButton.UseVisualStyleBackColor = true;
            this.CardReader_LoginButton.Click += new System.EventHandler(this.CardReader_LoginButton_Click);
            // 
            // CardReader_TimeLeftTimer
            // 
            this.CardReader_TimeLeftTimer.Enabled = true;
            this.CardReader_TimeLeftTimer.Interval = 5000;
            // 
            // CounterLabel
            // 
            this.CounterLabel.AutoSize = true;
            this.CounterLabel.Location = new System.Drawing.Point(388, 9);
            this.CounterLabel.Name = "CounterLabel";
            this.CounterLabel.Size = new System.Drawing.Size(0, 15);
            this.CounterLabel.TabIndex = 16;
            // 
            // bwSerialCommunication
            // 
            this.bwSerialCommunication.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSerialCommunication_DoWork);
            this.bwSerialCommunication.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSerialCommunication_RunWorkerCompleted);
            // 
            // InformationListBox
            // 
            this.InformationListBox.FormattingEnabled = true;
            this.InformationListBox.ItemHeight = 15;
            this.InformationListBox.Location = new System.Drawing.Point(15, 30);
            this.InformationListBox.Name = "InformationListBox";
            this.InformationListBox.Size = new System.Drawing.Size(405, 184);
            this.InformationListBox.TabIndex = 17;
            // 
            // CardReader_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(445, 543);
            this.Controls.Add(this.InformationListBox);
            this.Controls.Add(this.CounterLabel);
            this.Controls.Add(this.CardReader_LoginButton);
            this.Controls.Add(this.CardReader_PinCodetxt);
            this.Controls.Add(this.CardReader_CardIDtxt);
            this.Controls.Add(this.Kortleser_TekstPINkode);
            this.Controls.Add(this.CardReader_ResetButton);
            this.Controls.Add(this.CardReaderAlarm);
            this.Controls.Add(this.CardReaderDoorOpen);
            this.Controls.Add(this.CardReaderDoorClosed);
            this.Controls.Add(this.Kortleser_TimeLeft);
            this.Controls.Add(this.Kortleser_Alarm);
            this.Controls.Add(this.Kortleser_DørÅpen);
            this.Controls.Add(this.Kortleser_DørLukket);
            this.Controls.Add(this.CardReader_txtCardID);
            this.Controls.Add(this.CardReader_AccessButton);
            this.Controls.Add(this.CardReaderInformation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CardReader_GUI";
            this.Text = "Card Reader";
            ((System.ComponentModel.ISupportInitialize)(this.Kortleser_DørLukket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kortleser_DørÅpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Kortleser_Alarm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label CardReaderInformation;
        private Button CardReader_AccessButton;
        private TextBox CardReader_txtCardID;
        private PictureBox Kortleser_DørLukket;
        private PictureBox Kortleser_DørÅpen;
        private PictureBox Kortleser_Alarm;
        private Label Kortleser_TimeLeft;
        private Label CardReaderDoorClosed;
        private Label CardReaderDoorOpen;
        private Label CardReaderAlarm;
        private Button CardReader_ResetButton;
        private TextBox Kortleser_TekstPINkode;
        private Label CardReader_CardIDtxt;
        private Label CardReader_PinCodetxt;
        private Button CardReader_LoginButton;
        private System.Windows.Forms.Timer CardReader_TimeLeftTimer;
        private Label CounterLabel;
        private System.ComponentModel.BackgroundWorker bwSeriellKommunikasjon;
        private System.ComponentModel.BackgroundWorker bwSerialCommunication;
        private ListBox InformationListBox;
    }
}
