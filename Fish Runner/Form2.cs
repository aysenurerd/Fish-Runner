using Fish_Runner;
using System;
using System.Windows.Forms;

namespace Fish_Runner
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "Shark Frenzy";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Oyuna başlama: Form1 açılır
            Form1 gameForm = new Form1();
            gameForm.Show();
            this.Hide(); // MenuForm'u gizle
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Yardım mesajı göster
            MessageBox.Show("Use the W, A, S, D buttons to play the game." +
                "Eat and Enjoy!",
                "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Uygulamayı kapat
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Watch out! After a while, mines and trash will appear. " +
                " Trash negatively affects your hunger." +
                " Don't hit the mines, little shark!" +
                " Don't stay hungry and eat the fish.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}


