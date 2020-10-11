using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Ollave_GameTheory
{
    public partial class Form1 : Form
    {
        string opponent = "";
        int yourscore = 0, opponentscore = 0;
        int round = 1;
        ArrayList cheater = new ArrayList() { "cheat", "cheat", "cheat", "cheat", "cheat" };
        ArrayList cooperator = new ArrayList() { "cooperate", "cooperate", "cooperate", "cooperate", "cooperate" };
        ArrayList copycat = new ArrayList() { "cooperate" };
        ArrayList grudger = new ArrayList() { "cooperate", "cooperate", "cooperate", "cooperate", "cooperate" };
        ArrayList detective = new ArrayList() { "cooperate", "cheat", "cooperate", "cooperate" };
        bool detectiveflag = false;
        string myfourth = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void chooseOpponentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opponent = "detective";
            label7.Text = opponent;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void copycatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opponent = "copycat";
            label7.Text = opponent;
        }

        private void cheaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opponent = "cheater";
            label7.Text = opponent;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (opponent == "detective" && round == 4)
                myfourth = "cooperate";

            if (opponent == "detective" && round == 5)
            {
                if (detectiveflag == false)
                    detective.Add("cheat");
                else
                    detective.Add(myfourth);


            }
            panel1.BackColor = System.Drawing.Color.White;
            panel2.BackColor = System.Drawing.Color.White;
            panel3.BackColor = System.Drawing.Color.White;
            panel4.BackColor = System.Drawing.Color.White;

            if (opponent == "")
            {
                MessageBox.Show("please choose opponent");
                opponent = "";
                yourscore = 0;
                opponentscore = 0;
                round = 1;
                copycat = new ArrayList() { "cooperate" };
                grudger = new ArrayList() { "cooperate", "cooperate", "cooperate", "cooperate", "cooperate" };
                return;
            }

            switch (opponent)
            {
                case "cheater":
                    {
                        label6.Text = "cheat";
                        yourscore -= 1;
                        opponentscore += 3;
                        panel2.BackColor = System.Drawing.Color.Yellow;
                    }
                    break;
                case "cooperator":
                    {
                        panel1.BackColor = System.Drawing.Color.Yellow;
                        yourscore += 2;
                        opponentscore += 2;
                    }
                    break;
                case "copycat":
                    if ((string)copycat[round-1] == "cooperate")
                    {
                        panel1.BackColor = System.Drawing.Color.Yellow;
                        yourscore += 2;
                        opponentscore += 2;
                    }
                    else
                    {
                        panel2.BackColor = System.Drawing.Color.Yellow;
                        yourscore -= 1;
                        opponentscore += 3;
                    }
                    copycat.Add("cooperate");
                    break;
                case "grudger":
                    if ((string)grudger[round - 1] == "cooperate")
                    {
                        label6.Text = "cooperate";
                        panel1.BackColor = System.Drawing.Color.Yellow;
                        yourscore += 2;
                        opponentscore += 2;
                    }
                    else
                    {
                        yourscore -= 1;
                        opponentscore += 3;
                        label6.Text = "cheat";
                        panel2.BackColor = System.Drawing.Color.Yellow;
                    }
                    break;
                case "detective":
                    if ((string)detective[round - 1] == "cooperate")
                    {
                        label6.Text = "cooperate";
                        panel1.BackColor = System.Drawing.Color.Yellow;
                        yourscore += 2;
                        opponentscore += 2;
                    }
                    else
                    {
                        yourscore -= 1;
                        opponentscore += 3;
                        label6.Text = "cheat";
                        panel2.BackColor = System.Drawing.Color.Yellow;
                    }
                    break;
                default:return;
            }

            round++;
            label8.Text = round.ToString();
            label3.Text = yourscore.ToString();
            label4.Text = opponentscore.ToString();
            if (round > 5)
            {
                if (yourscore == opponentscore)
                    MessageBox.Show("Draw");
                else if (yourscore > opponentscore)
                    MessageBox.Show("you win");
                else
                    MessageBox.Show("you lose");

                round = 1;
                label8.Text = round.ToString();
                ArrayList copycat = new ArrayList() { "cooperate" };

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cooperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opponent = "cooperator";
            label7.Text = opponent;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void reset()
        {
            panel1.BackColor = System.Drawing.Color.White;
            panel2.BackColor = System.Drawing.Color.White;
            panel3.BackColor = System.Drawing.Color.White;
            panel4.BackColor = System.Drawing.Color.White;
            opponent = "";
            yourscore = 0;
            opponentscore = 0;
            round = 1;
            ArrayList copycat = new ArrayList() { "cooperate" };
            ArrayList grudger = new ArrayList() { "cooperate", "cooperate", "cooperate", "cooperate", "cooperate" }; 
        }
        private void button3_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void grudgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            opponent = "grudger";
            label7.Text = opponent;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (opponent == "detective")
            {
                detectiveflag = true;
                if (round == 4)
                {
                    myfourth = "cheat";
                }
            }

            panel1.BackColor = System.Drawing.Color.White;
            panel2.BackColor = System.Drawing.Color.White;
            panel3.BackColor = System.Drawing.Color.White;
            panel4.BackColor = System.Drawing.Color.White;

            if(opponent == "")
            {
                MessageBox.Show("please choose opponent");
                reset();
                return;
            }

            switch (opponent)
            {
                case "cheater":
                    label6.Text = "cheat";
                    panel4.BackColor = System.Drawing.Color.Yellow;
                    break;
                case "cooperator":
                    {
                        label6.Text = "cooperate";
                        yourscore += 3;
                        opponentscore -= 1;
                        panel3.BackColor = System.Drawing.Color.Yellow;
                    }
                    break;
                case "copycat":
                    if ((string)copycat[round-1] == "cooperate")
                    {
                        label6.Text = "cooperate";
                        panel3.BackColor = System.Drawing.Color.Yellow;
                        yourscore += 3;
                        opponentscore -= 1;
                    }
                    else
                    {
                        label6.Text = "cheat";
                        panel4.BackColor = System.Drawing.Color.Yellow;
                    }
                    copycat.Add("cheat");
                    break;
                case "grudger":
                    if ((string)grudger[round - 1] == "cooperate")
                    {
                        label6.Text = "cooperate";
                        panel3.BackColor = System.Drawing.Color.Yellow;
                        yourscore += 3;
                        opponentscore -= 1;
                    }
                    else
                    {
                        label6.Text = "cheat";
                        panel4.BackColor = System.Drawing.Color.Yellow;
                    }
                    break;
                case "detective":
                    if ((string)detective[round - 1] == "cooperate")
                    {
                        label6.Text = "cooperate";
                        panel3.BackColor = System.Drawing.Color.Yellow;
                        yourscore += 3;
                        opponentscore -= 1;
                    }
                    else
                    {
                        label6.Text = "cheat";
                        panel4.BackColor = System.Drawing.Color.Yellow;
                    }
                    break;
                default:return;
            }

            round++;
            label8.Text = round.ToString();
            label3.Text = yourscore.ToString();
            label4.Text = opponentscore.ToString();
            if (round > 5)
            {
                if (yourscore == opponentscore)
                    MessageBox.Show("Draw");
                else if (yourscore > opponentscore)
                    MessageBox.Show("you win");
                else
                    MessageBox.Show("you lose");

                reset();
                label8.Text = round.ToString();
            }

            grudger = new ArrayList() { "cheat","cheat", "cheat", "cheat", "cheat" };
        }
    }
}
