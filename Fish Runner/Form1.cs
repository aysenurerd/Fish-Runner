using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            // Sağ hareket
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goRight = true;
                if(facing%2 != 0)
                {
                    FlipImageHorizontally(player);
                }

            }

            // Sol hareket
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goLeft = true;
                if(facing%2 == 0)
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

            // Aşağı hareket
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










            // Süreye göre skoru artır
            score++;
            q.Text = "Score: " + score;

            // Balıkların hareketi
            AI1.Left -= fishSpeed;
            AI2.Left -= fishSpeed;
            AI3.Left -= fishSpeed;
            AI4.Left -= fishSpeed;
            AI5.Left -= fishSpeed;
            Stone.Left -= fishSpeed;

            // Balıklar alan dışına çıkarsa yeniden doğur
            alandisari(AI1);
            alandisari(AI2);
            alandisari(AI3);
            alandisari(AI4); 
            alandisari(AI5);
            alandisari(Stone);

            
            EatFish(AI1);
            EatFish(AI2);
            EatFish(AI3);
            EatFish(AI4);
            EatFish(AI5);
            EatStone(Stone);
            

            // Açlık barını azalt
            if (hungerBar.Value > 0)
            {
                hungerBar.Value -= 1; // Her zaman diliminde açlık barı azalır
            }
            else
            {
                gameOver(); // Açlık barı biterse oyun biter
            }

            // Skor güncelleme
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

            btnStart.Enabled = true; // Oyuna başlama butonu aktif
            explosion.Visible = false; // Explosion başlangıçta gizli
            loser.Visible = false;     // Loser başlangıçta gizli
            godown = false;
            goup = false;

            score = 0;

            // Oyuncuyu başlangıç noktasına yerleştir
            player.Top = 412 / 2 - player.Height / 2; // Ortadan başlat
            player.Left = 200; // İsteğe bağlı yatay konum

            // Açlık barını sıfırla
            hungerBar.Value = hungerBar.Maximum;

            // Diğer ayarlar
            seaSpeed = 12;
            fishSpeed = 5;
            
            // Balıkların başlangıç konumlarını rastgele ayarla
            AI1.Top = fishPosition.Next(50, 362); // 50 ile 362 arasında bir konum
            AI1.Left = fishPosition.Next(500, 800); // Sağ tarafta başlasın
            AI1.Visible = true; // Görünür yap

            AI2.Top = fishPosition.Next(50, 362); // 50 ile 362 arasında bir konum
            AI2.Left = fishPosition.Next(500, 800); // Sağ tarafta başlasın
            AI2.Visible = true; // Görünür yap

            gameTimer.Stop(); // Oyun başlamadan zamanlayıcıyı durdur
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ResetGame(); // Oyunu sıfırla
            gameTimer.Start(); // Zamanlayıcıyı başlat
            SendKeys.SendWait("A");
            btnStart.Enabled = false; // Başlat butonunu pasifleştir
            
        }

        private void playSound()
        {


        }
        private void Respawn(PictureBox fish)
        {
            fish.Top = fishPosition.Next(50, 330); // 50 ile 362 arasında rastgele bir konum
            fish.Left = fishPosition.Next(500, 800); // Sağ tarafta başlasın
            fish.Visible = true; // Balığı görünür yap
        }

        private void q_Click(object sender, EventArgs e)
        {

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
            int localhealt = hungerBar.Value;
            if (player.Bounds.IntersectsWith(thing.Bounds))
            {
                thing.Visible = false; // Balığı gizle

                // Açlık barını azalt
                localhealt = Math.Min(hungerBar.Maximum, hungerBar.Value - 20);

                if(localhealt < 0)
                {
                    hungerBar.Value = 0;
                }
                    
                else
                {
                    hungerBar.Value = Math.Min(hungerBar.Maximum, hungerBar.Value - 20);
                }

                
                Respawn(thing as PictureBox);
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
