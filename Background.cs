using System.Drawing;

namespace игра
{
    public class Background : GameObject
    {
        public int Speed { get; set; } = 5;
        public int ScreenHeight { get; set; } = 650;

        public Background(Point position, Size size) : base(position, size)
        {
        }

        public override void Update()
        {
            Position = new Point(Position.X, Position.Y + Speed);
        }

        public override void Draw(Graphics g)
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
            Position = new Point(Position.X, -ScreenHeight);
        }
    }
}