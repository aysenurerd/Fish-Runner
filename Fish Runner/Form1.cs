using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
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
        int facing = 0;

        Image playerImage;
        Random rand = new Random();
        Random fishPosition = new Random();

        bool godown, goup, goLeft, goRight;

        SoundPlayer backgroundMusic;
        SoundPlayer eatFishSound;
        SoundPlayer explosionSound;

        public Form1()
        {
            InitializeComponent();
            ResetGame();
            playerImage = player.Image;

            // Load sounds
            backgroundMusic = new SoundPlayer(Properties.Resources.backgraundSaound);
            //eatFishSound = new SoundPlayer(Properties.Resources.EatFishSound);
            explosionSound = new SoundPlayer(Properties.Resources.ExplosionSound);

            backgroundMusic.PlayLooping(); // Play background music in a loop
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S) godown = true;
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W) goup = true;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
                if (facing % 2 != 0) FlipImageHorizontally(player);
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = true;
                if (facing % 2 == 0) FlipImageHorizontally(player);
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S) godown = false;
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W) goup = false;
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D) goRight = false;
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A) goLeft = false;
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            if (godown && player.Bottom < 330) player.Top += playerSpeed;
            if (goup && player.Top > 0) player.Top -= playerSpeed;
            if (goRight && player.Right < this.ClientSize.Width) player.Left += playerSpeed;
            if (goLeft && player.Left > 0) player.Left -= playerSpeed;

            score++;
            q.Text = "Score: " + score;

            AI1.Left -= fishSpeed;
            AI2.Left -= fishSpeed;
            AI3.Left -= fishSpeed;
            AI4.Left -= fishSpeed;
            AI5.Left -= fishSpeed;
            Stone.Left -= fishSpeed;
            Bomb.Left -= fishSpeed;

            alandisari(AI1);
            alandisari(AI2);
            alandisari(AI3);
            alandisari(AI4);
            alandisari(AI5);
            alandisari(Stone);
            alandisari(Bomb);

            EatFish(AI1);
            EatFish(AI2);
            EatFish(AI3);
            EatFish(AI4);
            EatFish(AI5);
            EatStone(Stone);
            HitBomb(Bomb);

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

        private void gameOver()
        {
            gameTimer.Stop();
            backgroundMusic.Stop();
            MessageBox.Show("Game Over! Your Score: " + score);
            
        }

        private void ResetGame()
        {
            btnStart.Enabled = true;
            explosion.Visible = false;
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
            backgroundMusic.PlayLooping();
            gameTimer.Start();
            btnStart.Enabled = false;
        }

        private async void EatFish(PictureBox fish)
        {
            if (player.Bounds.IntersectsWith(fish.Bounds))
            {
                fish.Visible = false;
                player.Image = Properties.Resources.Eatshark;
                //eatFishSound.Play();

                if (facing % 2 != 0) FlipImageHorizontally(player);

                hungerBar.Value = Math.Min(hungerBar.Maximum, hungerBar.Value + 20);
                score += 10;
                Respawn(fish);

                await Task.Delay(1000);
                player.Image = playerImage;
                if (facing % 2 != 0) FlipImageHorizontally(player);
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
                explosionSound.Play();
                gameTimer.Stop();
                MessageBox.Show("Game Over! You hit a bomb!");
                
            }
        }
        private void alandisari(PictureBox fish)
        {
            if (fish.Left + fish.Width < 0)
            {
                Respawn(fish);
            }
        }

        private void UnderSea2_Click(object sender, EventArgs e)
        {

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

        private void Respawn(PictureBox fish)
        {
            fish.Top = fishPosition.Next(50, 330);
            fish.Left = fishPosition.Next(500, 800);
            fish.Visible = true;
        }
    }
}