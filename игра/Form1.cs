using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace игра
{
    public partial class Form1 : Form
    {
        private Point pos;
        private bool dragging, lose = false;
        private int count = 0;
        private Random rand = new Random();
        private int record = 0;
        private SoundPlayer backgroundMusic;
        private SoundPlayer dieSound;
        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            timer1.Start();

            var musicPath = @"C:\Users\Account\Downloads\musicFon.wav";
            if (System.IO.File.Exists(musicPath))
            {
                backgroundMusic = new SoundPlayer(musicPath);
                backgroundMusic.PlayLooping();
            }

            bg1.Top = 0;
            bg2.Top = -650;
            fish1.Top = -50;
            fish1.Left = rand.Next(250, 550);

            var diePath = @"C:\Users\Account\Downloads\die.wav";
            if (System.IO.File.Exists(diePath))
            {
                dieSound = new SoundPlayer(diePath);
            }

            this.DoubleBuffered = true;

            var bgPath = @"C:\Users\Account\Downloads\f.jpg";
            var playerPath = @"C:\Users\Account\Downloads\vecteezy_cute-cartoon-cat-halloween-character-pumpkin_9665797.png";
            var enemyPath = @"C:\Users\Account\Downloads\enemy.png";
            var fishPath = @"C:\Users\Account\Downloads\fish.png";

            if (System.IO.File.Exists(bgPath))
            {
                using (Image temp = Image.FromFile(bgPath))
                {
                    bg1.Image = new Bitmap(temp, 850, 650);
                    bg2.Image = new Bitmap(temp, 850, 650);
                }
            }
            var objectSize = 60;

   
            if (System.IO.File.Exists(playerPath))
            {
                using (Image temp = Image.FromFile(playerPath))
                {
                    Bitmap playerImg = new Bitmap(temp, objectSize, objectSize);
                    player.Image = MakeLightYellowBackground(playerImg);
                }
            }
            player.Size = new Size(objectSize, objectSize);
            player.BackColor = Color.LightGoldenrodYellow;
            player.Left = (this.ClientSize.Width - player.Width) / 2;

            if (System.IO.File.Exists(enemyPath))
            {
                using (Image temp = Image.FromFile(enemyPath))
                {
                    enemy1.Image = new Bitmap(temp, objectSize, objectSize);
                    enemy2.Image = new Bitmap(temp, objectSize, objectSize);
                    enemy1.SizeMode = PictureBoxSizeMode.StretchImage;
                    enemy2.SizeMode = PictureBoxSizeMode.StretchImage;
                    enemy1.Image = MakeLightYellowBackground((Bitmap)enemy1.Image);
                    enemy2.Image = MakeLightYellowBackground((Bitmap)enemy2.Image);
                }
            }
            enemy1.Size = new Size(objectSize, objectSize);
            enemy2.Size = new Size(objectSize, objectSize);
            enemy1.BackColor = Color.LightGoldenrodYellow;
            enemy2.BackColor = Color.LightGoldenrodYellow;

            if (System.IO.File.Exists(fishPath))
            {
                using (Image temp = Image.FromFile(fishPath))
                {
                    fish1.Image = new Bitmap(temp, objectSize, objectSize);
                    fish1.SizeMode = PictureBoxSizeMode.StretchImage;
                    fish1.Image = MakeLightYellowBackground((Bitmap)fish1.Image);
                }
            }
            fish1.Size = new Size(objectSize, objectSize);
            fish1.BackColor = Color.LightGoldenrodYellow;

            enemy1.BringToFront();
            enemy2.BringToFront();
            fish1.BringToFront();
            player.BringToFront();

            coins.BackColor = Color.LightSkyBlue;
            coins.ForeColor = Color.DarkBlue;
            coins.Font = new Font("Arial", 16, FontStyle.Bold);
            coins.Text = "Рыбки: 0";
            coins.Padding = new Padding(5);
            coins.AutoSize = false;
            coins.Size = new Size(150, 40);
            coins.TextAlign = ContentAlignment.MiddleCenter;

            labelRecord.BackColor = Color.LightSkyBlue;
            labelRecord.ForeColor = Color.DarkBlue;
            labelRecord.Font = new Font("Arial", 16, FontStyle.Bold);
            labelRecord.Text = "Рекорд: 0";
            labelRecord.Padding = new Padding(5);
            labelRecord.AutoSize = false;
            labelRecord.Size = new Size(180, 40);
            labelRecord.TextAlign = ContentAlignment.MiddleCenter;

            labalLose.BackColor = Color.LightSkyBlue;
            labalLose.ForeColor = Color.DarkBlue;
            labalLose.Font = new Font("Arial", 48, FontStyle.Bold);
            labalLose.Text = "GAME OVER";
            labalLose.AutoSize = false;
            labalLose.Size = new Size(500, 80);
            labalLose.TextAlign = ContentAlignment.MiddleCenter;
            labalLose.Location = new Point(175, 260);

            buttonRestart.BackColor = Color.LightSkyBlue;
            buttonRestart.ForeColor = Color.DarkBlue;
            buttonRestart.Font = new Font("Arial", 16, FontStyle.Bold);
            buttonRestart.Text = "RESTART";
            buttonRestart.FlatStyle = FlatStyle.Flat;
            buttonRestart.FlatAppearance.BorderColor = Color.DarkBlue;
            buttonRestart.Size = new Size(180, 50);
            buttonRestart.Location = new Point(335, 360);

            bg1.MouseDown += MouseClickDown;
            bg1.MouseUp += MouseClickUp;
            bg1.MouseMove += MouseClickMove;
            bg2.MouseDown += MouseClickDown;
            bg2.MouseUp += MouseClickUp;
            bg2.MouseMove += MouseClickMove;

            this.KeyPreview = true;
            labalLose.Visible = false;
            buttonRestart.Visible = false;
        }

        private Bitmap MakeLightYellowBackground(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);
            for (var x = 0; x < original.Width; x++)
            {
                for (var y = 0; y < original.Height; y++)
                {
                    var pixel = original.GetPixel(x, y);
                    if (pixel.A < 200 || (pixel.R > 200 && pixel.G > 200 && pixel.B > 200))
                        result.SetPixel(x, y, Color.LightGoldenrodYellow);
                    else
                        result.SetPixel(x, y, pixel);
                    
                }
            }
            return result;
        }

        private void MouseClickDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            pos.X = e.X;
            pos.Y = e.Y;
        }

        private void MouseClickUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void MouseClickMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                var currPoint = PointToScreen(new Point(e.X, e.Y));
                this.Location = new Point(currPoint.X - pos.X, currPoint.Y - pos.Y + bg1.Top);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lose) return;

            bg1.Top += 5;
            bg2.Top += 5;
            enemy1.Top += 5;
            enemy2.Top += 5;
            fish1.Top += 5;

            if (bg1.Top >= 650) { bg1.Top = 0; bg2.Top = -650; }
            else if (bg2.Top >= 650) { bg2.Top = 0; bg1.Top = -650; }

            if (fish1.Top > 650)
            {
                fish1.Top = -50;
                fish1.Left = GetRandomPositionNonColliding();
            }

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
                fish1.Left = GetRandomPositionNonColliding();
            }

            if (player.Bounds.IntersectsWith(enemy1.Bounds) || player.Bounds.IntersectsWith(enemy2.Bounds))
            {
                timer1.Enabled = false;
                labalLose.Visible = true;
                buttonRestart.Visible = true;
                lose = true;
                backgroundMusic?.Stop();
                dieSound?.Play();
            }
        }

        private int GetRandomPositionNonColliding()
        {
            var newLeft = rand.Next(250, 550);
            if (enemy1.Top > -100 && Math.Abs(enemy1.Left - newLeft) < 70)
                newLeft = Math.Max(250, Math.Min(549, enemy1.Left + 80));
            if (enemy2.Top > -100 && Math.Abs(enemy2.Left - newLeft) < 70)
                newLeft = Math.Max(250, Math.Min(549, enemy2.Left - 80));
            return newLeft;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (lose) return;
            var speed = 12;
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && player.Left > 200)
                player.Left -= speed;
            else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && player.Right < 650)
                player.Left += speed;
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            lose = false;
            count = 0;
            coins.Text = "Рыбки: 0";

            enemy1.Top = -550;
            enemy2.Top = -130;
            fish1.Top = -50;
            fish1.Left = GetRandomPositionNonColliding();
            player.Left = (this.ClientSize.Width - player.Width) / 2;

            labalLose.Visible = false;
            buttonRestart.Visible = false;
            timer1.Enabled = true;
            timer1.Start();

            backgroundMusic?.PlayLooping();
        }
    }
}