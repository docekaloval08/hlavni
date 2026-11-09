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
        private int[,] hernipole = new int[10, 10];

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

        private void Lode()
        {

        }

        private void RozmisteniFlotily() //náhodně
        {
            Random rnd = new Random();
            int[] velikostlodi = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            foreach (int delka in velikostlodi)
            {
                bool umistena = false;
                while (!umistena)
                {
                    int radek;
                    int sloupec;
                    int smer = rnd.Next(2);
                    bool volno = true;

                    if (smer == 0) //horizontálně
                    {
                        radek = rnd.Next(10);
                        sloupec = rnd.Next(10 - delka + 1);

                        for (int i = 0; i < delka; i++)
                        {
                            int aktradek = radek;
                            int aktsloupec = sloupec + i;

                            for (int j = 0; j <= 2; j++)
                            {
                                for (int k = 0; k <= 2; k++)
                                {
                                    int kontradek = aktradek + j;
                                    int kontsloupec = sloupec + k;

                                    if (kontradek >= 0 && kontradek < 10 && kontsloupec >= 0 && kontsloupec < 10)
                                    {
                                        if (hernipole[kontradek, kontsloupec] != 0)
                                        {
                                            volno = false;
                                            break;
                                        }
                                    }
                                }
                                if (!volno) break;
                            }
                            if (!volno) break;

                        }

                        if (volno)
                        {
                            for (int i = 0; i < delka; i++)
                            {
                                hernipole[radek, sloupec + i] = delka;
                            }
                            umistena = true;
                        }
                    }
                    else //vertikálně
                    {
                        radek = rnd.Next(10 - delka + 1);
                        sloupec = rnd.Next(10);

                        for (int i = 0; i < delka; i++)
                        {
                            int aktradek = radek + i;
                            int aktsloupec = sloupec;

                            for (int j = 0; j <= 2; j++)
                            {
                                for (int k = 0; k <= 2; k++)
                                {
                                    int kontradek = aktradek + j;
                                    int kontsloupec = sloupec + k;

                                    if (kontradek >= 0 && kontradek < 10 && kontsloupec >= 0 && kontsloupec < 10)
                                    {
                                        if (hernipole[kontradek, kontsloupec] != 0)
                                        {
                                            volno = false;
                                            break;
                                        }
                                    }
                                }
                                if (!volno) break;
                            }
                            if (!volno) break;

                        }

                        if (volno)
                        {
                            for (int i = 0; i < delka; i++)
                            {
                                hernipole[radek + i, sloupec] = delka;
                            }
                            umistena = true;
                        }
                    }
                }
            }
        }
    }
}
