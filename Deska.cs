using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hlavni
{
    internal class Deska
    {
        private Policka[,] Hernipole { get; set; } = new Policka[10, 10];
        private TableLayoutPanel tableLayoutPanel1;
        
        
        public Deska(TableLayoutPanel panel)
        {
            tableLayoutPanel1 = panel;
            for (int i = 0;i < 10; i++)
            {
                for (int j = 0;j < 10;j++) 
                {
                    Hernipole[i, j] = new Policka(i, j);
                }
            }
        }

        public void VytvorHraciDesku()
        {
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            for (int i = 0; i < 10; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Margin = new Padding(1);
                    btn.Tag = new Point(i, j);
                    btn.Click += TlacitkoPolicka_Click;
                    tableLayoutPanel1.Controls.Add(btn, j, i);
                }
            }

        }

        public void RozmisteniFlotily() //náhodně
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
                                        if (Hernipole[kontradek, kontsloupec].JeObsazena)
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
                                Hernipole[radek, sloupec + i].JeObsazena = true;
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
                                        if (Hernipole[kontradek, kontsloupec].JeObsazena)
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
                                Hernipole[radek + i, sloupec].JeObsazena = true;
                            }
                            umistena = true;
                        }
                    }
                }
            }
        }

        public void RozmisteniFlotilyManualne()
        {

        }

        public void TlacitkoPolicka_Click(object sender, EventArgs e)
        {
            Button tlacitko = (Button)sender;
            Point souradnice = (Point)tlacitko.Tag;
            int radek = souradnice.X;
            int sloupec = souradnice.Y;
            MessageBox.Show("souradnice: " + radek + " " + sloupec);


            tlacitko.Enabled = false;
        }
    }
}
