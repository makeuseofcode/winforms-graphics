using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 1800;
            this.Height = 1200;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Render Image
            PictureBox picture = new PictureBox();
            picture.ImageLocation = "flagLarge.bmp";
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(picture);

            // Line
            Color black = Color.FromArgb(255, 0, 0, 0);
            Pen blackPen = new Pen(black);
            blackPen.Width = 20;
            blackPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            blackPen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            e.Graphics.DrawLine(blackPen, 900, 100, 1300, 100);

            // Rectangle
            Color red = Color.FromArgb(255, 255, 0, 0);
            Pen redPen = new Pen(red);
            redPen.Width = 5;
            e.Graphics.DrawRectangle(redPen, 900, 200, 200, 100);

            // Rectanlge using object
            Rectangle rectangle = new Rectangle(900, 350, 200, 100);
            e.Graphics.DrawRectangle(redPen, rectangle);

            // Circle
            Color green = Color.FromArgb(255, 0, 255, 0);
            Pen greenPen = new Pen(green);
            greenPen.Width = 5;
            e.Graphics.DrawEllipse(greenPen, 1200, 200, 200, 100);

            // Triangle
            Color blue = Color.FromArgb(255, 0, 0, 255);
            Pen bluePen = new Pen(blue);
            bluePen.Width = 5;
            
            PointF[] coordinatesForTriangle = new PointF[] {
                new PointF(1500, 200),
                new PointF(1400, 400),
                new PointF(1600, 400)
            };
            
            e.Graphics.DrawPolygon(bluePen, coordinatesForTriangle);

            // Creating multiple shapes with filled color
            Color purple = Color.FromArgb(255, 128, 0, 0);
            SolidBrush solidBrush = new SolidBrush(purple);

            e.Graphics.FillRectangle(solidBrush, 100, 500, 300, 200);
            e.Graphics.FillEllipse(solidBrush, 550, 500, 200, 200);
            e.Graphics.FillPolygon(solidBrush, new PointF[] { new PointF(1000, 500), new PointF(800, 700), new PointF(1200, 700) });

            // Creating shape with filled color (using an object)
            Rectangle rectangle2 = new Rectangle(1400, 500, 300, 200);
            e.Graphics.FillRectangle(solidBrush, rectangle2);

            // Create filled shape using Hatch Style Brush
            HatchBrush hatchBrush = new HatchBrush(HatchStyle.Horizontal, green, blue);
            e.Graphics.FillRectangle(hatchBrush, 100, 800, 250, 200);

            // Create filled shape using Texture Style Brush
            Bitmap image = (Bitmap)Image.FromFile("flag.bmp", true);
            TextureBrush textureBrush = new TextureBrush(image);
            e.Graphics.FillRectangle(textureBrush, 500, 800, 250, 200);
        }
    }
}
