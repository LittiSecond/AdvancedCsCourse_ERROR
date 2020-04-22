using System;
using System.Drawing;

namespace OurGame
{
    class Star : BaseObject
    {

        public Star(Point pos, Point dir, Size size) 
            : base(pos,dir,size)
        {

        }

        public override void Draw()
        {
            Game._buffer.Graphics.DrawLine(Pens.White, _pos.X, _pos.Y,
                _pos.X + _size.Width, _pos.Y + _size.Height);
            Game._buffer.Graphics.DrawLine(Pens.White, _pos.X + _size.Width, _pos.Y,
                _pos.X , _pos.Y + _size.Height);
        }

        public override void Update()
        {
            _pos.X = _pos.X + _dir.X;
            if (_pos.X < 0) _pos.X = Game.Width; // + _size.Width;
        }
    }
}
