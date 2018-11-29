using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazlabII
{
    public partial class rastgele : Form
    {
        public rastgele()
        {
            InitializeComponent();
        }
        int i, j;
        double[,] matris;
        private void button1_Click(object sender, EventArgs e)
        {

            
            textBox1.ForeColor = Color.Red;
            MyClass rnd1 = new MyClass();

             matris = new double[rnd1.GetRandom(1, 5), rnd1.GetRandom(1, 5)];

            int m = matris.GetLength(0);
            int n = matris.GetLength(1);
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    matris[i, j] = (rnd1.GetRandom(1, 10));
                    textBox1.Text = textBox1.Text + matris[i, j];
                }
                textBox1.Text = textBox1.Text + "\r\n";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int m = matris.GetLength(0);
            int n = matris.GetLength(1);
            double[,] matrisT = new double[n, m];
            double[,] matrisC = new double[m, m];
            double[,] matrisTers = new double[m, n];
            double[,] matrisD = new double[m, m];
            for (i = 0; i < matris.GetLength(0); i++)
            {
                for (j = 0; j < matris.GetLength(1); j++)
                {

                    matrisT[j, i] = matris[i, j];


                }

            }


            textBox2.Text += "Transpose işlemi alın >>>>>" +
                                Environment.NewLine;

            for (i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                    textBox2.Text += matrisT[i, j].ToString() + "";
                }

                textBox2.Text += Environment.NewLine;
            }
            for (i = 0; i < m; i++)
            {
                for (int k = 0; k < m; k++)
                {
                    for (j = 0; j < n; j++)
                    {
                        matrisC[i, k] += matris[i, j] * matrisT[j, k];
                    }
                }
            }
            for (i = 0; i < m; i++)
            {
                for (int k = 0; k < m; k++)
                {
                    textBox3.Text += matrisC[i, k].ToString() + "";

                }

                textBox3.Text += Environment.NewLine;
                textBox3.Text = textBox3.Text + "\r\n";
            }

DeterminantHesap(matrisC);
        MessageBox.Show("determinant sonucu "+DeterminantHesap(matrisC).ToString());
            if (DeterminantHesap(matrisC) > 0)//tersini hesaplama bölümü
            {
                for (int k = 0; k < m; k++)
                {
                    for (i = 0; i < m; i++)
                    {
                        for (j = 0; j < m; j++)
                        {
                            if (!(i == k || j == k))
                            {
                                matrisC[i, j] = matrisC[i, j] + matrisC[i, k] * matrisC[k, j] / matrisC[k, k];

                            }
                        }
                    }
                    matrisC[k, k] = -1 / matrisC[k, k];
                    for (i = 0; i < m; i++)
                    {
                        if (!(i == k))
                        {
                            matrisC[i, k] = matrisC[i, k] * matrisC[k, k];
                        }
                    }
                    for (j = 0; j < m; j++)
                    {
                        if (!(j == k))
                        {
                            matrisC[k, j] = matrisC[k, j] * matrisC[k, k];
                        }


                    }
                }

                for (i = 0; i < m; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        matrisTers[i, j] = -matrisC[i, j];
                        Console.WriteLine(matrisT[i, j]);

                        textBox4.Text += matrisTers[i, j].ToString() + "";
                    }
                    Console.ReadLine();
                }
                //asıl formül olan tersini aldığım şeyi matrisin transpozu ile çarpıyoruz.
                for (i = 0; i < m; i++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        for (j = 0; j < n; j++)
                        {
                            matrisD[i, k] += matrisTers[i, j] * matrisT[j, k];
                        }
                    }
                }
                for (i = 0; i < m; i++)
                {
                    for (int k = 0; k < m; k++)
                    {
                        textBox5.Text += matrisD[i, k].ToString() + "";

                    }

                    textBox5.Text += Environment.NewLine;
                    textBox5.Text = textBox5.Text + "\r \n";
                }



            }
            else
                MessageBox.Show("determinant o dan kçük çıktı tekrar deneyin");

        }
    
        
        static double DeterminantHesap(double[,] matrisC)
        {
            int i;
            int boyut = Convert.ToInt32(Math.Sqrt(matrisC.Length));
            int isaret = 1;
            double toplam = 0;
            if (boyut == 1)
                return matrisC[0, 0];
            for (i = 0; i < boyut; i++)
            {
                double[,] altMatris = new double[boyut - 1, boyut - 1];
                for (int satir = 1; satir < boyut; satir++)
                {
                    for (int sutun = 0; sutun < boyut; sutun++)
                    {
                        if (sutun < i)
                            altMatris[satir - 1, sutun] = matrisC[satir, sutun];
                        else if (sutun > i)
                            altMatris[satir - 1, sutun - 1] = matrisC[satir, sutun];
                    }
                }
                if (i % 2 == 0)
                    isaret = 1;
                else
                    isaret = -1;

                toplam += isaret * matrisC[0, i] * (DeterminantHesap(altMatris));


            }

            return toplam;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            rastgele rs = new rastgele();
            rs.Close();
            Form1 f1 = new Form1();
            f1.Show();

            this.Hide();
        }

        
    }
    class MyClass
    {
        Random rnd = new Random();
        int _random;

        public int GetRandom(int min, int max)
        {
            return _random = rnd.Next(min, max);
        }
    }
}
