namespace MS_CW
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.opergrid = new System.Windows.Forms.DataGridView();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.opergrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Fira Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 809);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "a=16*3+1;\r\nb=11+2*a;\r\nc=3*a+2;\r\n\r\n\r\nif(b<c) \r\n  a = 4*b;\r\n  b=12;\r\nelse\r\n  a=2*b+" +
    "3;\r\n  a=19;\r\nendif\r\n\r\nk=99;\r\ns=10;\r\n\r\nfor(i=1; i<10; i=i+1;)\r\n  k=4;\r\n  s=s+k;\r\n" +
    "end";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 827);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Translate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // opergrid
            // 
            this.opergrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.opergrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.opergrid.Location = new System.Drawing.Point(280, 12);
            this.opergrid.Name = "opergrid";
            this.opergrid.Size = new System.Drawing.Size(500, 838);
            this.opergrid.TabIndex = 4;
            // 
            // datagrid
            // 
            this.datagrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Location = new System.Drawing.Point(786, 12);
            this.datagrid.Name = "datagrid";
            this.datagrid.Size = new System.Drawing.Size(497, 838);
            this.datagrid.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(151, 827);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Interpret";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1295, 862);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.datagrid);
            this.Controls.Add(this.opergrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "CW";
            ((System.ComponentModel.ISupportInitialize)(this.opergrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView opergrid;
        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.Button button2;
    }
}

