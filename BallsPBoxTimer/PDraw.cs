using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BallsPBoxTimer
{
    public partial class PDraw : UserControl
    {
        public void threadFunc(object obj)
        {
            PictureBox pictureBox = (PictureBox)obj;
            while (true)
            {
                Thread.Sleep(50);
                try
                {
                    foreach (PBall ball in pictureBox.Controls)
                    {
                        ball.Invoke((MethodInvoker)delegate ()
                    {
                        ball.MoveBall();
                    });
                    }
                    pictureBox.Invalidate();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private Thread timerThread;

        public PDraw()
        {
            InitializeComponent();

            timerThread = new Thread(threadFunc);
            timerThread.Start(pictureBox1);
        }
        Random rand = new Random(DateTime.Now.Millisecond);

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.Controls.Add(new PBall(e.X, e.Y));
        }
    }
}
