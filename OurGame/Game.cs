using System;
using System.Windows.Forms;
using System.Drawing;

namespace OurGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics _buffer;

        // размеры игрового поля
        public static int Width { get; set; }
        public static int Heigth { get; set; }

        private static BaseObject[] _objs;
        private static Timer _timer;
        

        static Game()
        {

        }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Heigth = form.ClientSize.Height;
            _buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Heigth));
            Load();


            //_timer = new Timer { Interval = 100 };

            _timer = new Timer();
            _timer.Interval = 100;

            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        public static void Draw()
        {
            _buffer.Graphics.Clear(Color.Black);
            //_buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //_buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 50, 200, 125));

            foreach (BaseObject obj in _objs)
            {
                obj?.Draw();
            }

            _buffer.Render();

        }

        private static void Updatu()
        {
            foreach (BaseObject obj in _objs)
            {
                obj?.Update();
            }
        }

        private static void Load()
        {
            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length / 2; i++)
            {
                _objs[i] = new Asteroid(new Point(600, i * 20), new Point(15 - i, 15 - i), 
                                            new Size(20, 20));
            }
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                _objs[i] = new Star(new Point(600, i * 20), new Point(-i, 0),
                                            new Size(5, 5));
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Updatu();
        }

    }
}
