using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public MyCircle(Color clr, int radius): base(clr)
        {
            _radius = radius;
        }

        public MyCircle() : this(Color.Blue, 50)
        {
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutLine();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutLine()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius));
        }
    }
}
