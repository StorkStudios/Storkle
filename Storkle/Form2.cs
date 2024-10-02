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
    public partial class Form2 : Form
    {
        private Form1 mainWindow;

        public Form2(Form1 opener, string hero, string gender, Image picture)
        {
            InitializeComponent();
            this.CenterToScreen();
            mainWindow = opener;
            if(gender == "Mężczyzna")
            {
                label2.Text = label2.Text + " " + hero;
            }
            else
            {
                if(gender == "Kobieta")
                {
                    label2.Text = label2.Text + "a " + hero;
                }
                else
                {
                    label2.Text = label2.Text + "(a) " + hero;
                }
            }
            pictureBox1.Image = picture;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainWindow.RestartStorkle();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
