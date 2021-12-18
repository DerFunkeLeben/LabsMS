using System;
using System.Windows.Forms;

namespace MS_CW
{
    public class Interpretator
    {
        public Command[] PDA;
        public Map<int, Var> variables;
        public Map<int, int> addresses;
        public Map<int, int> labels;
        public int size;
        public Interpretator()
        {
            variables = new Map<int, Var>();
            addresses = new Map<int, int>();
            labels = new Map<int, int>();
            PDA = new Command[100];
            size = 0;
        }
        public void AddCommand(Command a)
        {
            PDA[size] = a;
            size++;
        }
        public void FillGrid(DataGridView oper, DataGridView data)
        {
            oper.Rows.Clear();
            data.Rows.Clear();
            oper.ColumnCount = 1;
            data.ColumnCount = 3;
            oper.Columns[0].Name = "Command";
            oper.Columns[0].Width = 300;
            data.Columns[0].Name = "№";
            data.Columns[1].Name = "Name";
            data.Columns[2].Name = "Data";
            for (int i = 0; i < size; i++)
            {
                string attr = "(";
                for (int j = 0; j < PDA[i].attr.Length; j++)
                    if (j == PDA[i].attr.Length - 1)
                        attr += addresses[PDA[i].attr[j]];
                    else
                        attr += addresses[PDA[i].attr[j]].ToString() + ",";
                attr += ")";
                oper.Rows.Add(PDA[i].Name + attr);
            }
            for (int i = 1; i < variables.Size; i++)
            {
                data.Rows.Add(i, variables[i].Name, variables[i].Data);
            }
        }
        public void Execute()
        {
            int index = 0;
            while (index != size)
            {
                Command com = PDA[index];
                switch (com.Name)
                {
                    case "Assign":
                        if (!variables[addresses[com.attr[1]]].Set)
                            throw new Exception(String.Format("{0} is not set", variables[addresses[com.attr[1]]].Name));
                        variables[addresses[com.attr[0]]].Data = variables[addresses[com.attr[1]]].Data;
                        variables[addresses[com.attr[0]]].Set = true;
                        index++;
                        break;
                    case "Add":
                        if (!variables[addresses[com.attr[0]]].Set)
                            throw new Exception(String.Format("{0} is not set", variables[addresses[com.attr[0]]].Name));
                        if (!variables[addresses[com.attr[1]]].Set)
                            throw new Exception(String.Format("{0} is not set", variables[addresses[com.attr[1]]].Name));
                        variables[addresses[com.attr[2]]].Data = variables[addresses[com.attr[0]]].Data + variables[addresses[com.attr[1]]].Data;
                        variables[addresses[com.attr[2]]].Set = true;
                        index++;
                        break;
                    case "Multiply":
                        if (!variables[addresses[com.attr[0]]].Set)
                            throw new Exception(String.Format("{0} is not set", variables[addresses[com.attr[0]]].Name));
                        if (!variables[addresses[com.attr[1]]].Set)
                            throw new Exception(String.Format("{0} is not set", variables[addresses[com.attr[1]]].Name));
                        variables[addresses[com.attr[2]]].Data = variables[addresses[com.attr[0]]].Data * variables[addresses[com.attr[1]]].Data;
                        variables[addresses[com.attr[2]]].Set = true;
                        index++;
                        break;
                    case "Conditional_jump":
                        if (variables[addresses[com.attr[1]]].Data == 0)
                        {
                            for (int i = 0; i < size; i++)
                                if (PDA[i].Name == "Label" && com.attr[0] == PDA[i].attr[0])
                                    index = i;
                        }
                        else
                            index++;

                        break;
                    case "Unconditional_jump":
                        for (int i = 0; i < size; i++)
                            if (PDA[i].Name == "Label" && com.attr[0] == PDA[i].attr[0])
                                index = i;
                        break;
                    case "More":
                        if (!variables[addresses[com.attr[0]]].Set)
                            throw new Exception(String.Format("{0} is not set", variables[addresses[com.attr[0]]].Name));
                        if (!variables[addresses[com.attr[1]]].Set)
                            throw new Exception(String.Format("{0} is not set", variables[addresses[com.attr[1]]].Name));
                        if (variables[addresses[com.attr[0]]].Data > variables[addresses[com.attr[1]]].Data)
                            variables[addresses[com.attr[2]]].Data = 1;
                        else
                            variables[addresses[com.attr[2]]].Data = 0;
                        variables[addresses[com.attr[2]]].Set = true;
                        index++;
                        break;
                    case "Less":
                        if (!variables[addresses[com.attr[0]]].Set)
                            throw new Exception(String.Format("{0} is not set", variables[addresses[com.attr[0]]].Name));
                        if (!variables[addresses[com.attr[1]]].Set)
                            throw new Exception(String.Format("{0} is not set", variables[addresses[com.attr[1]]].Name));
                        if (variables[addresses[com.attr[0]]].Data < variables[addresses[com.attr[1]]].Data)
                            variables[addresses[com.attr[2]]].Data = 1;
                        else
                            variables[addresses[com.attr[2]]].Data = 0;
                        variables[addresses[com.attr[2]]].Set = true;
                        index++;
                        break;
                    case "Label":
                        index++;
                        break;
                }
            }
        }
    }
}
