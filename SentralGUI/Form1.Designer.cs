namespace SentralGUI
{
    partial class SentrallVindu
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
            this.AlarmVindu = new System.Windows.Forms.ListBox();
            this.rapportTextBox = new System.Windows.Forms.TextBox();
            this.adminTextBox = new System.Windows.Forms.TextBox();
            this.SendRapportKommando = new System.Windows.Forms.Button();
            this.AvbrytRapportKommando = new System.Windows.Forms.Button();
            this.SendAdminKommando = new System.Windows.Forms.Button();
            this.AvbrytAdminKommando = new System.Windows.Forms.Button();
            this.RapportComboBox = new System.Windows.Forms.ComboBox();
            this.ServerComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HjelpKommando = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ServerVindu = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // AlarmVindu
            // 
            this.AlarmVindu.FormattingEnabled = true;
            this.AlarmVindu.ItemHeight = 15;
            this.AlarmVindu.Location = new System.Drawing.Point(12, 12);
            this.AlarmVindu.Name = "AlarmVindu";
            this.AlarmVindu.Size = new System.Drawing.Size(477, 199);
            this.AlarmVindu.TabIndex = 0;
            // 
            // rapportTextBox
            // 
            this.rapportTextBox.Location = new System.Drawing.Point(12, 256);
            this.rapportTextBox.Name = "rapportTextBox";
            this.rapportTextBox.Size = new System.Drawing.Size(477, 23);
            this.rapportTextBox.TabIndex = 2;
            // 
            // adminTextBox
            // 
            this.adminTextBox.Location = new System.Drawing.Point(495, 256);
            this.adminTextBox.Name = "adminTextBox";
            this.adminTextBox.Size = new System.Drawing.Size(473, 23);
            this.adminTextBox.TabIndex = 3;
            // 
            // SendRapportKommando
            // 
            this.SendRapportKommando.Location = new System.Drawing.Point(12, 285);
            this.SendRapportKommando.Name = "SendRapportKommando";
            this.SendRapportKommando.Size = new System.Drawing.Size(236, 23);
            this.SendRapportKommando.TabIndex = 4;
            this.SendRapportKommando.Text = "Send";
            this.SendRapportKommando.UseVisualStyleBackColor = true;
            this.SendRapportKommando.Click += new System.EventHandler(this.SendRapportKommando_Click);
            // 
            // AvbrytRapportKommando
            // 
            this.AvbrytRapportKommando.Location = new System.Drawing.Point(254, 285);
            this.AvbrytRapportKommando.Name = "AvbrytRapportKommando";
            this.AvbrytRapportKommando.Size = new System.Drawing.Size(235, 23);
            this.AvbrytRapportKommando.TabIndex = 5;
            this.AvbrytRapportKommando.Text = "Reset";
            this.AvbrytRapportKommando.UseVisualStyleBackColor = true;
            this.AvbrytRapportKommando.Click += new System.EventHandler(this.AvbrytRapportKommando_Click);
            // 
            // SendAdminKommando
            // 
            this.SendAdminKommando.Location = new System.Drawing.Point(495, 285);
            this.SendAdminKommando.Name = "SendAdminKommando";
            this.SendAdminKommando.Size = new System.Drawing.Size(230, 23);
            this.SendAdminKommando.TabIndex = 6;
            this.SendAdminKommando.Text = "Send";
            this.SendAdminKommando.UseVisualStyleBackColor = true;
            this.SendAdminKommando.Click += new System.EventHandler(this.SendAdminKommando_Click);
            // 
            // AvbrytAdminKommando
            // 
            this.AvbrytAdminKommando.Location = new System.Drawing.Point(731, 285);
            this.AvbrytAdminKommando.Name = "AvbrytAdminKommando";
            this.AvbrytAdminKommando.Size = new System.Drawing.Size(237, 23);
            this.AvbrytAdminKommando.TabIndex = 7;
            this.AvbrytAdminKommando.Text = "Reset";
            this.AvbrytAdminKommando.UseVisualStyleBackColor = true;
            this.AvbrytAdminKommando.Click += new System.EventHandler(this.AvbrytAdminKommando_Click);
            // 
            // RapportComboBox
            // 
            this.RapportComboBox.FormattingEnabled = true;
            this.RapportComboBox.Location = new System.Drawing.Point(12, 335);
            this.RapportComboBox.Name = "RapportComboBox";
            this.RapportComboBox.Size = new System.Drawing.Size(477, 23);
            this.RapportComboBox.TabIndex = 8;
            // 
            // ServerComboBox
            // 
            this.ServerComboBox.FormattingEnabled = true;
            this.ServerComboBox.Location = new System.Drawing.Point(495, 335);
            this.ServerComboBox.Name = "ServerComboBox";
            this.ServerComboBox.Size = new System.Drawing.Size(473, 23);
            this.ServerComboBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Repport Command";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(674, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Server command";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Velg Rapport";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(694, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Velg Server";
            // 
            // HjelpKommando
            // 
            this.HjelpKommando.Location = new System.Drawing.Point(12, 364);
            this.HjelpKommando.Name = "HjelpKommando";
            this.HjelpKommando.Size = new System.Drawing.Size(178, 23);
            this.HjelpKommando.TabIndex = 14;
            this.HjelpKommando.Text = "Help";
            this.HjelpKommando.UseVisualStyleBackColor = true;
            this.HjelpKommando.Click += new System.EventHandler(this.HjelpKommando_Click);
            // 
            // ServerVindu
            // 
            this.ServerVindu.Location = new System.Drawing.Point(495, 12);
            this.ServerVindu.Name = "ServerVindu";
            this.ServerVindu.Size = new System.Drawing.Size(473, 199);
            this.ServerVindu.TabIndex = 15;
            this.ServerVindu.Text = "";
            // 
            // SentrallVindu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(980, 410);
            this.Controls.Add(this.ServerVindu);
            this.Controls.Add(this.HjelpKommando);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerComboBox);
            this.Controls.Add(this.RapportComboBox);
            this.Controls.Add(this.AvbrytAdminKommando);
            this.Controls.Add(this.SendAdminKommando);
            this.Controls.Add(this.AvbrytRapportKommando);
            this.Controls.Add(this.SendRapportKommando);
            this.Controls.Add(this.adminTextBox);
            this.Controls.Add(this.rapportTextBox);
            this.Controls.Add(this.AlarmVindu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SentrallVindu";
            this.Text = "Sentralen For Adgangskontroll";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox AlarmVindu;
        private TextBox rapportTextBox;
        private TextBox adminTextBox;
        private Button SendRapportKommando;
        private Button AvbrytRapportKommando;
        private Button SendAdminKommando;
        private Button AvbrytAdminKommando;
        private ComboBox RapportComboBox;
        private ComboBox ServerComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button HjelpKommando;
        private System.Windows.Forms.Timer timer1;
        private TextBox InformasjonsVinduTxt;
        private RichTextBox ServerVindu;
    }
}
