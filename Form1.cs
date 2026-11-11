using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hlavni
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            Deska deska = new Deska(tableLayoutPanel1);
            deska.VytvorHraciDesku();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        

        

        
    }
}
