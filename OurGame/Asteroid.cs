using System;
using System.Drawing;

namespace OurGame
{
    class Asteroid : BaseObject
    {
        private Image _image;

        private static Image[] _images = null;
        private static int _nextImageIndex;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _image = GetImage();
        }

        public Asteroid(Point pos, Point dir, Size size, Image image) : base(pos, dir, size)
        {
            _image = image;
        }

        public override void Draw()
        {
            if (_image == null) return;
            Game._buffer.Graphics.DrawImage(_image, new Rectangle(_pos, _size));
        }
        
        /*       
        public override void Update()
        {
            _pos.X = _pos.X + _dir.X;
            if (_pos.X < 0) _pos.X = Game.Width;
        }
        */

            // задумался, а не создать ли класс - менеджер ресурсов, чтобы 
            // все классы, кому нужны картинки, обращались за ними к менеджеру?
            

        private static Image GetImage()
        {
            Image image = null;
            if (_images == null)
            {
                LoadImages();
                _nextImageIndex = 0;
            }

            if (_images != null)
            {
                int len = _images.Length;
                if (len > 0)
                {
                    image = _images[_nextImageIndex++];
                    if (_nextImageIndex == len)
                    {
                        _nextImageIndex = 0;
                    }
                }                
            }
            return image;
        }

        private static void LoadImages()
        {
            _images = new Image[5];
            _images[0] = OurGame.Properties.Resources.a1;
            _images[1] = OurGame.Properties.Resources.a2;
            _images[2] = OurGame.Properties.Resources.a3;
            _images[3] = OurGame.Properties.Resources.a4;
            _images[4] = OurGame.Properties.Resources.a5;
        }

    }
}
