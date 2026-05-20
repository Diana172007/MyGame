namespace игра
{
    public abstract class MovingObject : GameObject
    {
        public int Speed { get; set; }
        public bool IsActive { get; set; } = true;

        protected MovingObject(Point position, Size size, int speed) : base(position, size)
        {
            Speed = speed;
        }

        public abstract void Move();
    }
}