using System.Windows.Forms;

namespace игра
{
    public class Player : MovingObject
    {
        public int MinX { get; set; }
        public int MaxX { get; set; }
        public int MoveSpeed { get; set; } = 10;

        public Player(System.Drawing.Point position, System.Drawing.Size size) : base(position, size, 0)
        {
            MinX = 250;
            MaxX = 600 - size.Width;
        }

        public void MoveLeft()
        {
            if (Position.X - MoveSpeed >= MinX)
                Position = new System.Drawing.Point(Position.X - MoveSpeed, Position.Y);
        }

        public void MoveRight()
        {
            if (Position.X + MoveSpeed + Size.Width <= MaxX + Size.Width)
                Position = new System.Drawing.Point(Position.X + MoveSpeed, Position.Y);
        }

        public override void Move() { }
        public override void Update() { }

        public void HandleKey(Keys key)
        {
            if (key == Keys.Left || key == Keys.A)
                MoveLeft();
            else if (key == Keys.Right || key == Keys.D)
                MoveRight();
        }
    }
}