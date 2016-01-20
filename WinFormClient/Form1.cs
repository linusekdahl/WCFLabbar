using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            StringClient host = new StringClient(); // proxy översätter 
            //så att jag tror att min klass TextFormatClient är i mitt projekt

            //Interfacet -> vårt projekt via proxy
            var input = textBox1.Text;
            label1.Text = input;


        }
    }
}
