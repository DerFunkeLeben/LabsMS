using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = inputData.Text;
            string Lexem = "";
            LexemsTable.Rows.Clear();

            while ((Lexem = LeksBlock.GetLexem(inputData.Text)) != "\0")
            {
                LeksBlock.table.Add(Lexem, LeksBlock.GetLexemType(Lexem).ToString());
                dataGridView1.Rows.Add(Lexem, LeksBlock.GetLexemType(Lexem));
            }
            Node p = LeksBlock.table.head;

            while (p != null)
            {
                if (p.type == "ID" || p.type == "INT")
                    dataGridView2.Rows.Add(p.id, p.type);
                p = p.next;
            }

        }
    }
}
