using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Storkle
{
    public partial class Form1 : Form
    {
        private Random generator = new Random();
        private string dataPath = "Database.csv";
        private DataSet storkleData;
        private int hero;

        private int smallImageSize = 64;
        private Color matchColor = Color.Green;
        private Color halfmatchColor = Color.Yellow;
        private Color mismatchColor = Color.Red;

        public void RestartStorkle()
        {
            hero = generator.Next(0, storkleData.GetHeroes().Length - 1);
            dataGridView1.Rows.Clear();
        }

        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void DataLoad(string path)
        {
            storkleData = new DataSet(path);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataLoad(dataPath);

            comboBox1.Items.AddRange(storkleData.GetHeroes());
            dataGridView1.Columns.Add(new DataGridViewImageColumn());
            dataGridView1.Columns[0].Width = smallImageSize;
            for (int i = 1; i < storkleData.GetHeaders().Length; i++)
            {
                dataGridView1.Columns.Add(storkleData.GetHeaders()[i], storkleData.GetHeaders()[i]);
            }
            for (int i = 1; i < storkleData.GetHeaders().Length; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
            RestartStorkle();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selection = comboBox1.SelectedIndex;

            if (selection >= 0 && selection < storkleData.GetHeroes().Length)
            {
                dataGridView1.Rows.Add(storkleData.GetData()[selection]);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Height = smallImageSize;
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = new Bitmap(storkleData.GetPictures()[selection], new Size(smallImageSize, smallImageSize));
                for (int i = 1; i < storkleData.GetHeaders().Length; i++)
                {
                    if (storkleData.GetData()[selection][i] == storkleData.GetData()[hero][i])
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.BackColor = matchColor;
                    }
                    else
                    {
                        string[] words1 = storkleData.GetData()[selection][i].Split(new char[] { ' ' });
                        string[] words2 = storkleData.GetData()[hero][i].Split(new char[] { ' ' });
                        for (int j = 0; j < words1.Length; j++)
                        {
                            words1[j] = words1[j].ToLower();
                        }
                        for (int j = 0; j < words2.Length; j++)
                        {
                            words2[j] = words2[j].ToLower();
                        }
                        bool halfmatch = false;
                        for (int j = 0; j < words1.Length; j++)
                        {
                            for (int k = 0; k < words2.Length; k++)
                            {
                                if (words1[j] == words2[k])
                                {
                                    halfmatch = true;
                                }
                            }
                        }
                        if (halfmatch)
                        {
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.BackColor = halfmatchColor;
                        }
                        else
                        {
                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[i].Style.BackColor = mismatchColor;
                        }
                    }
                }
                if (storkleData.GetData()[selection] == storkleData.GetData()[hero])
                {
                    Form2 victoryScreen = new Form2(this, storkleData.GetHeroes()[hero], storkleData.GetData()[hero][6], storkleData.GetPictures()[hero]);
                    victoryScreen.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestartStorkle();
        }
    }
}
