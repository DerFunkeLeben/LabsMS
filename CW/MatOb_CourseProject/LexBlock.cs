using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MS_CW
{
    public class Lexemer
    {
        public Map<int, Lexeme> types;

        int Index { get; set; }
        public string Input { get; set; }
        public Lexemer(string GRAMMAR)
        {
            types = new Map<int, Lexeme>();
            Index = 0;
            InitLex(GRAMMAR);
        }
        public void InitLex(string GRAMMAR)
        {
            types.Add(types.Size, new Lexeme(types.Size, "INVALID"));
            types.Add(types.Size, new Lexeme(types.Size, "EOF"));

            var m = new Regex(@"\S+").Matches(GRAMMAR);

            for (int i = 0; i < m.Count; i++)
                if (m[i].Value != "::=" && m[i].Value != ">>>" && types.Get(m[i].Value) == 0 && m[i].Value != "EOF")
                    if (m[i].Value.Contains('['))
                        if (m[i].Value.Contains('{'))
                            types.Add(types.Size, new Command(types.Size, m[i].Value.Substring(0, m[i].Value.IndexOf('[', 0)), new int[m[i].Value.Split(new[] { ',' }).Length]));
                        else
                            types.Add(types.Size, new Lexeme(types.Size, m[i].Value.Substring(0, m[i].Value.IndexOf('[', 0)), new int[m[i].Value.Split(new[] { ',' }).Length]));
                    else
                        types.Add(types.Size, new Lexeme(types.Size, m[i].Value));

        }
        public Lexeme GetLexeme()
        {
            while (Index != Input.Length && Char.IsWhiteSpace(Input[Index]))
                Index++;
            if (Index == Input.Length)
                return new Lexeme(types.Get("EOF"), "EOF");
            if (types.Get(Input.Substring(Index, 1)) != 0 && types.Has(types.Get(Input.Substring(Index, 1))))
            {
                Index++;
                return new Lexeme(types.Get(Input.Substring(Index - 1, 1)), Input.Substring(Index - 1, 1));
            }
            if (Index != Input.Length - 1 && types.Get(Input.Substring(Index, 2)) != 0 && types.Has(types.Get(Input.Substring(Index, 2))))
            {
                Index += 2;
                return new Lexeme(types.Get(Input.Substring(Index - 2, 2)), Input.Substring(Index - 2, 2));
            }
            if (!Char.IsDigit(Input[Index]))
            {
                int start = Index;
                while (Index != Input.Length && (Char.IsLetter(Input[Index]) || Char.IsDigit(Input[Index])))
                    Index++;
                if (types.Get(Input.Substring(start, Index - start)) != 0 && types.Has(types.Get(Input.Substring(start, Index - start))))
                    return new Lexeme(types.Get(Input.Substring(start, Index - start)), Input.Substring(start, Index - start));
                else
                    return new Lexeme(types.Get("<ID>"), Input.Substring(start, Index - start));
            }
            else
            {
                int start = Index;
                while (Index != Input.Length && (Char.IsLetter(Input[Index]) || Char.IsDigit(Input[Index])))
                    Index++;
                if (int.TryParse(Input.Substring(start, Index - start), out int a))
                    return new Lexeme(types.Get("<INT>"), Input.Substring(start, Index - start));
                else
                    return new Lexeme(types.Get("INVALID"), Input.Substring(start, Index - start));
            }
        }
        public void Reset()
        {
            Index = 0;
        }
    }

    public class Var : IComparable
    {
        public int Data;
        public string Name { get; set; }
        public bool Set { get; set; }
        public Var(string name)
        {
            Name = name;
            Set = false;
        }
        public Var(string name, int data)
        {
            Data = data;
            Name = name;
            Set = true;
        }
        public int CompareTo(object obj)
        {
            return Name.CompareTo((string)obj);
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Lexeme : IComparable
    {
        public int Type { get; }
        public string Name { get; set; }
        public int[] attr;
        public virtual bool IsCommand()
        {
            return false;
        }
        public virtual Lexeme Copy()
        {
            return new Lexeme(Type, Name, (attr != null) ? new int[attr.Length] : null);
        }
        public int CompareTo(object obj)
        {
            return Name.CompareTo((string)obj);
        }
        public Lexeme(int type, string name, int[] attr = null)
        {
            Type = type;
            Name = name;
            this.attr = attr;
        }
    }
    public class Command : Lexeme
    {
        public Command(int type, string name, int[] attr = null) : base(type, name, attr) { }
        public override Lexeme Copy()
        {
            return new Command(Type, Name, (attr != null) ? new int[attr.Length] : null);
        }
        public override bool IsCommand()
        {
            return true;
        }
    }

       
}
