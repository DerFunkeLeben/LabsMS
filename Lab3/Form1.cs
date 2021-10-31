using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultMsg.Text = "";
            Thread.Sleep(500);

            bool result = SyntaxAnalyzer.programIsValid(data.Text);
            resultMsg.Text = result ? "Program is valid" : "Errors detected!!!";
            resultMsg.ForeColor = result ? Color.Green : Color.Red;
        }
    }
}
