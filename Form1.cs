using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Vision.Detection.Cascades;     //Arquivos de base, xml dos rostos
using Accord.Vision.Detection;              //
using Accord.Imaging.Filters;

namespace DetecçãoFacial
{
    public partial class Form1 : Form
    {

        private HaarObjectDetector detector;            //Declaração

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Arquivo xml facefrontal_default
            HaarCascade cascade = new FaceHaarCascade();
            detector = new HaarObjectDetector(cascade, 25, ObjectDetectorSearchMode.Average, 1.1f, ObjectDetectorScalingMode.GreaterToSmaller);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            Bitmap bmp = null;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                bmp = (Bitmap)Bitmap.FromFile(ofd.FileName);
            }

            Rectangle[] rects = detector.ProcessFrame(bmp);

            foreach(var rect in rects)
            {
                RectanglesMarker marker = new RectanglesMarker(rects, Color.DarkCyan);

                pictureBox1.Image = marker.Apply(bmp);
            }
        }
    }
}
