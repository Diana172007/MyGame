using System.Drawing;

namespace игра
{
    public interface IGameObject
    {
        Point Position { get; set; }
        Size Size { get; set; }
        Rectangle Bounds { get; }
        void Update();
        void Draw(Graphics g);
    }
}