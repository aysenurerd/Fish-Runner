namespace Fish_Runner
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Stone = new System.Windows.Forms.PictureBox();
            this.AI3 = new System.Windows.Forms.PictureBox();
            this.AI4 = new System.Windows.Forms.PictureBox();
            this.AI5 = new System.Windows.Forms.PictureBox();
            this.explosion = new System.Windows.Forms.PictureBox();
            this.AI2 = new System.Windows.Forms.PictureBox();
            this.AI1 = new System.Windows.Forms.PictureBox();
            this.loser = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.UnderSea2 = new System.Windows.Forms.PictureBox();
            this.UnderSea1 = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.hungerBar = new System.Windows.Forms.ProgressBar();
            this.q = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Stone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnderSea2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnderSea1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.Stone);
            this.panel1.Controls.Add(this.AI3);
            this.panel1.Controls.Add(this.AI4);
            this.panel1.Controls.Add(this.AI5);
            this.panel1.Controls.Add(this.explosion);
            this.panel1.Controls.Add(this.AI2);
            this.panel1.Controls.Add(this.AI1);
            this.panel1.Controls.Add(this.loser);
            this.panel1.Controls.Add(this.player);
            this.panel1.Controls.Add(this.UnderSea2);
            this.panel1.Controls.Add(this.UnderSea1);
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 412);
            this.panel1.TabIndex = 0;
            // 
            // Stone
            // 
            this.Stone.Image = global::Fish_Runner.Properties.Resources.Cutie_Sharks__1_;
            this.Stone.Location = new System.Drawing.Point(734, 169);
            this.Stone.Name = "Stone";
            this.Stone.Size = new System.Drawing.Size(48, 41);
            this.Stone.TabIndex = 10;
            this.Stone.TabStop = false;
            // 
            // AI3
            // 
            this.AI3.Image = global::Fish_Runner.Properties.Resources.tas6;
            this.AI3.Location = new System.Drawing.Point(423, 313);
            this.AI3.Name = "AI3";
            this.AI3.Size = new System.Drawing.Size(66, 33);
            this.AI3.TabIndex = 9;
            this.AI3.TabStop = false;
            // 
            // AI4
            // 
            this.AI4.Image = global::Fish_Runner.Properties.Resources.tas5;
            this.AI4.Location = new System.Drawing.Point(597, 193);
            this.AI4.Name = "AI4";
            this.AI4.Size = new System.Drawing.Size(65, 29);
            this.AI4.TabIndex = 8;
            this.AI4.TabStop = false;
            // 
            // AI5
            // 
            this.AI5.Image = global::Fish_Runner.Properties.Resources.tas3;
            this.AI5.Location = new System.Drawing.Point(390, 67);
            this.AI5.Name = "AI5";
            this.AI5.Size = new System.Drawing.Size(54, 34);
            this.AI5.TabIndex = 7;
            this.AI5.TabStop = false;
            // 
            // explosion
            // 
            this.explosion.BackColor = System.Drawing.Color.Transparent;
            this.explosion.Image = global::Fish_Runner.Properties.Resources.boom;
            this.explosion.Location = new System.Drawing.Point(253, 67);
            this.explosion.Name = "explosion";
            this.explosion.Size = new System.Drawing.Size(58, 50);
            this.explosion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.explosion.TabIndex = 6;
            this.explosion.TabStop = false;
            this.explosion.Visible = false;
            this.explosion.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // AI2
            // 
            this.AI2.Image = global::Fish_Runner.Properties.Resources.balik;
            this.AI2.Location = new System.Drawing.Point(575, 323);
            this.AI2.Name = "AI2";
            this.AI2.Size = new System.Drawing.Size(78, 35);
            this.AI2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AI2.TabIndex = 5;
            this.AI2.TabStop = false;
            this.AI2.Tag = "fishUp";
            // 
            // AI1
            // 
            this.AI1.Image = global::Fish_Runner.Properties.Resources.japon;
            this.AI1.Location = new System.Drawing.Point(575, 67);
            this.AI1.Name = "AI1";
            this.AI1.Size = new System.Drawing.Size(57, 34);
            this.AI1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AI1.TabIndex = 4;
            this.AI1.TabStop = false;
            this.AI1.Tag = "fishDown";
            this.AI1.UseWaitCursor = true;
            this.AI1.Visible = false;
            // 
            // loser
            // 
            this.loser.Image = global::Fish_Runner.Properties.Resources.tas2;
            this.loser.Location = new System.Drawing.Point(213, 146);
            this.loser.Name = "loser";
            this.loser.Size = new System.Drawing.Size(318, 110);
            this.loser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loser.TabIndex = 3;
            this.loser.TabStop = false;
            this.loser.Visible = false;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.BackgroundImage = global::Fish_Runner.Properties.Resources.Ekran_görüntüsü_2024_12_19_192205;
            this.player.Image = global::Fish_Runner.Properties.Resources.MoveShark_01_01_2025_08_25_25;
            this.player.Location = new System.Drawing.Point(63, 178);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(43, 32);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.player.TabIndex = 2;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // UnderSea2
            // 
            this.UnderSea2.Image = global::Fish_Runner.Properties.Resources.Ekran_görüntüsü_2024_12_19_192205;
            this.UnderSea2.Location = new System.Drawing.Point(0, 0);
            this.UnderSea2.Name = "UnderSea2";
            this.UnderSea2.Size = new System.Drawing.Size(802, 412);
            this.UnderSea2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UnderSea2.TabIndex = 1;
            this.UnderSea2.TabStop = false;
            // 
            // UnderSea1
            // 
            this.UnderSea1.Image = global::Fish_Runner.Properties.Resources.Ekran_görüntüsü_2024_12_19_192205;
            this.UnderSea1.Location = new System.Drawing.Point(-902, 0);
            this.UnderSea1.Name = "UnderSea1";
            this.UnderSea1.Size = new System.Drawing.Size(802, 419);
            this.UnderSea1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UnderSea1.TabIndex = 0;
            this.UnderSea1.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStart.Location = new System.Drawing.Point(682, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(108, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimerEvent);
            // 
            // hungerBar
            // 
            this.hungerBar.BackColor = System.Drawing.Color.Red;
            this.hungerBar.Location = new System.Drawing.Point(53, 12);
            this.hungerBar.Name = "hungerBar";
            this.hungerBar.Size = new System.Drawing.Size(164, 23);
            this.hungerBar.TabIndex = 3;
            // 
            // q
            // 
            this.q.AutoSize = true;
            this.q.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.q.Location = new System.Drawing.Point(341, 9);
            this.q.Name = "q";
            this.q.Size = new System.Drawing.Size(127, 32);
            this.q.TabIndex = 4;
            this.q.Text = "Score: 0";
            this.q.Click += new System.EventHandler(this.q_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 495);
            this.Controls.Add(this.q);
            this.Controls.Add(this.hungerBar);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Fish Runner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Stone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.explosion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AI1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnderSea2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnderSea1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox UnderSea1;
        private System.Windows.Forms.PictureBox UnderSea2;
        private System.Windows.Forms.PictureBox explosion;
        private System.Windows.Forms.PictureBox AI2;
        private System.Windows.Forms.PictureBox AI1;
        private System.Windows.Forms.PictureBox loser;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ProgressBar hungerBar;
        private System.Windows.Forms.Label q;
        private System.Windows.Forms.PictureBox AI3;
        private System.Windows.Forms.PictureBox AI4;
        private System.Windows.Forms.PictureBox AI5;
        private System.Windows.Forms.PictureBox Stone;
    }
}

