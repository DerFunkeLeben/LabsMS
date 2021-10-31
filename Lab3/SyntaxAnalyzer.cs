using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class SyntaxAnalyzer
    {
        public static bool programIsValid(string data)
        {
            bool result = true;
            bool keep = false;
            bool bra_opened = false;
            bool inside_for = false;

            LexBlock.index = 0;
            string LexemType = "";
            Stack<string> PDA = new Stack<string>();

            PDA.Push("<.>");
            PDA.Push("<program>");
            
            while (result && !PDA.IsEmpty())
            {
                if (!keep)
                {
                    string Lexem = LexBlock.GetLexem(data);
                    LexemType = LexBlock.GetLexemType(Lexem).ToString();
                    if (LexemType == "INVALID")
                    {
                        result = false;
                        continue;
                    }
                }

                switch (PDA.Peek())
                {
                    case "<program>":
                        if ((LexemType == "ID") || (LexemType == "KW_IF") || (LexemType == "KW_FOR"))
                        {
                            PDA.Pop();
                            PDA.Push("<operators list>");
                            PDA.Push("<operator>");
                        }
                        else result = false;
                        keep = true;
                        break;

                    case ("<operators list>"):
                        if ((LexemType == "ID") || (LexemType == "KW_IF") || (LexemType == "KW_FOR"))
                        {
                            PDA.Pop();
                            PDA.Push("<operators list>");
                            PDA.Push("<operator>");
                        }
                        else if ((LexemType == "KW_ENDIF") ||
                                (LexemType == "END") ||
                                (LexemType == "KW_FOREND") ||
                                (LexemType == "KW_ELSE"))
                        {
                            PDA.Pop();
                        }
                        else result = false;
                        keep = true;
                        break;

                    case ("<operator>"):
                        if ((LexemType == "ID"))
                        {
                            PDA.Pop();
                            PDA.Push("<;>");
                            PDA.Push("<E>");
                            PDA.Push("<=>");
                        }
                        else if ((LexemType == "KW_FOR"))
                        {
                            PDA.Pop();
                            PDA.Push("<end>");
                            PDA.Push("<operators list>");
                            PDA.Push("<)>");
                            PDA.Push("<E>");
                            PDA.Push("<=>");
                            PDA.Push("<ID>");
                            PDA.Push("<;>");
                            PDA.Push("<logical expression>");
                            PDA.Push("<;>");
                            PDA.Push("<E>");
                            PDA.Push("<=>");
                            PDA.Push("<ID>");
                            PDA.Push("<(>");
                            inside_for = true;
                        }
                        else if ((LexemType == "KW_IF"))
                        {
                            PDA.Pop();
                            PDA.Push("<endif>");
                            PDA.Push("<else block>");
                            PDA.Push("<operators list>");
                            PDA.Push("<)>");
                            PDA.Push("<logical expression>");
                            PDA.Push("<(>");
                        }
                        else result = false;
                        keep = false;
                        break;

                    case ("<else block>"):
                        if (LexemType == "KW_ELSE")
                        {
                            PDA.Pop();
                            PDA.Push("<operators list>");
                            keep = false;
                        }
                        else if ((LexemType == "ID") ||
                                (LexemType == "KW_IF") ||
                                (LexemType == "KW_FOR") ||
                                (LexemType == "KW_ENDIF") ||
                                (LexemType == "END") ||
                                (LexemType == "KW_FOREND"))
                        {
                            PDA.Pop();
                            keep = true;
                        }
                        else result = false;
                        break;

                    case ("<logical expression>"):
                        if ((LexemType == "ID") || (LexemType == "INT"))
                        {
                            PDA.Pop();
                            PDA.Push("<F>");
                            PDA.Push("<logical operator>");
                            PDA.Push("<F>");
                            keep = true;
                        }
                        else result = false;
                        break;

                    case ("<logical operator>"):
                        if ((LexemType == "OP_LESS") || (LexemType == "OP_MORE"))
                            PDA.Pop();
                        else result = false;
                        keep = false;
                        break;

                    case ("<E>"):
                        if ((LexemType == "ID") || (LexemType == "INT"))
                        {
                            PDA.Pop();
                            PDA.Push("<E list>");
                            PDA.Push("<T>");
                        }
                        else result = false;
                        keep = true;
                        break;

                    case ("<E list>"):
                        if ((LexemType == "OP_PLS"))
                        {
                            PDA.Pop();
                            PDA.Push("<E list>");
                            PDA.Push("<T>");
                            keep = false;
                        }
                        else if((LexemType == "DELIM_SEMI") || (LexemType == "BRA_CLS" && bra_opened && inside_for))
                        {
                            PDA.Pop();
                            keep = true;
                        }
                        else result = false;
                        break;

                    case ("<T>"):
                        if ((LexemType == "ID") || (LexemType == "INT"))
                        {
                            PDA.Pop();
                            PDA.Push("<T list>");
                            PDA.Push("<F>");
                        }
                        else result = false;
                        keep = true;
                        break;

                    case ("<T list>"):
                        if ((LexemType == "OP_PLS") || (LexemType == "OP_MULT"))
                        {
                            PDA.Pop();
                            PDA.Push("<T list>");
                            PDA.Push("<F>");
                            keep = false;
                        }
                        else if ((LexemType == "DELIM_SEMI") || (LexemType == "BRA_CLS" && bra_opened && inside_for))
                        {
                            PDA.Pop();
                            keep = true;
                        }
                        else result = false;
                        break;

                    case ("<F>"):
                        if ((LexemType == "ID") || (LexemType == "INT"))
                            PDA.Pop();
                        else result = false;
                        keep = false;
                        break;

                    case ("<=>"):
                        Pop_Shift(ref LexemType, "OP_SET", ref PDA, ref result, ref keep);
                        break;

                    case ("<;>"):
                        Pop_Shift(ref LexemType, "DELIM_SEMI", ref PDA, ref result, ref keep);
                        break;

                    case ("<(>"):
                        bra_opened = true;
                        Pop_Shift(ref LexemType, "BRA_OPN", ref PDA, ref result, ref keep);
                        break;

                    case ("<)>"):
                        bra_opened = false;
                        Pop_Shift(ref LexemType, "BRA_CLS", ref PDA, ref result, ref keep);
                        break;

                    case ("<end>"):
                        inside_for = false;
                        Pop_Shift(ref LexemType, "KW_FOREND", ref PDA, ref result, ref keep);
                        break;

                    case ("<endif>"):
                        Pop_Shift(ref LexemType, "KW_ENDIF", ref PDA, ref result, ref keep);
                        break;

                    case ("<.>"):
                        Pop_Shift(ref LexemType, "END", ref PDA, ref result, ref keep);
                        break;

                    case ("<ID>"):
                        Pop_Shift(ref LexemType, "ID", ref PDA, ref result, ref keep);
                        break;

                    default:
                        result = false;
                        break;
                }
            }

            return result;
        }

        private static void Pop_Shift(ref string LexemType, string GotLexType, ref Stack<string> PDA, ref bool result, ref bool keep)
        {
            if ((LexemType == GotLexType))
                PDA.Pop();
            else result = false;
            keep = false;
        }
    }
}