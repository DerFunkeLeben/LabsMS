using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MS_CW
{
    public class Translator
    {
        Rule[,] table;
        Lexemer lex;
        Stack<Lexeme> PDA;
        public Interpretator inter;
        public Translator(string start)
        {
            string GRAMMAR = Grammar.LL1;

            lex = new Lexemer(GRAMMAR);
            PDA = new Stack<Lexeme>();
            inter = new Interpretator();
            InitRules(GRAMMAR);
            PDA.Push(lex.types[lex.types.Get("EOF")].Copy());
            PDA.Push(new Lexeme(lex.types.Get(start), start));
        }
        void InitRules(string GRAMMAR)
        {
            table = new Rule[lex.types.Size, lex.types.Size];
            var m = new Regex(@"(\S+)\s*::=(.*?)>>>(.*?)\n").Matches(GRAMMAR);

            Rule rule;
            for (int i = 0; i < m.Count; i++)
            {
                rule = new Rule(m[i].Value, lex);
                for (int j = 0; j < rule.choice.Length; j++)
                    table[rule.from, rule.choice[j]] = rule;
            }
            for (int i = 0; i < lex.types.Size; i++)
                table[i, i] = new Rule(i);
        }
        public void PushCommand(Lexeme a)
        {
            switch (a.Name)
            {
                case "{MOV}":
                    a.Name = "Assign";
                    inter.AddCommand((Command)a);
                    PDA.Pop();
                    break;
                case "{ADD}":
                    inter.variables.Add(inter.variables.Size, new Var(inter.variables[inter.addresses[a.attr[0]]].Name + "+" + inter.variables[inter.addresses[a.attr[1]]].Name));
                    inter.addresses[a.attr[2]] = inter.variables.Size - 1;
                    inter.AddCommand((Command)a);
                    a.Name = "Add";
                    PDA.Pop();
                    break;
                case "{MUL}":
                    inter.variables.Add(inter.variables.Size, new Var(inter.variables[inter.addresses[a.attr[0]]].Name + "*" + inter.variables[inter.addresses[a.attr[1]]].Name));
                    inter.addresses[a.attr[2]] = inter.variables.Size - 1;
                    a.Name = "Multiply";
                    inter.AddCommand((Command)a);
                    PDA.Pop();
                    break;
                case "{JCC}":
                    if (inter.addresses[a.attr[0]] == -1)
                    {
                        inter.labels.Add(a.attr[0], inter.labels.Size);
                        inter.addresses[a.attr[0]] = inter.labels.Size - 1;
                    }
                    a.Name = "Conditional_jump";
                    inter.AddCommand((Command)a);
                    PDA.Pop();
                    break;
                case "{JMP}":
                    if (inter.addresses[a.attr[0]] == -1)
                    {
                        inter.labels.Add(a.attr[0], inter.labels.Size);
                        inter.addresses[a.attr[0]] = inter.labels.Size - 1;
                    }
                    a.Name = "Unconditional_jump";
                    inter.AddCommand((Command)a);
                    PDA.Pop();
                    break;
                case "{>}":
                    inter.variables.Add(inter.variables.Size, new Var(inter.variables[inter.addresses[a.attr[0]]].Name + ">" + inter.variables[inter.addresses[a.attr[1]]].Name));
                    inter.addresses[a.attr[2]] = inter.variables.Size - 1;
                    a.Name = "More";
                    inter.AddCommand((Command)a);
                    PDA.Pop();
                    break;
                case "{<}":
                    inter.variables.Add(inter.variables.Size, new Var(inter.variables[inter.addresses[a.attr[0]]].Name + "<" + inter.variables[inter.addresses[a.attr[1]]].Name));
                    inter.addresses[a.attr[2]] = inter.variables.Size - 1;
                    a.Name = "Less";
                    inter.AddCommand((Command)a);
                    PDA.Pop();
                    break;
                case "{label}":
                    if (inter.addresses[a.attr[0]] == -1)
                    {
                        inter.labels.Add(a.attr[0], inter.labels.Size);
                        inter.addresses[a.attr[0]] = inter.labels.Size - 1;
                    }
                    a.Name = "Label";
                    inter.AddCommand((Command)a);
                    PDA.Pop();
                    break;
            }
        }
        public bool ParseStep(Lexeme a)
        {
            int type = a.Type;
            int stacktype = PDA.Peek().Type;
            do
            {
                if (PDA.Peek().IsCommand())
                {
                    PushCommand(PDA.Peek());
                    continue;
                }
                if (PDA.Peek().Name == "<ID>" && a.Type == lex.types.Get("<ID>"))
                {
                    if ((inter.variables.Size == 0 || inter.variables.Get(a.Name) == 0))
                    {
                        inter.variables.Add(inter.variables.Size, new Var(a.Name));
                        inter.addresses[PDA.Peek().attr[0]] = inter.variables.Size - 1;
                    }
                    else
                    {
                        inter.addresses[PDA.Peek().attr[0]] = inter.variables.Get(a.Name);
                    }
                }
                if (PDA.Peek().Name == "<INT>" && a.Type == lex.types.Get("<INT>"))
                {
                    if ((inter.variables.Size == 0 || inter.variables.Get(a.Name) == 0))
                    {
                        inter.variables.Add(inter.variables.Size, new Var(a.Name, Int32.Parse(a.Name)));
                        inter.addresses[PDA.Peek().attr[0]] = inter.variables.Size - 1;
                    }
                    else
                    {
                        inter.addresses[PDA.Peek().attr[0]] = inter.variables.Get(a.Name);
                    }
                }
                stacktype = PDA.Peek().Type;
                Rule rule = table[stacktype, type];
                if (rule == null)
                {
                    MessageBox.Show("Expected " + PDA.Peek().Name + " but got " + a.Name);
                    return false;
                }
                else
                {
                    rule.ApplyRule(PDA, inter.addresses, lex);
                }
            } while (stacktype != type);
            return true;
        }
        public void Parse(string input)
        {
            lex.Input = input;
            Lexeme a = null;
            do
            {
                a = lex.GetLexeme();
                if (!ParseStep(a))
                    return;
            } while (a.Type != lex.types.Get("EOF"));
            MessageBox.Show("Allow");
        }
       }

}
