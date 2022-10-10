using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private int _length;

        public MyLine(int x, int y)
        {
            X = x;
            Y = y;
            Color = Color.Black;
            _length = 100;
        }

        public MyLine() : this(0, 0)
        {
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutLine();
            }
            SplashKit.DrawLine(Color.Black, X, Y, X + _length, Y);
        }

        public override void DrawOutLine()
        {
            SplashKit.FillCircle(Color.Black, X, Y, 5);
            SplashKit.FillCircle(Color.Black, X + _length, Y, 5);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(X, Y, X + _length, Y));
        }
    }
}
