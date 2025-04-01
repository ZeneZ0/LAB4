namespace лаба_4
{
    partial class Form1
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
            btnRefill = new Button();
            txtInfo = new RichTextBox();
            btnGet = new Button();
            txtOut = new RichTextBox();
            SuspendLayout();
            // 
            // btnRefill
            // 
            btnRefill.Location = new Point(14, 14);
            btnRefill.Margin = new Padding(4, 3, 4, 3);
            btnRefill.Name = "btnRefill";
            btnRefill.Size = new Size(349, 27);
            btnRefill.TabIndex = 0;
            btnRefill.Text = "Перезаполнить";
            btnRefill.UseVisualStyleBackColor = true;
            btnRefill.Click += btnRefill_Click;
            // 
            // txtInfo
            // 
            txtInfo.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtInfo.Location = new Point(14, 47);
            txtInfo.Margin = new Padding(4, 3, 4, 3);
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.Size = new Size(349, 69);
            txtInfo.TabIndex = 1;
            txtInfo.Text = "";
            // 
            // btnGet
            // 
            btnGet.Location = new Point(259, 298);
            btnGet.Margin = new Padding(4, 3, 4, 3);
            btnGet.Name = "btnGet";
            btnGet.Size = new Size(106, 138);
            btnGet.TabIndex = 2;
            btnGet.Text = "Взять";
            btnGet.UseVisualStyleBackColor = true;
            btnGet.Click += btnGet_Click;
            // 
            // txtOut
            // 
            txtOut.Location = new Point(13, 298);
            txtOut.Margin = new Padding(4, 3, 4, 3);
            txtOut.Name = "txtOut";
            txtOut.Size = new Size(233, 138);
            txtOut.TabIndex = 3;
            txtOut.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 448);
            Controls.Add(txtOut);
            Controls.Add(btnGet);
            Controls.Add(txtInfo);
            Controls.Add(btnRefill);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Торговый автомат";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnRefill;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.RichTextBox txtOut;
    }
}