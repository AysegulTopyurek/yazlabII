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
    public partial class el_ile : Form
    {
        public el_ile()
        {
            InitializeComponent();
        }
        double[,] matris;
        int i, j;
       
           
           
        private void el_ile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int m = int.Parse(textBox1.Text);
            int n = int.Parse(textBox2.Text);


            matris = new double[m, n];
            if (m < 5 && n < 5 )
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {

                        matris[i, j] = int.Parse(Microsoft.VisualBasic.Interaction.InputBox((i + 1) + ",satir" + (j + 1) + ",sütuna sayi giriniz", "sayi giriniz", "", 40, 40));
                        textBox3.Text = textBox3.Text + matris[i, j];
                    }
                    textBox3.Text = textBox3.Text + "\r\n";

                }

            }
            else
                MessageBox.Show("Lütfen 0 ve 5 arasında bir değer giriniz");
        }

            private void button2_Click(object sender, EventArgs e)
            {
                el_ile el = new el_ile();
                el.Close();
                Form1 f1 = new Form1();
                f1.Show();

                this.Hide();
            }



            private void button3_Click(object sender, EventArgs e)
            {
                int m = int.Parse(textBox1.Text);
                int n = int.Parse(textBox2.Text);
                double[,] matrisT = new double[n, m];
                double[,] matrisTers = new double[m, n];
                double[,] matrisC = new double[m, m];
                double[,] matrisD = new double[m, m];
                for (i = 0; i < m; i++)
                {
                    for (j = 0; j < n; j++)
                    {

                        matrisT[j, i] = matris[i, j];


                    }

                }
                textBox4.Text += "Transpose işlemi alın >>>>>" +
                                Environment.NewLine;

                for (i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {

                        textBox4.Text += matrisT[i, j].ToString() + "";
                    }

                    textBox4.Text += Environment.NewLine;
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
                        textBox5.Text += matrisC[i, k].ToString() + "";

                    }

                    textBox5.Text += Environment.NewLine;
                    textBox5.Text = textBox5.Text + "\r \n";
                }



                DeterminantHesap(matrisC);
                MessageBox.Show("determinant sonucu " + DeterminantHesap(matrisC).ToString());
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

                            textBox6.Text += matrisTers[i, j].ToString() + "";
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
                            textBox7.Text += matrisD[i, k].ToString() + "";

                        }

                        textBox7.Text += Environment.NewLine;
                        textBox7.Text = textBox7.Text + "\r \n";
                    }



                }
                else
                    MessageBox.Show("determinant o dan kçük çıktı tekrar deneyin");

            }


        


    

    private void textBox6_TextChanged(object sender, EventArgs e)
        {
          
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

    }
} 


                
            
        
    

    
