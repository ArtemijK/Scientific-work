using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Map_visual
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            string File1 = openFileDialog1.FileName;
            calculation(File1);
        }

        public void calculation(string File1)
        {
            if (File.Exists(File1) == true)
            {
                BinaryReader reader = new BinaryReader(File.Open(File1, FileMode.Open));
                char[] q = reader.ReadChars(4);
                short sNX = reader.ReadInt16();
                short sNY = reader.ReadInt16();
                int Nx = (int)sNX;
                int Ny = (int)sNX;
                int N = Nx * Ny;
                float[] Z = new float[N];
                double XMin = reader.ReadDouble();
                double XMax = reader.ReadDouble();
                double YMin = reader.ReadDouble();
                double YMax = reader.ReadDouble();
                double ZMin = reader.ReadDouble();
                double ZMax = reader.ReadDouble();
                string MESNx = Convert.ToString(Nx);
                string MESNy = Convert.ToString(Ny);
                MessageBox.Show("Точек по X - " + MESNx +"\n"+ "Точек по Y - " + MESNy);

                int k = (int)((XMax - XMin) / Nx) + 1;
                for (int i = 0; i < N; i++)
                {
                    Z[i] = reader.ReadSingle();
                }
            }

            
        }

        
    }
}
