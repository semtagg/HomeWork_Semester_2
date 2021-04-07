using System;
using System.Drawing;
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
        private Timer timer = new Timer();
        private int centerX;
        private int centerY;
        private int secondsHand;
        private int minutessHand;
        private int hoursHand;

        private void Invalidate(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Clock_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            graphics.Clear(Color.White);

            var ss = DateTime.Now.Second;
            var mm = DateTime.Now.Minute;
            var hh = DateTime.Now.Hour;

            var handCoord = new int[2];

            graphics.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, Height, Height);
            graphics.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(140, 2));
            graphics.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(286, 140));
            graphics.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(142, 282));
            graphics.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(0, 140));

            centerX = Height / 2;
            centerY = Width / 2;

            secondsHand = (Height / 2) - 10;
            minutessHand = (Height / 2) - 30;
            hoursHand = (Height / 2) - 50;

            handCoord = SecondsAndMinutesCoord(ss, secondsHand);
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(centerX, centerY), new Point(handCoord[0], handCoord[1]));

            handCoord = SecondsAndMinutesCoord(mm, minutessHand);
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(centerX, centerY), new Point(handCoord[0], handCoord[1]));

            handCoord = HoursCoord(hh % 12, mm, hoursHand);
            graphics.DrawLine(new Pen(Color.Gray, 3f), new Point(centerX, centerY), new Point(handCoord[0], handCoord[1]));

            this.Text = $"Current time  {hh}:{mm}:{ss}";
            graphics.Dispose();
        }

        private int[] SecondsAndMinutesCoord(int val, int hand)
        {
            int[] coordinates = new int[2];
            val *= 6;

            if (val >= 0 && val <= 180)
            {
                coordinates[0] = centerX + (int)(hand * Math.Sin(Math.PI * val / 180));
                coordinates[1] = centerY - (int)(hand * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coordinates[0] = centerX - (int)(hand * -Math.Sin(Math.PI * val / 180));
                coordinates[1] = centerY - (int)(hand * Math.Cos(Math.PI * val / 180));
            }
            return coordinates;
        }

        private int[] HoursCoord(int hval, int mval, int hlen)
        {
            int[] coordinates = new int[2];

            int val = (int)((hval * 30) + (mval * 0.5));

            if (val >= 0 && val <= 180)
            {
                coordinates[0] = centerX + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coordinates[1] = centerY - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coordinates[0] = centerX - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coordinates[1] = centerY - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coordinates;
        }
    }
}
