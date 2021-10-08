﻿namespace Lab2 {
    static class LexBlock
    {
        public enum LexType
        {
            INVALID,
            ID,
            INT,
            OP_SET,
            OP_MULT,
            OP_PLS,
            OP_LESS,
            OP_MORE,
            DELIM_COM,
            DELIM_SEMI,
            BRA_OPN,
            BRA_CLS,
            KW_IF,
            KW_ELSE,
            KW_ENDIF,
            KW_FOR,
            KW_FOREND,
            END,
        }

        public static string Input { get { return Input; } set { Input = value; index = 0; } }

        public static int index { get; set; }
        public static string Terminal = "+*(),;=<> \n\r";
        public static LinkedListNode table = new LinkedListNode();

        public static string GetLexem(string data)
        {
            while (index < data.Length)
            {

                if (data[index] == ' '
                 || data[index] == '\0'
                 || data[index] == '\n'
                 || data[index] == '\r')
                {
                    return data[index].ToString();
                }
                index++;
            }

            if (data[index] == '=' )
            {
                index++;
                return "=";
            }
            for (int i = index; i < data.Length; i++)
            {
                if (Terminal.Contains(data[i]))
                {
                    if (index == i)
                    {
                        index = i + 1;
                        return data[i].ToString();
                    }
                    index = i;
                    return data.Substring(index, i - index);
                }
                if (i == data.Length - 1)
                {
                    index = i + 1;
                    return data.Substring(index, i - index + 1);
                }
            }
            return "\0";
        }
        public static LexType GetLexemType(string lex)
        {
            switch (lex)
            {
                case "if": return LexType.KW_IF;
                case "else": return LexType.KW_ELSE;
                case "endif": return LexType.KW_ENDIF;
                case "for": return LexType.KW_FOR;
                case "end": return LexType.KW_FOREND;
                case "(": return LexType.BRA_OPN;
                case ")": return LexType.BRA_CLS;
                case "<": return LexType.OP_LESS;
                case ">": return LexType.OP_MORE;
                case "=": return LexType.OP_SET;
                case "+": return LexType.OP_PLS;
                case "*": return LexType.OP_MULT;
                case ";": return LexType.DELIM_SEMI;
                case ",": return LexType.DELIM_COM;
                case "\0": return LexType.END;
                case "\r": return LexType.INVALID;
                case "\n": return LexType.INVALID;
                default: break;
            }

            int num = 0;
            if (int.TryParse(lex, out num))
                return LexType.INT;

            foreach (int i in lex)
                if ((lex[i] < 'a' || lex[i] > 'z') && (lex[i] < 'A' || lex[i] > 'Z'))
                    return LexType.INVALID;

            return LexType.ID;
        }
    }
}
