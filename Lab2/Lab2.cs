using System;

namespace Lab2 {
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

        public static int index { get; set; }
        public static char[] Terminal = { '+','*','(',')',',',';','=','<','>',' ','\n','\r' };
        public static LinkedListNode table = new LinkedListNode();

        private static bool TerminalExists(char item)
        {
            foreach (char lex in Terminal)
                if (lex == item) return true;
            return false;
        }
        private static bool isLetter(char l) => (l >= 'a' && l <= 'z') || (l >= 'A' && l <= 'Z');

        public static string GetLexem(string data)
        {
            for(; (index < data.Length) 
               && (data[index] == ' '
               || data[index] == '\0'
               || data[index] == '\n'
               || data[index] == '\r'); index++);
            if (index == data.Length)
                return "\0";

            for (int i = index; i < data.Length; i++)
            {
                if (TerminalExists(data[i]))
                {
                    if (index == i)
                    {
                        index = i + 1;
                        return data[i].ToString();
                    }
                    string temp = data.Substring(index, i - index);
                    index = i;
                    return temp;
                }
                if (i == data.Length - 1)
                {
                    string temp = data.Substring(index, i - index + 1);
                    index = i + 1;
                    return temp;
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
                default: break;
            }

            int num = 0;
            if (int.TryParse(lex, out num))
                return LexType.INT;

            if (isLetter(lex[0]))
                foreach (char l in lex)
                {
                    if (isLetter(l) || int.TryParse(l.ToString(), out num))
                        continue;
                    return LexType.INVALID;
                }
            else return LexType.INVALID;

            return LexType.ID;
        }

         
    }
}
