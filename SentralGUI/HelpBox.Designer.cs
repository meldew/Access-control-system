namespace SentralGUI
{
    partial class SentralGUI_HelpBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_HelpBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lb_HelpBox
            // 
            this.lb_HelpBox.FormattingEnabled = true;
            this.lb_HelpBox.ItemHeight = 15;
            this.lb_HelpBox.Location = new System.Drawing.Point(4, 6);
            this.lb_HelpBox.Name = "lb_HelpBox";
            this.lb_HelpBox.Size = new System.Drawing.Size(858, 529);
            this.lb_HelpBox.TabIndex = 0;
            // 
            // SentralGUI_HelpBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(864, 542);
            this.Controls.Add(this.lb_HelpBox);
            this.Name = "SentralGUI_HelpBox";
            this.Text = "Hjelp";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lb_HelpBox;
    }
}