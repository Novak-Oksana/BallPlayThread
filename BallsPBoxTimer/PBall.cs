using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace BallsPBoxTimer
{
    public partial class PBall : PictureBox
    {
        int dX;
        int dY;
      
        PictureBox box = new PictureBox();
     
        public PBall(int x, int y)
        {
            InitializeComponent();
            Bitmap b = new Bitmap(100, 100);
            Location = new Point(x, y);
            Size = new Size(40, 40);
            BackColor = Color.Transparent;
            using (Graphics g = Graphics.FromImage(b))
            {
                g.FillEllipse(PickBrush(), 0, 0, 40, 40);
            }
            Image = b;

           Random rnd = new Random();
           dX = rnd.Next(-10, 10);
            dY = rnd.Next(-10, 10);
                }

        private Brush PickBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }

        public void MoveBall()
        {
            int X = Location.X;
            int Y = Location.Y;
            Control parent = this.Parent;

            if (X <= (40 / 2) || (X >= parent.Width - (40 / 2)))
                dX = -dX;
            if (Y <= (40 / 2) || (Y >= parent.Height - (40 / 2)))
                dY = -dY;
            X += dX;
            Y += dY;

            Location = new Point(X, Y);
        }

        private void PBall_MouseClick(object sender, MouseEventArgs e)
        {
            Parent.Controls.Remove(this);
            Dispose();
        }
    }
}
