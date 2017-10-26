using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsPBox
{
    public partial class PDraw : UserControl
    {
       
        public PDraw()
        {
            InitializeComponent();

        }
        Random rand = new Random(DateTime.Now.Millisecond);

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
            pictureBox1.Controls.Add(new PBall(e.X, e.Y));
                 }
             
    }
}
