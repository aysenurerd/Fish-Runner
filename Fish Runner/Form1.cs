using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fish_Runner
{
    public partial class Form1 : Form
    {
       
        int seaSpeed;
        int fishSpeed;
        int playerSpeed = 12;
        int score;
        int fishImage;
        int facing = 0;

        Image playerImage;

        Random rand = new Random();
        Random fishPosition = new Random();

        bool godown, goup, goLeft, goRight;

        public Form1()
        {
            InitializeComponent();
            ResetGame();
            playerImage = player.Image;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                godown = true;
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goup = true;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
                if (facing % 2 != 0)
                {
                    FlipImageHorizontally(player);
                }

            }

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = true;
                if (facing % 2 == 0)
                {
                    FlipImageHorizontally(player);
                }

            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                godown = false;
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goup = false;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (godown == true && player.Bottom < 330)
            {
                player.Top += playerSpeed;
            }
            if (goup == true && player.Top > 0)
            {
                player.Top -= playerSpeed;
            }

            if (goRight == true && player.Right < this.ClientSize.Width)
            {
                player.Left += playerSpeed;
            }

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }

           

            score++;
            q.Text = "Score: " + score;

            AI1.Left -= fishSpeed;
            AI2.Left -= fishSpeed;
            AI3.Left -= fishSpeed;
            AI4.Left -= fishSpeed;
            AI5.Left -= fishSpeed;
            Stone.Left -= fishSpeed;
            Bomb.Left -= fishSpeed; // Bomb hareketi

            alandisari(AI1);
            alandisari(AI2);
            alandisari(AI3);
            alandisari(AI4);
            alandisari(AI5);
            alandisari(Stone);
            alandisari(Bomb); // Bomb yeniden doğma kontrolü

            EatFish(AI1);
            EatFish(AI2);
            EatFish(AI3);
            EatFish(AI4);
            EatFish(AI5);
            EatStone(Stone);
            HitBomb(Bomb); // Bomb kontrolü

            if (hungerBar.Value > 0)
            {
                hungerBar.Value -= 1;
            }
            else
            {
                gameOver();
            }

            q.Text = "Score: " + score;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void changeAIfish(PictureBox tempFish)
        {

        }

        private void gameOver()
        {
            gameTimer.Stop();
            MessageBox.Show("Game Over! Your Score: " + score);
            ResetGame();
        }

        private void ResetGame()
        {
            btnStart.Enabled = true;
            explosion.Visible = false;
            loser.Visible = false;
            godown = false;
            goup = false;

            score = 0;

            player.Top = 412 / 2 - player.Height / 2;
            player.Left = 200;

            hungerBar.Value = hungerBar.Maximum;

            seaSpeed = 12;
            fishSpeed = 5;

            Respawn(AI1);
            Respawn(AI2);
            Respawn(AI3);
            Respawn(AI4);
            Respawn(AI5);
            Respawn(Stone);
            Respawn(Bomb);

            gameTimer.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ResetGame();
            gameTimer.Start();
            btnStart.Enabled = false;
        }

        private void playSound()
        {

        }

        private void Respawn(PictureBox fish)
        {
            fish.Top = fishPosition.Next(50, 330);
            fish.Left = fishPosition.Next(500, 800);
            fish.Visible = true;
        }

        private void q_Click(object sender, EventArgs e)
        {

        }
        
       





        private async void EatFish(PictureBox fish)
        {
            if (player.Bounds.IntersectsWith(fish.Bounds))
            {
                fish.Visible = false;

                player.Image = Properties.Resources.Eatshark;

                if (facing % 2 != 0)
                {
                    FlipImageHorizontally(player);
                }

                hungerBar.Value = Math.Min(hungerBar.Maximum, hungerBar.Value + 20);

                score += 10;

                Respawn(fish);

                await Task.Delay(1000);
                player.Image = playerImage;
                if (facing % 2 != 0)
                {
                    FlipImageHorizontally(player);
                }
            }
        }

        private void EatStone(PictureBox thing)
        {
            if (player.Bounds.IntersectsWith(thing.Bounds))
            {
                thing.Visible = false;

                hungerBar.Value = Math.Max(0, hungerBar.Value - 20);

                Respawn(thing);
            }
        }

        private void HitBomb(PictureBox bomb)
        {
            if (player.Bounds.IntersectsWith(bomb.Bounds))
            {
                bomb.Visible = false;

                explosion.Left = bomb.Left;
                explosion.Top = bomb.Top;
                explosion.Visible = true;

                gameTimer.Stop();

                MessageBox.Show("Game Over! You hit a bomb!");
                ResetGame();
            }
        }

        private void alandisari(PictureBox fish)
        {
            if (fish.Left + fish.Width < 0)
            {
                Respawn(fish);
            }
        }

        private void FlipImageHorizontally(PictureBox pictureBox)
        {
            facing++;

            Image originalImage = pictureBox.Image;

            Bitmap flippedImage = new Bitmap(originalImage);

            using (Graphics g = Graphics.FromImage(flippedImage))
            {
                g.Clear(Color.Transparent);
                g.ScaleTransform(-1, 1);
                g.DrawImage(originalImage, new Point(-originalImage.Width, 0));
            }

            pictureBox.Image = flippedImage;
        }
    }
}
