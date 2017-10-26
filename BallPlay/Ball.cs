using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallPlay
{
    public class Ball
    {
        private int R = 40;
        private int X, Y; // Координаты
        private int dX, dY; // Путь за 1 тик таймера
        private Color color;

        // Заполнение данных о шаре 
        public Ball(Random rand, int x, int y)
        {
            X = x; // Координаты центра
            Y = y;
            dX = rand.Next(1, 10); // Путь за один tick таймера (в пикселях)
            dY = rand.Next(1, 10);
            color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255), rand.Next(255));
        }


        public void Draw(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(color);
            Graphics rg = e.Graphics;
            rg.FillEllipse(brush, X - (R / 2), Y - (R / 2), R, R);

        }

        public void Path(int width, int height)
        {
            if (X <= (R / 2))
                dX = -dX;
            if (X >= width - (R / 2))
                dX = -dX;
            if (Y <= (R / 2))
                dY = -dY;
            if (Y >= height - (R / 2))
                dY = -dY;
            // прибавляем к текущей координате изменение пути
            X += dX;
            Y += dY;
        }

        public Point GetPosition()
        {
            return new Point(X, Y);
        }
    }
}
