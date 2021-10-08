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
            LexemsTable.Rows.Clear();

            FillTable_Lexems();
            FillTable_Ids();
        }
    
        private void FillTable_Lexems()
        {
            string Lexem = "";

            while ((Lexem = LexBlock.GetLexem(inputData.Text)) != "\0")
            {
                string Attr = LexBlock.GetLexemType(Lexem).ToString();
                Identifier id = new Identifier
                {
                    Name = Lexem,
                    Attr = Attr
                };
                LexBlock.table.Add(id);
                LexemsTable.Rows.Add(Lexem, Attr);
            }
        }

        private void FillTable_Ids()
        {
            LinkedListNode node = LexBlock.table.Head;
            while (node != null)
            {
                if (node.Value.Attr == "ID" || node.Value.Attr == "INT")
                    TableOfIds.Rows.Add(node.Value.Name, node.Value.Attr);
                node = node.Next;
            }
        }
    }
}
