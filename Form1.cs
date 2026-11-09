using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            VytvorHraciDesku();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void VytvorHraciDesku()
        {
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i <10; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
            }

            for (int i = 0;i <10;i++)
            {
                for (int j = 0;j <10;j++)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Margin = new Padding(1);
                    btn.Tag = new Point(i,j);
                    btn.Click += TlacitkoPolicka_Click;
                    tableLayoutPanel1.Controls.Add(btn, j, i);
                }
            }

        }

        private void TlacitkoPolicka_Click(object sender, EventArgs e)
        {
            Button tlacitko = (Button)sender;
            Point souradnice = (Point)tlacitko.Tag;
            int radek = souradnice.X;
            int sloupec = souradnice.Y;



            tlacitko.Enabled = false;
        }

        private void Lode(object sender, EventArgs e)
        {

        }

    }
}
