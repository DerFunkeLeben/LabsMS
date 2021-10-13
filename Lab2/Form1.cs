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
            LexBlock.table = new LinkedListNode();
            LexBlock.index = 0;

            FillTable_Lexems();
            FillTable_Ids();
        }
    
        private void FillTable_Lexems()
        {
            string Lexem = "";
            LexemsTable.Rows.Clear();

            while ((Lexem = LexBlock.GetLexem(inputData.Text)) != "\0")
            {
                string Attr = LexBlock.GetLexemType(Lexem).ToString();
                LexemsTable.Rows.Add(Lexem, Attr);

                if(!LexBlock.table.Contains(Lexem) && (Attr == "ID" || Attr == "INT"))
                {
                    Identifier id = new Identifier
                    {
                        Name = Lexem,
                        Attr = Attr
                    };
                    LexBlock.table.Add(id);
                }
            }
        }

        private void FillTable_Ids()
        {
            TableOfIds.Rows.Clear();
            LinkedListNode node = LexBlock.table.Head;
            while (node != null)
            {
                TableOfIds.Rows.Add(node.Value.Name, node.Value.Attr);
                node = node.Next;
            }

        }
    }
}
