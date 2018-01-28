namespace ClashBattle {
    partial class startMenu {
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
            this.btnCreatePlayer = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRandomPlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreatePlayer
            // 
            this.btnCreatePlayer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCreatePlayer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCreatePlayer.Location = new System.Drawing.Point(15, 234);
            this.btnCreatePlayer.Name = "btnCreatePlayer";
            this.btnCreatePlayer.Size = new System.Drawing.Size(143, 23);
            this.btnCreatePlayer.TabIndex = 0;
            this.btnCreatePlayer.Text = "Create Player";
            this.btnCreatePlayer.UseVisualStyleBackColor = false;
            this.btnCreatePlayer.Click += new System.EventHandler(this.btnCreatePlayer_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtName.Location = new System.Drawing.Point(230, 73);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtTitle.Location = new System.Drawing.Point(230, 121);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(51, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type The Name You Would Like:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(51, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type The Title You Would Like:";
            // 
            // btnRandomPlayer
            // 
            this.btnRandomPlayer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRandomPlayer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnRandomPlayer.Location = new System.Drawing.Point(233, 234);
            this.btnRandomPlayer.Name = "btnRandomPlayer";
            this.btnRandomPlayer.Size = new System.Drawing.Size(140, 23);
            this.btnRandomPlayer.TabIndex = 6;
            this.btnRandomPlayer.Text = "Use Default Character";
            this.btnRandomPlayer.UseVisualStyleBackColor = false;
            this.btnRandomPlayer.Click += new System.EventHandler(this.btnRandomPlayer_Click);
            // 
            // startMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(385, 280);
            this.Controls.Add(this.btnRandomPlayer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCreatePlayer);
            this.Name = "startMenu";
            this.Text = "startMenu";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.startMenu_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreatePlayer;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRandomPlayer;
    }
}