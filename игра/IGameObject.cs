namespace игра
{
    public interface IGameObject
    {
        System.Drawing.Point Position { get; set; }
        System.Drawing.Size Size { get; set; }
        System.Drawing.Rectangle Bounds { get; }
        void Update();
        void Draw(System.Drawing.Graphics g);
    }
}