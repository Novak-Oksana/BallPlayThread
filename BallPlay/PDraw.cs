using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallPlay
{
    public partial class PDraw : UserControl
    {
        public PDraw()
        {
            InitializeComponent();
        }

        List<Ball> ballList = new List<Ball>(); // список экземпляров (шаров)
        Random rand = new Random(DateTime.Now.Millisecond);

        private void Tick(object sender, EventArgs e)
        {
            // Метод проверки соударения со стенками
            foreach (Ball ball in ballList)
                ball.Path(pbox.Width, pbox.Height);
            pbox.Invalidate(); // Перерисовка
        }

        private void Speed(object sender, EventArgs e)
        {
            timer1.Interval = rand.Next(50, 300); ; // Скорость
        }

        private void BallPaint(object sender, PaintEventArgs e)
        {
            foreach (Ball ball in ballList)
                ball.Draw(e); // рисование
        }

        private void pbox_MouseClick(object sender, MouseEventArgs e)
        {
            int i = 0;
            bool found = false;
            timer1.Enabled = true;
            foreach (Ball ball in ballList)
            {
                if (e.X >= ball.GetPosition().X - 15 && e.X <= ball.GetPosition().X + 15 && e.Y >= ball.GetPosition().Y - 15 && e.Y <= ball.GetPosition().Y + 15)
                {
                    found = true;
                    break;
                }
                ++i;
            }
            if (found == true)
                ballList.RemoveAt(i);
            else
                ballList.Add(new Ball(rand, e.X, e.Y));

        }
    }
}
