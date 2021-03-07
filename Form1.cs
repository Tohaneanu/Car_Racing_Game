using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Car_racing_game
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            over.Visible = false;
            ReadHighScore();
            
           
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gamespeed);
            enemy(gamespeed);
            gameover();
            coin(gamespeed);
            coinscollection();
        }
        Random r = new Random();
        int x;
        void enemy(int speed)
        {

            if (enemy1.Top > 500)
            {
                x = r.Next(0, 200);
     
                enemy1.Location = new Point(x, -10);
            }
            else
                enemy1.Top += speed;
            if (enemy2.Top > 500)
            {
                x = r.Next(200, 360);

                enemy2.Location = new Point(x, -10);
            }
            else
                enemy2.Top += speed;
            if (enemy3.Top > 500)
            {
                x = r.Next(120, 320);

                enemy3.Location = new Point(x, -10);
            }
            else
                enemy3.Top += speed;

        }
        void coin(int speed)
        {

            if (coin1.Top > 500)
            {
                x = r.Next(0, 180);

                coin1.Location = new Point(x, -10);
            }
            else
                coin1.Top += speed;
            if (coin2.Top > 500)
            {
                x = r.Next(180, 360);

                coin2.Location = new Point(x, -10);
            }
            else
                coin2.Top += speed;
            if (coin3.Top > 500)
            {
                x = r.Next(0, 360);

                coin3.Location = new Point(x, -10);
            }
            else
                coin3.Top += speed;
            if (coin4.Top > 500)
            {
                x = r.Next(0, 360);

                coin4.Location = new Point(x, -10);
            }
            else
                coin4.Top += speed;
        }
      
        void gameover()
        {
            if (my_car.Bounds.IntersectsWith(enemy1.Bounds))
            {
                timer1.Enabled = false;
                gamespeed = 0;
                over.Visible = true;
                over.Text = " Game Over!\nYour score is " + collectedcoin;
                
            }
            if (my_car.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                gamespeed = 0;
                over.Visible = true;
                over.Text = " Game Over!\nYour score is " + collectedcoin;
               

            }
            if (my_car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                gamespeed = 0;
                over.Visible = true;
                over.Text = " Game Over!\nYour score is " + collectedcoin;
               

            }
        } 
        void moveline(int speed)
        {
            if (pictureBox1.Top > 500)
                pictureBox1.Top = 0;
            else
            pictureBox1.Top += speed;
            if (pictureBox2.Top > 500)
                pictureBox2.Top = 0;
            else
                pictureBox2.Top += speed;
            if (pictureBox3.Top > 500)
                pictureBox3.Top = 0;
            else
                pictureBox3.Top += speed;
        }

        int gamespeed=0;
       
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            
                if (e.KeyCode == Keys.Left)
                {
                    if (my_car.Left > 0)
                        my_car.Left += -10;
                }
                if (e.KeyCode == Keys.Right)
                {
                    if (my_car.Right < 380)
                        my_car.Left += 10;
                }
                if (e.KeyCode == Keys.Up)
                    if (gamespeed < 21)
                        gamespeed += 2;
                if (e.KeyCode == Keys.Down)
                    if (gamespeed > 0)
                        gamespeed -= 2;
                if (gamespeed == 0)
                    difficulty.Visible = false;
                else if (gamespeed == 2)
                    difficulty.Text = "Difficulty:easy";
                else if (gamespeed == 4)
                    difficulty.Text = "Difficulty:middle";
                else if (gamespeed == 8)
                    difficulty.Text = "Difficulty:hard";
                else
                    difficulty.Text = "Difficulty:champion";
            
        }
        int collectedcoin = 0;
        void coinscollection()
        {
            if (my_car.Bounds.IntersectsWith(coin1.Bounds))
            {
                x = r.Next(0, 180);

                coin1.Location = new Point(x, -10);
                collectedcoin++;
                scor.Text = "Coins=" + collectedcoin.ToString();
               SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Iulia\Desktop\Car racing game\Super Mario Bros.-Coin Sound Effect.wav");
                player.Load();                                        
               player.Play();
            }
            if (my_car.Bounds.IntersectsWith(coin2.Bounds))
            {
                x = r.Next(0, 180);

                coin2.Location = new Point(x, -10);
                collectedcoin++;
                scor.Text = "Coins=" + collectedcoin.ToString();
               SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Iulia\Desktop\Car racing game\Super Mario Bros.-Coin Sound Effect.wav");
               player.Load();
              player.Play();
            }
            if (my_car.Bounds.IntersectsWith(coin3.Bounds))
            {
                x = r.Next(0, 180);

                coin3.Location = new Point(x, -10);
                collectedcoin++;
                scor.Text = "Coins=" + collectedcoin.ToString();
                SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Iulia\Desktop\Car racing game\Super Mario Bros.-Coin Sound Effect.wav");
               player.Load();
               player.Play();
            }
            if (my_car.Bounds.IntersectsWith(coin4.Bounds))
            {
                x = r.Next(0, 180);

                coin4.Location = new Point(x, -10);
                collectedcoin++;
                scor.Text = "Coins=" + collectedcoin.ToString();
                //SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\Iulia\source\repos\Car racing game\bin\Debug\sound.wav");
               // player.Load();
               // player.Play();
            }


        }
        void ReadHighScore()
        {
            if (!File.Exists("highscores.txt"))
            {
                TextWriter tw = new StreamWriter("highscores.txt");
                tw.Write("1");
                tw.Close();
            }
            TextReader tr = new StreamReader("highscores.txt");
            hscores.Text = tr.ReadLine();
            tr.Close();
        }
        void WriteHighScore()
        {
            if(collectedcoin>=Convert.ToInt32(hscores.Text))
            {
                TextWriter tw = new StreamWriter("highscores.txt");
                tw.WriteLine(collectedcoin);
                tw.Close();
             
              }
        }
     

     
        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            WriteHighScore();
        }
    }
}
