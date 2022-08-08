using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFinder
{
    public partial class Form1 : Form
    {
        string path = "RUS.txt";

        public Form1()
        {
            InitializeComponent();
        }

        bool CheckWordSymbolsCount(int rule, int value)
        {
            if (rule == 0)
            {
                return true;
            }
            else
            {
                if (rule == value)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        bool CheckWordDefiniteSymbol(DefiniteSymbol[] rules, char[] word)
        {
            if (rules.Length > 0)
            {
                int counter = 0;
                for(int i = 0; i < rules.Length; i++)
                {
                    if (rules[i].index < word.Length)
                    {
                        if (rules[i].symbol.ToLower() == word[rules[i].index].ToString().ToLower())
                        {
                            counter++;
                        }
                    }
                }

                if (counter == rules.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        bool CheckWordFreeSymbol(string[] rules, char[] word)
        {
            if (rules.Length > 0)
            {
                int counter = 0;
                for (int i = 0; i < rules.Length; i++)
                {
                    for(int j = 0; j < word.Length; j++)
                    {
                        if (rules[i].ToLower() == word[j].ToString().ToLower())
                        {
                            counter++;
                            break;
                        }
                    }
                }

                if (counter == rules.Length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        struct DefiniteSymbol
        {
            public int index;
            public string symbol;

            public DefiniteSymbol(int index, string symbol)
            {
                this.index = index;
                this.symbol = symbol;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") || (textBox2.Text != ""))
            {
                int wordSymbolsCount = int.Parse(numericUpDown1.Value.ToString());

                string[] definiteSymbols1;
                DefiniteSymbol[] definiteSymbols = new DefiniteSymbol[0];
                if (textBox1.Text != "")
                {
                    definiteSymbols1 = textBox1.Text.Split('\n');
                    definiteSymbols = new DefiniteSymbol[definiteSymbols1.Length];

                    for (int i = 0; i < definiteSymbols1.Length; i++)
                    {
                        string[] definiteSymbols2 = definiteSymbols1[i].Split(':');

                        definiteSymbols[i] = new DefiniteSymbol(int.Parse(definiteSymbols2[0].Trim()), definiteSymbols2[1].ToString().Trim().ToLower());
                    }
                }


                string[] freeSymbols = new string[0];
                if (textBox2.Text != "")
                {
                    freeSymbols = textBox2.Text.Split(',');
                    for (int i = 0; i < freeSymbols.Length; i++)
                    {
                        freeSymbols[i] = freeSymbols[i].Trim().ToLower();
                    }
                }


                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        char[] letters = line.ToCharArray();
                        if (CheckWordSymbolsCount(wordSymbolsCount, letters.Length))
                        {
                            if (CheckWordDefiniteSymbol(definiteSymbols, letters))
                            {
                                if (CheckWordFreeSymbol(freeSymbols, letters))
                                {
                                    listBox1.Items.Add(line);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите условия поиска");
            }
        }
    }
}



/*
 static string path = "RUS.txt";
static void Main(string[] args)
{
    int count = 0;
    using (StreamReader reader = new StreamReader(path))
    {
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            char[] letters = line.ToCharArray();
            if (letters.Length == 9)
            {
                if (letters[1].ToString() == "а")
                {
                    for(int i = 0; i < letters.Length; i++) 
                    {
                        if (letters[i].ToString() == "щ")
                        {
                            for (int j = 0; j < letters.Length; j++)
                            {
                                if (letters[j].ToString() == "т")
                                {
                                    Console.WriteLine(line);
                                    count++;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
    Console.WriteLine(count);
 */
