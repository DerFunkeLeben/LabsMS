using System;
using System.Threading;

namespace Labs {

    static class LexBlock
    {
        public enum LexType
        {
            INVALID,
            ID,
            INT,
            OP_SET,
            OP_DIV,
            OP_MIN,
            OP_LESS,
            OP_MORE,
            DELIM_COM,
            DELIM_SEMI,
            BRA_OPN,
            BRA_CLS,
            KW_IF,
            KW_ELSE,
            KW_DO,
            KW_UNTIL,
            END,
        }
        public static LexemeType GetLexemType(string input)
        {
            if (input == "if") return LexemeType.KW_IF;
            if (input == "else") return LexemeType.KW_ELSE;
            if (input == "until") return LexemeType.KW_UNTIL;
            if (input == "do") return LexemeType.KW_DO;
            if (input == "(") return LexemeType.BRA_OPN;
            if (input == ")") return LexemeType.BRA_CLS;
            if (input == "<") return LexemeType.OP_LESS;
            if (input == ">") return LexemeType.OP_MORE;
            if (input == ":=") return LexemeType.OP_SET;
            if (input == "-") return LexemeType.OP_MIN;
            if (input == ";") return LexemeType.DELIM_SEMI;
            if (input == ",") return LexemeType.DELIM_COM;
            if (input == "/") return LexemeType.OP_DIV;
            if (input == "\0") return LexemeType.END;
            int num = 0;
            if (int.TryParse(input, out num))
            {
                return LexemeType.INT;
            }
            for (int i = 0; i < input.Length; i++)
                if (input[i] < 'a' || input[i] > 'z')
                {
                    if (input[i] < 'A' || input[i] > 'Z')
                        return LexemeType.INVALID;
                }
            return LexemeType.ID;
        }

    }



    int option = int.Parse(Console.ReadLine());
                switch(option) {
                    case 1:
                        menu.Init(list);
                        break;
                    case 2:
                        menu.Print(list);
                        break;
                    case 3:
                        menu.Add(list);
                        break;
                    case 4:
                        menu.Find(list);
                        break;
                    case 5:
                        menu.Remove(list);
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("ERROR - INCORRECT OPTION");
                        break;
                
            
        
    
}
