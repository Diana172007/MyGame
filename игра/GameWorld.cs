using System;
using System.Drawing;
using System.Windows.Forms;

namespace игра
{
    public class GameWorld
    {
        public PictureBox bg1;
        public PictureBox bg2;
        public PictureBox player;
        public PictureBox enemy1;
        public PictureBox enemy2;
        public PictureBox fish1;
        public Label coins;
        public Label labelRecord;
        public Label labalLose;
        public Button buttonRestart;
        public Timer timer1;
        private Random rand = new Random();
        private int count = 0;
        private int record = 0;
        private bool lose = false;
        public bool IsGameOver => lose;

        public GameWorld(PictureBox bg1, PictureBox bg2, PictureBox player,
            PictureBox enemy1, PictureBox enemy2, PictureBox fish1,
            Label coins, Label labelRecord, Label labalLose, Button buttonRestart, Timer timer1)
        {
            this.bg1 = bg1;
            this.bg2 = bg2;
            this.player = player;
            this.enemy1 = enemy1;
            this.enemy2 = enemy2;
            this.fish1 = fish1;
            this.coins = coins;
            this.labelRecord = labelRecord;
            this.labalLose = labalLose;
            this.buttonRestart = buttonRestart;
            this.timer1 = timer1;
        }

        public void Initialize()
        {
            
            var bgPath = @"C:\Users\Account\Downloads\f.jpg";
            var playerPath = @"C:\Users\Account\Downloads\vecteezy_cute-cartoon-cat-halloween-character-pumpkin_9665797.png";

            if (System.IO.File.Exists(bgPath))
            {
                using (var temp = Image.FromFile(bgPath))
                {
                    bg1.Image = new Bitmap(temp, 850, 650);
                    bg2.Image = new Bitmap(temp, 850, 650);
                }
            }
            if (System.IO.File.Exists(playerPath))
            {
                using (var temp = Image.FromFile(playerPath))
                {
                    player.Image = new Bitmap(temp, 80, 60);
                }
            }
            enemy1.BackColor = Color.Red;
            enemy2.BackColor = Color.Red;
            fish1.BackColor = Color.Gold;
            bg1.Top = 0;
            bg2.Top = -650;
            fish1.Top = -50;
            fish1.Left = rand.Next(250, 550);
            player.Left = 385;
            player.Top = 550;

            player.Width = 80;
            player.Height = 60;
            enemy1.Width = 50;
            enemy1.Height = 50;
            enemy2.Width = 50;
            enemy2.Height = 50;
            fish1.Width = 40;
            fish1.Height = 40;

            coins.Text = "Рыбки: 0";
            labelRecord.Text = "Рекорд: 0";
            labalLose.Visible = false;
            buttonRestart.Visible = false;

            timer1.Enabled = true;
        }

        public void Update()
        {
            if (lose) return;

            bg1.Top += 5;
            bg2.Top += 5;

            if (bg1.Top >= 650)
            {
                bg1.Top = 0;
                bg2.Top = -650;
            }
            else if (bg2.Top >= 650)
            {
                bg2.Top = 0;
                bg1.Top = -650;
            }

            enemy1.Top += 5;
            enemy2.Top += 5;

            if (enemy1.Top > 650)
            {
                enemy1.Top = -400;
                enemy1.Left = rand.Next(250, 300);
            }
            if (enemy2.Top > 650)
            {
                enemy2.Top = -130;
                enemy2.Left = rand.Next(325, 550);
            }

            fish1.Top += 5;

            if (fish1.Top > 650)
            {
                fish1.Top = -50;
                fish1.Left = GetRandomPosition();
            }

            if (player.Bounds.IntersectsWith(fish1.Bounds))
            {
                count++;
                coins.Text = "Рыбки: " + count;

                if (count > record)
                {
                    record = count;
                    labelRecord.Text = "Рекорд: " + record;
                }

                fish1.Top = -50;
                fish1.Left = GetRandomPosition();
            }
            if (player.Bounds.IntersectsWith(enemy1.Bounds) ||
                player.Bounds.IntersectsWith(enemy2.Bounds))
            {
                GameOver();
            }
        }

        private int GetRandomPosition()
        {
            var newLeft = rand.Next(250, 550);
            if (enemy1.Top > -100 && Math.Abs(enemy1.Left - newLeft) < 50)
                newLeft = Math.Max(250, Math.Min(549, enemy1.Left + 60));

            if (enemy2.Top > -100 && Math.Abs(enemy2.Left - newLeft) < 50)
                newLeft = Math.Max(250, Math.Min(549, enemy2.Left - 60));

            return newLeft;
        }

        private void GameOver()
        {
            lose = true;
            timer1.Enabled = false;
            labalLose.Visible = true;
            buttonRestart.Visible = true;
        }

        public void HandleKey(Keys key)
        {
            if (lose) return;

            if ((key == Keys.Left || key == Keys.A) && player.Left > 250)
                player.Left -= 10;
            else if ((key == Keys.Right || key == Keys.D) && player.Right < 600)
                player.Left += 10;
        }

        public void Restart()
        {
            lose = false;
            count = 0;
            coins.Text = "Рыбки: 0";

            enemy1.Top = -550;
            enemy2.Top = -130;
            fish1.Top = -50;
            fish1.Left = GetRandomPosition();

            labalLose.Visible = false;
            buttonRestart.Visible = false;
            timer1.Enabled = true;
        }
    }
}