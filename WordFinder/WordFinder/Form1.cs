using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
