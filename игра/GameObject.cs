namespace игра
{
    public abstract class GameObject : IGameObject
    {
        public System.Drawing.Point Position { get; set; }
        public System.Drawing.Size Size { get; set; }
        public System.Drawing.Image Image { get; set; }
        public System.Drawing.Rectangle Bounds => new System.Drawing.Rectangle(Position, Size);
        protected GameObject(System.Drawing.Point position, System.Drawing.Size size)
        {
            Position = position;
            Size = size;
        }
        public abstract void Update();

        public virtual void Draw(System.Drawing.Graphics g)
        {
            if (Image != null)
                g.DrawImage(Image, Bounds);
        }
    }
}