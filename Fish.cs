using System;

namespace игра
{
    public class Fish : MovingObject
    {
        private Random random;

        public Fish(Point position, Size size, int speed, Random rand) : base(position, size, speed)
        {
            random = rand;
        }

        public override void Move()
        {
            Position = new Point(Position.X, Position.Y + Speed);
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
            Position = new Point(random.Next(250, 550), -50);
        }
    }
}