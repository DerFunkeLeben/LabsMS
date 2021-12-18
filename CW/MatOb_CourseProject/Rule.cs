using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MS_CW
{
    public class Rule
    {
        public int from;
        public int[] to;
        public int[] choice;
        public int[][] attr;
        public Rule(string s, Lexemer lex)
        {
            string[] temp;
            var m = new Regex(@"(\S+)\s*::=(.*?)>>>(.*?)\n").Match(s);
            from = lex.types.Get(m.Groups[1].Value.Split(new[] { '[' })[0]);
            var m1 = new Regex(@"\S+").Matches(m.Groups[2].Value);
            to = new int[m1.Count];
            attr = new int[m1.Count + 1][];
            if (m.Groups[1].Value.Contains('['))
            {
                temp = m.Groups[1].Value.Split(new[] { '[', ']', ',' });

                attr[0] = new int[temp.Length - 2];
                for (int j = 1; j < temp.Length - 1; j++)
                    attr[0][j - 1] = Int32.Parse(temp[j]);
            }
            for (int i = 0; i < m1.Count; i++)
                if (m1[i].Value.Contains('['))
                {
                    temp = m1[i].Value.Split(new[] { '[', ']', ',' });
                    attr[i + 1] = new int[temp.Length - 2];
                    for (int j = 1; j < temp.Length - 1; j++)
                        attr[i + 1][j - 1] = Int32.Parse(temp[j]);
                }
            for (int i = 0; i < m1.Count; i++)
                to[i] = lex.types.Get(m1[i].Value.Split(new[] { '[' })[0]);
            var m2 = new Regex(@"\S+").Matches(m.Groups[3].Value);
            choice = new int[m2.Count];
            for (int i = 0; i < m2.Count; i++)
                choice[i] = lex.types.Get(m2[i].Value.Split(new[] { '[' })[0]);
        }
        public void ApplyRule(Stack<Lexeme> PDA, Map<int, int> addresses, Lexemer lex)
        {
            Map<int, int> temp = new Map<int, int>();
            Lexeme top = PDA.Peek();
            if (attr != null)
            {
                if (attr[0] != null)
                    for (int i = 0; i < attr[0].Length; i++)
                        if (!temp.Has(attr[0][i]))
                            temp.Add(attr[0][i], top.attr[i]);
                        else
                            addresses[top.attr[i]] = addresses[temp[attr[0][i]]];
                PDA.Pop();
                for (int i = attr.Length - 1; i >= 1; i--)
                {
                    Lexeme t = lex.types[to[i - 1]].Copy();
                    for (int j = 0; attr[i] != null && j < attr[i].Length; j++)
                    {
                        if (temp.Has(attr[i][j]))
                            t.attr[j] = temp[attr[i][j]];
                        else
                        {
                            temp.Add(attr[i][j], addresses.Size);
                            addresses.Add(addresses.Size, -1);
                            t.attr[j] = temp[attr[i][j]];
                        }
                    }
                    PDA.Push(t);
                }
            }
            else PDA.Pop();
        }
        public Rule(int tfrom)
        {
            from = tfrom;
            choice = new int[1];
            to = new int[0];
            choice[0] = tfrom;
        }
    }

}
