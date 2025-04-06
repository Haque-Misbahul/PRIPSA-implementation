using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer1
{
    public partial class Form1 : Form
    {
        int duration = 0;

        static double[] bt = new double[15];//burst time
        double[] dt = new double[10];//duration....clock
        double[] lt = new double[15];//lead time
        double[] pr = new double[15];
        double[,] block1 = new double[15,15];
        double[,] block2 = new double[15,15];
        double[,] block3 = new double[5,5];
        double[] pname = new double[15];
        int length = 0;
        string msg;
        int count;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            duration++;
            textBox1.Text = duration.ToString();

            count = 0;

            if (duration == 20)
            {
                
                Array.Sort(pr, pname);
                duration = 0;
                label2.Text = "  ";
                label6.Text = "  ";
                label10.Text = "  ";

                string st = "";

                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 1; j++)
                    {

                        // st = st + block1[i, j].ToString() + " " + block1[i, j + 1] + "\n";
                        
                        if (count <= 4)
                        {
                            block1[i, j] = pname[i];
                            block1[i, j + 1] = pr[i];

                            if ((pr[i] == 0) && (pname[i] == 0))
                            {


                            }
                            else
                            {

                            


                                msg = "p"+block1[i, j].ToString() + "                         " + block1[i, j + 1] + "\n";
                                label6.Text = label6.Text + msg;
                                count++;
                            }
                        }

                        else
                        {

                            block2[i, j] = pname[i];
                            block2[i, j + 1] = pr[i];

                            if ((pr[i] == 0) && (pname[i] == 0))
                            {


                            }
                            else
                            {


                                

                                msg = " "+ "p"+block2[i, j].ToString() + "                         " + block2[i, j + 1] + "\n";
                                label10.Text = label10.Text + msg;
                            }
                        }


                     

                    }

                }
              

                Array.Clear(dt, 0, dt.Length);
                Array.Clear(lt, 0, lt.Length);
                Array.Clear(pr, 0, pr.Length);
                Array.Clear(pname, 0, pname.Length);

                Array.Clear(block1, 0, block1.Length);
                Array.Clear(block2, 0, block2.Length);

                length = 0;

                //MessageBox.Show(st);

                //foreach (double key in pr)
                //{
                //    st = st + key +"\n";
                //}
                //MessageBox.Show(st);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            timer1.Stop();
            //for(int i=0; i <length; i++)
            //{
            //   msg =msg + bt[i].ToString() + " " + dt[i].ToString() + " " + pr[i].ToString() + "\n";
            //}
            //label2.Text = msg;



        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            //label2.Text = null;
            double x = Convert.ToDouble(textBox2.Text.ToString());

            double y = Convert.ToDouble(textBox3.Text.ToString());

            
            textBox2.Text = null;
            textBox3.Text = null;

            double alfpha = 0.6;
            bt[length] = x;
            lt[length] = y;
            dt[length] = duration;
            //pr[length] = x * duration;
            pr[length] = alfpha * bt[length] + (1 - alfpha) * lt[length];
            pname[length] = length;



            
           msg =pname[length].ToString() +"   "+ bt[length].ToString() + "     " + lt[length].ToString() + "    " + pr[length].ToString() + "\n";
            
            label2.Text =label2.Text+ msg;
            length++;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
