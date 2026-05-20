using System.Drawing;

namespace игра
{
    public abstract class GameObject : IGameObject
    {
        public Point Position { get; set; }
        public Size Size { get; set; }
        public Image Image { get; set; }

        public Rectangle Bounds => new Rectangle(Position, Size);

        protected GameObject(Point position, Size size)
        {
            Position = position;
            Size = size;
        }

        public abstract void Update();

        public virtual void Draw(Graphics g)
        {
            if (Image != null)
                g.DrawImage(Image, Bounds);
        }
    }
}