using System;

namespace игра
{
    public class Enemy : MovingObject
    {
        private Random random;
        public int RespawnY { get; set; }
        public int MinX { get; set; }
        public int MaxX { get; set; }
        public Enemy(System.Drawing.Point position, System.Drawing.Size size, int speed, Random rand) : base(position, size, speed)
        {
            random = rand;
            MinX = 250;
            MaxX = 550;
            RespawnY = -400;
        }
        public override void Move()
        {
            if (!IsActive) return;
            Position = new System.Drawing.Point(Position.X, Position.Y + Speed);
        }
        public override void Update()
        {
            Move();
            CheckRespawn();
        }
        private void CheckRespawn()
        {
            if (Position.Y > 650)
            {
                Position = new System.Drawing.Point(random.Next(MinX, MaxX), RespawnY);
            }
        }
        public void SetCustomRespawn(int y, int minX, int maxX)
        {
            RespawnY = y;
            MinX = minX;
            MaxX = maxX;
        }
    }
}