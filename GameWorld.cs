using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace игра
{
    public class GameWorld
    {
        private List<GameObject> gameObjects;
        private List<MovingObject> movingObjects;
        private Player player;
        private Fish fish;
        private List<Enemy> enemies;
        private List<Background> backgrounds;
        private GameScore gameScore;
        private SoundManager soundManager;
        private Random random;
        private bool isGameOver;

        public bool IsGameOver => isGameOver;

        public GameWorld(Label scoreLabel, Label recordLabel)
        {
            random = new Random();
            gameObjects = new List<GameObject>();
            movingObjects = new List<MovingObject>();
            enemies = new List<Enemy>();
            backgrounds = new List<Background>();

            gameScore = new GameScore(scoreLabel, recordLabel);
            soundManager = new SoundManager();

            InitializeObjects();
        }

        private void InitializeObjects()
        {
            player = new Player(new Point(385, 550), new Size(80, 60));
            fish = new Fish(new Point(random.Next(250, 550), -50), new Size(40, 40), 5, random);

            var enemy1 = new Enemy(new Point(random.Next(250, 300), -400), new Size(50, 50), 5, random);
            var enemy2 = new Enemy(new Point(random.Next(325, 550), -130), new Size(50, 50), 5, random);
            enemies.Add(enemy1);
            enemies.Add(enemy2);

            var bg1 = new Background(new Point(0, 0), new Size(850, 650));
            var bg2 = new Background(new Point(0, -650), new Size(850, 650));
            backgrounds.Add(bg1);
            backgrounds.Add(bg2);

            gameObjects.AddRange(backgrounds);
            gameObjects.Add(player);
            gameObjects.Add(fish);
            gameObjects.AddRange(enemies);
            movingObjects.AddRange(enemies);
            movingObjects.Add(fish);
        }

        public void LoadImages()
        {
            var bgPath = @"C:\Users\Account\Downloads\f.jpg";
            var playerPath = @"C:\Users\Account\Downloads\vecteezy_cute-cartoon-cat-halloween-character-pumpkin_9665797.png";

            if (System.IO.File.Exists(bgPath))
            {
                using (var temp = Image.FromFile(bgPath))
                {
                    foreach (var bg in backgrounds)
                        bg.Image = new Bitmap(temp, 850, 650);
                }
            }

            if (System.IO.File.Exists(playerPath))
            {
                using (var temp = Image.FromFile(playerPath))
                    player.Image = new Bitmap(temp, 100, 100);
            }
        }

        public void Update()
        {
            if (isGameOver) return;

            foreach (var obj in movingObjects)
                obj.Update();

            UpdateBackgrounds();
            CheckCollisions();
        }

        private void UpdateBackgrounds()
        {
            foreach (var bg in backgrounds)
            {
                bg.Update();
                if (bg.IsOutOfScreen())
                    bg.ResetPosition();
            }
        }

        private void CheckCollisions()
        {
            if (player.Bounds.IntersectsWith(fish.Bounds))
            {
                gameScore.AddScore(1);
                fish.Respawn();
            }

            if (enemies.Any(e => player.Bounds.IntersectsWith(e.Bounds)))
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            isGameOver = true;
            soundManager.StopBackground();
            soundManager.PlayDie();
        }

        public void HandleKey(Keys key)
        {
            if (!isGameOver)
                player.HandleKey(key);
        }

        public void Restart()
        {
            isGameOver = false;
            gameScore.Reset();
            fish.Respawn();

            foreach (var enemy in enemies)
                enemy.Position = new Point(random.Next(enemy.MinX, enemy.MaxX), enemy.RespawnY);

            soundManager.PlayBackground();
        }

        public void StartGame()
        {
            soundManager.PlayBackground();
        }

        public void Draw(Graphics g)
        {
            foreach (var obj in gameObjects.OrderBy(o => o is Background ? 0 : 1))
                obj.Draw(g);
        }
    }
}