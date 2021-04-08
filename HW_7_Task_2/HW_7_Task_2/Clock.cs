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
        private int currentHeight;
        private int currentWidth;

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

            currentWidth = Width - 20;
            currentHeight = Height - 50;

            graphics.DrawEllipse(new Pen(Color.Black, 1f), 3, 3, Math.Min(currentWidth, currentHeight) - 3, Math.Min(currentWidth, currentHeight) - 3);
            graphics.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(Math.Min(currentWidth, currentHeight) / 2 - 12, 8));
            graphics.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(Math.Min(currentWidth, currentHeight) - 18, Math.Min(currentWidth, currentHeight) / 2 - 6));
            graphics.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(Math.Min(currentWidth, currentHeight) / 2 - 8, Math.Min(currentWidth, currentHeight) - 30));
            graphics.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(8, Math.Min(currentWidth, currentHeight)/2 - 8));

            centerX = Math.Min(currentWidth, currentHeight) / 2;
            centerY = Math.Min(currentWidth, currentHeight) / 2;

            secondsHand = Math.Min(currentWidth, currentHeight) / 2 - 30;
            minutessHand = Math.Min(currentWidth, currentHeight) / 2 - 50;
            hoursHand = Math.Min(currentWidth, currentHeight) / 2 - 70;

            handCoord = SecondsAndMinutesCoord(ss, secondsHand);
            graphics.DrawLine(new Pen(Color.Red, 1f), new Point(centerX, centerY + 4), new Point(handCoord[0], handCoord[1]));

            handCoord = SecondsAndMinutesCoord(mm, minutessHand);
            graphics.DrawLine(new Pen(Color.Black, 2f), new Point(centerX, centerY + 4), new Point(handCoord[0], handCoord[1]));

            handCoord = HoursCoord(hh % 12, mm, hoursHand);
            graphics.DrawLine(new Pen(Color.Gray, 3f), new Point(centerX, centerY + 4), new Point(handCoord[0], handCoord[1]));

            this.Text = $"Current time  {hh}:{mm}:{ss}";
            graphics.Dispose();
        }

        private int[] SecondsAndMinutesCoord(int value, int handLength)
        {
            int[] coordinates = new int[2];
            value *= 6;

            if (value >= 0 && value <= 180)
            {
                coordinates[0] = centerX + (int)(handLength * Math.Sin(Math.PI * value / 180));
                coordinates[1] = centerY - (int)(handLength * Math.Cos(Math.PI * value / 180));
            }
            else
            {
                coordinates[0] = centerX - (int)(handLength * -Math.Sin(Math.PI * value / 180));
                coordinates[1] = centerY - (int)(handLength * Math.Cos(Math.PI * value / 180));
            }
            return coordinates;
        }

        private int[] HoursCoord(int hoursValue, int minutes, int handLength)
        {
            int[] coordinates = new int[2];

            int val = (int)((hoursValue * 30) + (minutes * 0.5));

            if (val >= 0 && val <= 180)
            {
                coordinates[0] = centerX + (int)(handLength * Math.Sin(Math.PI * val / 180));
                coordinates[1] = centerY - (int)(handLength * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coordinates[0] = centerX - (int)(handLength * -Math.Sin(Math.PI * val / 180));
                coordinates[1] = centerY - (int)(handLength * Math.Cos(Math.PI * val / 180));
            }
            return coordinates;
        }
    }
}
