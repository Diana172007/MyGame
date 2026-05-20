using System;
using System.Drawing;
using System.Windows.Forms;

namespace игра
{
    public class Form1 : Form
    {
        private Timer timer;
        private PictureBox bg1, bg2, player, enemy1, enemy2, fish;
        private Label scoreLabel, recordLabel, gameOverLabel;
        private Button restartButton;

        private Random rand = new Random();
        private int score = 0;
        private int record = 0;
        private bool gameOver = false;
        private Point dragPos;
        private bool isDragging;

        public Form1()
        {
            this.ClientSize = new Size(850, 650);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.KeyPreview = true;
            this.DoubleBuffered = true;

            CreateBackgrounds();
            CreatePlayer();
            CreateEnemies();
            CreateFish();
            CreateUI();
            CreateTimer();

            this.KeyDown += OnKeyDown;
            this.KeyPress += OnKeyPress;
            this.MouseDown += OnMouseDown;
            this.MouseUp += OnMouseUp;
            this.MouseMove += OnMouseMove;
        }

        private void CreateBackgrounds()
        {
            string bgPath = @"C:\Users\Account\Downloads\f.jpg";

            bg1 = new PictureBox { Size = new Size(850, 650), Location = new Point(0, 0) };
            bg2 = new PictureBox { Size = new Size(850, 650), Location = new Point(0, -650) };

            if (System.IO.File.Exists(bgPath))
            {
                using (var img = Image.FromFile(bgPath))
                {
                    bg1.Image = new Bitmap(img, 850, 650);
                    bg2.Image = new Bitmap(img, 850, 650);
                }
            }

            this.Controls.Add(bg1);
            this.Controls.Add(bg2);
        }

        private void CreatePlayer()
        {
            string playerPath = @"C:\Users\Account\Downloads\vecteezy_cute-cartoon-cat-halloween-character-pumpkin_9665797.png";

            player = new PictureBox { Size = new Size(80, 60), Location = new Point(385, 550) };

            if (System.IO.File.Exists(playerPath))
            {
                using (var img = Image.FromFile(playerPath))
                    player.Image = new Bitmap(img, 80, 60);
            }

            this.Controls.Add(player);
        }

        private void CreateEnemies()
        {
            enemy1 = new PictureBox { Size = new Size(50, 50), Location = new Point(250, -400), BackColor = Color.Red };
            enemy2 = new PictureBox { Size = new Size(50, 50), Location = new Point(400, -130), BackColor = Color.Red };
            this.Controls.Add(enemy1);
            this.Controls.Add(enemy2);
        }

        private void CreateFish()
        {
            fish = new PictureBox { Size = new Size(40, 40), Location = new Point(rand.Next(250, 550), -50), BackColor = Color.Gold };
            this.Controls.Add(fish);
        }

        private void CreateUI()
        {
            scoreLabel = new Label { Text = "Рыбки: 0", Location = new Point(20, 20), ForeColor = Color.White, Font = new Font("Arial", 14), BackColor = Color.Transparent };
            recordLabel = new Label { Text = "Рекорд: 0", Location = new Point(150, 20), ForeColor = Color.White, Font = new Font("Arial", 14), BackColor = Color.Transparent };
            gameOverLabel = new Label { Text = "GAME OVER", Location = new Point(300, 280), ForeColor = Color.Red, Font = new Font("Arial", 36), Visible = false, BackColor = Color.Transparent };
            restartButton = new Button { Text = "Restart", Location = new Point(350, 350), Size = new Size(150, 50), Visible = false, Font = new Font("Arial", 14) };

            restartButton.Click += (s, e) => Restart();

            this.Controls.Add(scoreLabel);
            this.Controls.Add(recordLabel);
            this.Controls.Add(gameOverLabel);
            this.Controls.Add(restartButton);
        }

        private void CreateTimer()
        {
            timer = new Timer { Interval = 20 };
            timer.Tick += UpdateGame;
            timer.Start();
        }

        private void UpdateGame(object sender, EventArgs e)
        {
            if (gameOver) return;

            bg1.Top += 5;
            bg2.Top += 5;
            if (bg1.Top >= 650) { bg1.Top = 0; bg2.Top = -650; }
            if (bg2.Top >= 650) { bg2.Top = 0; bg1.Top = -650; }

            enemy1.Top += 5;
            enemy2.Top += 5;
            if (enemy1.Top > 650) { enemy1.Top = -400; enemy1.Left = rand.Next(250, 300); }
            if (enemy2.Top > 650) { enemy2.Top = -130; enemy2.Left = rand.Next(325, 550); }

            fish.Top += 5;
            if (fish.Top > 650)
            {
                fish.Top = -50;
                fish.Left = rand.Next(250, 550);
            }

            if (player.Bounds.IntersectsWith(fish.Bounds))
            {
                score++;
                scoreLabel.Text = "Рыбки: " + score;
                if (score > record)
                {
                    record = score;
                    recordLabel.Text = "Рекорд: " + record;
                }
                fish.Top = -50;
                fish.Left = rand.Next(250, 550);
            }

            if (player.Bounds.IntersectsWith(enemy1.Bounds) || player.Bounds.IntersectsWith(enemy2.Bounds))
            {
                gameOver = true;
                timer.Stop();
                gameOverLabel.Visible = true;
                restartButton.Visible = true;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver) return;
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && player.Left > 250)
                player.Left -= 10;
            if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && player.Right < 600)
                player.Left += 10;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) Close();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragPos = e.Location;
        }

        private void OnMouseUp(object sender, MouseEventArgs e) => isDragging = false;

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var p = PointToScreen(e.Location);
                Location = new Point(p.X - dragPos.X, p.Y - dragPos.Y);
            }
        }

        private void Restart()
        {
            gameOver = false;
            score = 0;
            scoreLabel.Text = "Рыбки: 0";
            gameOverLabel.Visible = false;
            restartButton.Visible = false;

            enemy1.Top = -400;
            enemy2.Top = -130;
            fish.Top = -50;
            fish.Left = rand.Next(250, 550);
            player.Left = 385;

            timer.Start();
        }
    }
}