using System;
using System.Windows.Forms;

namespace MS_CW
{
    public partial class Form1 : Form
    {
        Translator translator;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            translator = new Translator("<program>");
            translator.Parse(textBox1.Text);
            translator.inter.FillGrid(opergrid, datagrid);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            translator.inter.Execute();
            translator.inter.FillGrid(opergrid, datagrid);
        }
    }
}
