using System;
using System.Drawing;
using System.Media;
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
        SoundPlayer explosionSound;

        public Form1()
        {
            InitializeComponent();
            ResetGame();

            // Oyuncu görüntüsünü kaydet
            playerImage = player.Image;

            // Sesleri yükle
            backgroundMusic = new SoundPlayer(Properties.Resources.backgraundSaound);
            explosionSound = new SoundPlayer(Properties.Resources.ExplosionSound);

            // Arka plan müziğini başlat
            backgroundMusic.PlayLooping();

            // Klavye olaylarını bağla
            this.KeyDown += new KeyEventHandler(keyisdown);
            this.KeyUp += new KeyEventHandler(keyisup);

            // Form klavye girişlerini algılamalı
            this.KeyPreview = true;
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

            // Sağ hareket
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
                if (facing % 2 != 0)
                {
                    FlipImageHorizontally(player);
                }

            }

            // Sol hareket
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

            // Sağ hareket
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = false;
            }

            // Sol hareket
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
            if (player.Bottom >= 330)
            {

            }

            // Yukarı hareket
            if (goup == true && player.Top > 0)
            {
                player.Top -= playerSpeed;
            }
            else if (player.Top <= 0)
            {
                player.Top = 0; // Üst sınırda dur
            }

            // Sağ hareket
            if (goRight == true && player.Right < this.ClientSize.Width)  // Sağ sınırda dur
            {
                player.Left += playerSpeed;
            }

            // Sol hareket
            if (goLeft == true && player.Left > 0)  // Sol sınırda dur
            {
                player.Left -= playerSpeed;

            }


            // Skor artırımı
            score++;
            q.Text = "Score: " + score;
           
            if (score % 170 == 0 && fishSpeed < 12) // Hız artışı, maksimum hız limiti 20
            {
                fishSpeed++;
            }

            // Balık ve engelleri hareket ettir
            AI1.Left -= fishSpeed;
            AI2.Left -= fishSpeed;
            AI3.Left -= fishSpeed;
            AI4.Left -= fishSpeed;
            AI5.Left -= fishSpeed;
          
            if (score >= 200)
            {
                Stone.Left -= fishSpeed;
            }
            if (score >= 300)
            {
                Bomb.Left -= fishSpeed;
            }

            // Alan dışı kontrolü
            alandisari(AI1);
            alandisari(AI2);
            alandisari(AI3);
            alandisari(AI4);
            alandisari(AI5);
            if (score >= 200) alandisari(Stone);
            if (score >= 300) alandisari(Bomb);

            // Çarpışma kontrolü
            EatFish(AI1);
            EatFish(AI2);
            EatFish(AI3);
            EatFish(AI4);
            EatFish(AI5);
            if (score >= 200) EatStone(Stone);
            if (score >= 300) HitBomb(Bomb);

            // Açlık çubuğu kontrolü
            if (hungerBar.Value > 0)
            {
                hungerBar.Value -= 1;
            }
            else
            {
                gameOver();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (gameTimer.Enabled)
            {
                gameTimer.Stop();
                backgroundMusic.Stop();
                btnStart.Text = "Start";
            }
            else
            {
                gameTimer.Start();
                backgroundMusic.PlayLooping();
                btnStart.Text = "Stop";
            }
        }

        private void ResetGame()
        {
            explosion.Visible = false;
            godown = false;
            goup = false;
            goLeft = false;
            goRight = false;
            score = 0;
            player.Top = this.ClientSize.Height / 2 - player.Height / 2;
            player.Left = 200;
            hungerBar.Value = hungerBar.Maximum;
            seaSpeed = 12;
            fishSpeed = 5;

            // Balık ve engelleri respawn yap
            Respawn(AI1);
            Respawn(AI2);
            Respawn(AI3);
            Respawn(AI4);
            Respawn(AI5);
            Respawn(Stone);
            Respawn(Bomb);

            gameTimer.Stop();
            btnStart.Text = "Başlat";
        }

        private async void EatFish(PictureBox fish)
        {




            if (player.Bounds.IntersectsWith(fish.Bounds))
            {
                fish.Visible = false; // Balığı gizle

                player.Image = Properties.Resources.Eatshark;

                if (facing % 2 != 0)
                {
                    FlipImageHorizontally(player);
                }

                // Açlık barını artır
                hungerBar.Value = Math.Min(hungerBar.Maximum, hungerBar.Value + 20);

                // Skoru artır
                score += 10;

                // Balığı yeniden doğur
                Respawn(fish as PictureBox);


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
                gameOver();
            }
        }

        private void gameOver()
        {
            gameTimer.Stop();
            backgroundMusic.Stop();
            MessageBox.Show("Game Over! Your Score: " + score);
            ResetGame();
        }

        private void alandisari(PictureBox fish)
        {
            if (fish.Left + fish.Width < 0)
            {
                Respawn(fish);
            }
        }

        private void Respawn(PictureBox fish)
        {
            if ((fish == Stone && score < 200) || (fish == Bomb && score < 300))
            {
                // Eğer skor eşiklerin altındaysa, bu nesneler görünmesin
                fish.Visible = false;
                return;
            }
            fish.Top = fishPosition.Next(50, this.ClientSize.Height - fish.Height);
            fish.Left = this.ClientSize.Width + rand.Next(75, 300); // Daha kısa aralıkta respawn
            fish.Visible = true;
        }
        private void FlipImageHorizontally(PictureBox pictureBox)
        {

            facing++;

            // PictureBox'ın mevcut resmini al
            Image originalImage = pictureBox.Image;

            // Yeni bir Bitmap oluştur (Resmin boyutlarıyla)
            Bitmap flippedImage = new Bitmap(originalImage);

            // Yatay flip işlemi yapmak için Graphics objesi kullanıyoruz
            using (Graphics g = Graphics.FromImage(flippedImage))
            {
                // Resmi yatayda ters çevir (X ekseninde)
                g.Clear(Color.Transparent); // Sayfanın temizlenmesi
                g.ScaleTransform(-1, 1);  // Yatayda ters çevirme
                g.DrawImage(originalImage, new Point(-originalImage.Width, 0)); // Resmi çiz
            }

            // PictureBox'ta resmi güncelle
            pictureBox.Image = flippedImage;


        }



    }
}
