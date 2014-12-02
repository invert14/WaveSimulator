using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WaveSimulator
{
    public partial class Form1 : Form
    {
        private Graphics g;
        private BackgroundWorker bw = new BackgroundWorker();

        const int s = 128;
        const int radius = s/16;
        const double ratio = 8;
        double[,] p = new double[s, s];
        double[,] c = new double[s, s];
        double[,] f = new double[s, s];
        int speed = 10;
        double dt = 0.00005;
        double dx = 0.01;
        double r;
        double stopTime = 0.1;
        int maxIter;
        int rememberStep;
//        int maxIter = 1;

        private Dictionary<int, double[,]> mem = new Dictionary<int, double[,]>();
        private bool simulationPaused = true;
        private bool simulationStarted = false;
        private ColorPalette colorPalette;
        private Bitmap bitmap;

        public Form1()
        {
            InitializeComponent();

            g = panel1.CreateGraphics();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
//            bw.RunWorkerAsync();
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            InitializeGrid();
            InitializeBitmap();
            UpdateSettings();
        }

        void UpdateSettings()
        {
            r = speed*dt/dx;
            maxIter = (int) (stopTime/dt);
            rememberStep = maxIter/100;
            UpdateSettingsControls();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            simulationPaused = true;
            SetSettingsControlsEnabled(true);
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            trackBar1.Value = e.ProgressPercentage;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool remember;
            int rememberIter = 0;

            for (int iter = 0; iter <= maxIter; iter++)
            {
                while (simulationPaused)
                {
                }

                if (iter%rememberStep == 0)
                    remember = true;
                else
                    remember = false;
                bw.ReportProgress(100*iter/maxIter);

                Random random = new Random();
                for (int x = 1; x < s - 1; x++)
                {
                    for (int y = 1; y < s - 1; y++)
                    {
                        double val = r*r*(c[x - 1, y] - c[x, y]) +
                                     r*r*(c[x + 1, y] - c[x, y]) +
                                     r*r*(c[x, y - 1] - c[x, y]) +
                                     r*r*(c[x, y + 1] - c[x, y]) +
                                     2*c[x, y] - p[x, y];

                        f[x, y] = val;

                        f[x, 0] = (2*c[x, 0] + (r - 1)*p[x, 0] +
                            2*r*r*(c[x, 1] + c[x + 1, 0] + c[x - 1, 0] - 3*c[x, 0]))/(1 + r);
                        f[x, s - 1] = (2*c[x, s - 1] + (r - 1)*p[x, s - 1] + 
                            2*r*r*(c[x, s - 2] + c[x + 1, s - 1] + c[x - 1, s - 1] - 3*c[x, s - 1]))/(1 + r);
                        f[0, y] = (2*c[0, y] + (r - 1)*p[0, y] +
                            2*r*r*(c[1, y] + c[0, y + 1] + c[0, y - 1] - 3*c[0, y]))/(1 + r);
                        f[s-1, y] = (2 * c[s-1, y] + (r - 1) * p[s-1, y] +
                            2 * r * r * (c[s-2, y] + c[s-1, y + 1] + c[s-1, y - 1] - 3 * c[s-1, y])) / (1 + r);

                        f[0, 0] = (2*c[0, 0] + (r - 1)*p[0, 0] + 
                            2*r*r*(c[1, 0] + c[0, 1] - 2*c[0, 0]))/(1 + r);
                        f[s - 1, s - 1] = (2*c[s - 1, s - 1] + (r - 1)*p[s - 1, s - 1] +
                            2*r*r*(c[s - 2, s - 1] + c[s - 1, s - 2] - 2*c[s - 1, s - 1]))/(1 + r);
                        f[0, s-1] = (2 * c[0, s-1] + (r - 1) * p[0, s-1] +
                            2 * r * r * (c[1, s-1] + c[0, s-2] - 2 * c[0, s-1])) / (1 + r);
                        f[s-1, 0] = (2 * c[s-1, 0] + (r - 1) * p[s-1, 0] +
                            2 * r * r * (c[s-2, 0] + c[s-1, 1] - 2 * c[s-1, 0])) / (1 + r);


                        if (remember)
                        {
                            if (!mem.ContainsKey(rememberIter))
                            {
                                mem[rememberIter] = new double[s, s];
                            }
                            mem[rememberIter][x, y] = c[x, y];
                        }
                        p[x, y] = c[x, y];
                        c[x, y] = f[x, y];
                    }
                }
                if (remember)
                    rememberIter++;
                
                UpdateBitmap(c);
                
                Console.Out.WriteLine(c[s/2,s/2]);
            }
        }

        private void InitializeGrid()
        {
            for (int i = 0; i != s; i++)
            {
                for (int j = 0; j != s; j++)
                {
                    c[i, j] = 0d;
                    p[i, j] = 0d;
                    f[i, j] = 0d;
                }
            }
        }

        private void UpdateBitmap(double[,] values)
        {
            var BoundsRect = new Rectangle(0, 0, s, s);
            BitmapData bmpData = bitmap.LockBits(BoundsRect,
                ImageLockMode.WriteOnly,
                bitmap.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            int length = bmpData.Stride * bitmap.Height;
            var rgbValues = new byte[length];
            for (int x = 0; x <= s - 1; x ++)
            {
                for (int y = 0; y <= s - 1; y ++)
                {
                    rgbValues[x * bmpData.Stride + y] = (byte)(values[x, y] / ratio * 256 + 127);
                }
            }
            Marshal.Copy(rgbValues, 0, ptr, length);
            bitmap.UnlockBits(bmpData);
            g.DrawImage(bitmap, 0, 0);
        }

        private void InitializeBitmap()
        {
            bitmap = new Bitmap(s, s, PixelFormat.Format8bppIndexed);
            colorPalette = bitmap.Palette;
            for (int i = 0; i < 256; i++)
                colorPalette.Entries[i] = Color.FromArgb(255, i, i, i);
            bitmap.Palette = colorPalette;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!bw.IsBusy)
            {
                UpdateSettings();
                bw.RunWorkerAsync();
                SetSettingsControlsEnabled(false);
            }

            if (!simulationPaused)
                simulationPaused = true;
            else
                simulationPaused = false;
        }

        private void SetSettingsControlsEnabled(bool state)
        {
            updateButton.Enabled = state;

            label1.Enabled = state;
            dtTextBox.Enabled = state;
            label2.Enabled = state;
            dxTextBox.Enabled = state;
            label3.Enabled = state;
            stopTimeTextBox.Enabled = state;
            label4.Enabled = state;
            speedTextBox.Enabled = state;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int val = trackBar1.Value;
            if (simulationPaused && mem.ContainsKey(val))
            {
                UpdateBitmap(mem[val]);
                Console.Out.WriteLine(trackBar1.Value);
            }
        }

        private void StartWave(int cx, int cy)
        {
            int radius = 1;
            for (int x = cx - radius; x <= cx + radius; x++)
            {
                for (int y = cy - radius; y <= cy + radius; y++)
                {
                    if (IsPointInBounds(x, y, s, s))
                    {
                        c[x, y] = -2.0;
                        p[x, y] = -2.0;
                    }
                }
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.Out.WriteLine(e.X + " " + e.Y);
            if (IsPointInBounds(e.X, e.Y, s, s))
            {
                StartWave(e.Y, e.X);
            }
        }

        private bool IsPointInBounds(int x, int y, int xBound, int yBound)
        {
            return (x > 0 && x < xBound - 1 && y > 0 && y < yBound - 1);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            UpdateBitmap(c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitializeGrid();
            mem.Clear();
            if (!bw.IsBusy)
            {
                UpdateBitmap(c);
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtTextBox.Text.Length > 0)
                {
                    dt = Convert.ToSingle(dtTextBox.Text, CultureInfo.InvariantCulture);
                }
                if (dxTextBox.Text.Length > 0)
                {
                    dx = Convert.ToSingle(dxTextBox.Text, CultureInfo.InvariantCulture);
                }
                if (stopTimeTextBox.Text.Length > 0)
                {
                    stopTime = Convert.ToSingle(stopTimeTextBox.Text, CultureInfo.InvariantCulture);
                }
                if (speedTextBox.Text.Length > 0)
                {
                    speed = Convert.ToInt32(speedTextBox.Text, CultureInfo.InvariantCulture);
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Unable to convert!");
            }
            UpdateSettingsControls();
        }

        private void UpdateSettingsControls()
        {
            dtTextBox.Clear();
            dxTextBox.Clear();
            stopTimeTextBox.Clear();
            speedTextBox.Clear();

            cdtTextBox.Text = dt.ToString("F6");
            cdxTextBox.Text = dx.ToString("F3");
            cStopTimeTextBox.Text = stopTime.ToString("F3");
            currentSpeedTextBox.Text = speed.ToString();
        }
    }
}