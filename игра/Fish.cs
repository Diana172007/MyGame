using System;

namespace игра
{
    public class Fish : MovingObject
    {
        private Random random;
        public Fish(System.Drawing.Point position, System.Drawing.Size size, int speed, Random rand) : base(position, size, speed)
        {
            random = rand;
        }
        public override void Move()
        {
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
                Respawn();
            }
        }
        public void Respawn()
        {
            Position = new System.Drawing.Point(random.Next(250, 550), -50);
        }
    }
}