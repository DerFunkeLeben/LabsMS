
namespace Lab3
{
    partial class Form1
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
            this.data = new System.Windows.Forms.TextBox();
            this.resultMsg = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(12, 12);
            this.data.Multiline = true;
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(380, 526);
            this.data.TabIndex = 0;
            this.data.Text = "a=16*3+1;\r\nb=11+2*a;\r\nc=3*a+2;\r\n\r\nif(b<c) \r\n  a = 4*b;\r\n  b=12;\r\nelse\r\n  a=2*b+3;" +
    "\r\n  a=19;\r\nendif\r\n\r\n\r\nk=99;\r\ns=10;\r\n\r\nfor(i=1; i<10; i=i+1)\r\n  k=l;\r\n  s=s+k;\r\ne" +
    "nd";
            // 
            // resultMsg
            // 
            this.resultMsg.AutoSize = true;
            this.resultMsg.Location = new System.Drawing.Point(12, 548);
            this.resultMsg.Name = "resultMsg";
            this.resultMsg.Size = new System.Drawing.Size(85, 15);
            this.resultMsg.TabIndex = 1;
            this.resultMsg.Text = "Analize syntax:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.ForeColor = System.Drawing.Color.Green;
            this.button1.Location = new System.Drawing.Point(364, 544);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "▶";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(407, 578);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.resultMsg);
            this.Controls.Add(this.data);
            this.Name = "Form1";
            this.Text = "Lab3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox data;
        private System.Windows.Forms.Label resultMsg;
        private System.Windows.Forms.Button button1;
    }
}

