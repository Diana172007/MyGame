namespace игра
{
    public class Background : GameObject
    {
        public int Speed { get; set; } = 5;
        public int ScreenHeight { get; set; } = 650;
        public Background(System.Drawing.Point position, System.Drawing.Size size) : base(position, size)
        {
        }
        public override void Update()
        {
            Position = new System.Drawing.Point(Position.X, Position.Y + Speed);
        }
        public override void Draw(System.Drawing.Graphics g)
        {
            if (Image != null)
                g.DrawImage(Image, Bounds);
        }
        public bool IsOutOfScreen()
        {
            return Position.Y >= ScreenHeight;
        }
        public void ResetPosition()
        {
            Position = new System.Drawing.Point(Position.X, -ScreenHeight);
        }
    }
}