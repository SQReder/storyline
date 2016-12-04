using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Storyline.Story;

namespace Storyline
{
    public partial class Form1 : Form
    {
        private static readonly Random Random = new Random();
        private Storyline _storyline;
        private int _size = 1000;
        private Bitmap _storylineImage;

        public Form1()
        {
            InitializeComponent();

            textSize.Text = _size.ToString();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            NewStoryline();
        }

        private Row Generate()
        {
            var row0 = new Row();
            var col1 = new Column();
            var row1 = new Row();
            var col2 = new Column();
            var row2 = new Row();
            var col3 = new Column();
            var row3 = new Row();

            AddImages(row0, 1);
            AddImages(col1, 2);
            AddImages(row1, 1);
            AddImages(col2, 3);
            AddImages(row2, 2);
            AddImages(col3, 2);
            AddImages(row3, 2);

            row0.Add(col1);
            col1.Add(row1);
            row1.Add(col2);
            col2.Add(row2);

            AddImages(row0, 1);

            return row0;
        }

        private static void AddImages(IStoryContainer inner, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var idx = Random.Next(1, 10);
                var image = Image.FromFile($"./images/{idx}.jpg");
                var imageWrapper = new ImageWrapper(image, new Padding(25, 5, 10, 2));
                inner.Add(imageWrapper);
            }
        }

        private void NewStoryline()
        {
            var row = Generate();

            _storyline = new Storyline(row);

            msgPaddingReduced.Visible = false;

            RefreshImage();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (_storylineImage != null)
            {
                e.Graphics.DrawImage(_storylineImage, 0, 0);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = saveFileDialog.FileName;

                RefreshImage();
                _storylineImage.Save(fileName, ImageFormat.Jpeg);
            }
        }

        private void textSize_TextChanged(object sender, EventArgs e)
        {
            int size;
            if (int.TryParse(textSize.Text, out size))
            {
                _size = size;
                textSize.BackColor = Color.White;
            }
            else
            {
                textSize.BackColor = Color.SeaShell;
            }
        }

        private void btnRefit_Click(object sender, EventArgs e)
        {
            RefreshImage();
        }

        private void RefreshImage()
        {
            _storylineImage = _storyline.GetImage(_size, cbDebug.Checked);
            msgPaddingReduced.Visible = _storyline.IsPaddingReduced;
            Invalidate();
        }

        private void btnNewImageSet_Click(object sender, EventArgs e)
        {
            NewStoryline();
        }

        private void cbDebug_CheckedChanged(object sender, EventArgs e)
        {
            RefreshImage();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
