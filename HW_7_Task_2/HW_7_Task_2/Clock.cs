using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HW_7_Task_2
{
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        private int centerX;
        private int centerY;
        private int currentHeight;
        private int currentWidth;

        private void Invalidate(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private Matrix RotateAroundCenter(float angle, Point center)
        {
            var result = new Matrix();
            result.RotateAt(angle, center);
            return result;
        }

        private void Clock_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            graphics.Clear(Color.White);

            var ss = DateTime.Now.Second;
            var mm = DateTime.Now.Minute;
            var hh = DateTime.Now.Hour;

            currentWidth = Width - 20 ;
            currentHeight = Height - 50;

            graphics.DrawEllipse(new Pen(Color.Black, 1f), 3, 3, Math.Min(currentWidth, currentHeight) - 3, Math.Min(currentWidth, currentHeight) - 3);
            graphics.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(Math.Min(currentWidth, currentHeight) / 2 - 12, 8));
            graphics.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(Math.Min(currentWidth, currentHeight) - 18, Math.Min(currentWidth, currentHeight) / 2 - 6));
            graphics.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(Math.Min(currentWidth, currentHeight) / 2 - 8, Math.Min(currentWidth, currentHeight) - 30));
            graphics.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(8, Math.Min(currentWidth, currentHeight)/2 - 8));

            centerX = Math.Min(currentWidth, currentHeight) / 2;
            centerY = Math.Min(currentWidth, currentHeight) / 2;

            graphics.Transform = RotateAroundCenter(6.0f * ss, new Point(centerX, centerY + 4));
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(centerX, centerY + 4), new Point(centerX, 15));

            graphics.Transform = RotateAroundCenter(6.0f * mm, new Point(centerX, centerY + 4));
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(centerX, centerY + 4), new Point(centerX, 30));

            graphics.Transform = RotateAroundCenter(30.0f * hh, new Point(centerX, centerY + 4));
            graphics.DrawLine(new Pen(Color.Gray, 3f), new Point(centerX, centerY + 4), new Point(centerX, 50));

            this.Text = $"Current time  {hh}:{mm}:{ss}";
            graphics.Dispose();
        }
    }
}
