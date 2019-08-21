using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using CoreAPI;
using Entities_POJO;
using ZXing;
using CoreAPI;
using Exceptions;

namespace ScannerQR
{ 
    public partial class Form1 : Form
    {
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice FinalFrame;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                comboBox1.Items.Add(Device.Name);
            }
            comboBox1.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBox1.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
            FinalFrame.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckManagement check = new CheckManagement();

            BarcodeReader Reader = new BarcodeReader();
            try
            {
                Result result = Reader.Decode((Bitmap)pictureBox1.Image); 
                string decoded = result.ToString().Trim();
                if(decoded != ""){
                    Check mensaje = check.hacerCheck(decoded);
                    if (mensaje == null)
                    {
                        MessageBox.Show
                        ("¡LO SENTIMOS, HA OCURRIDO UN PROBLEMA, INTENTE MÁS TARDE O CONTACTE CON EL HOTEL!");
                        timer1.Stop();
                    }
                    else if (mensaje.FkSubReservacion.Equals(""))
                    {
                        mensaje.FkSubReservacion =
                        "¡LO SENTIMOS, HA OCURRIDO UN PROBLEMA, INTENTE MÁS TARDE O CONTACTE CON EL HOTEL!";
                        timer1.Stop();
                    }
                    else
                    {
                        MessageBox.Show(mensaje.FkSubReservacion);
                        timer1.Stop();
                    }
                    timer1.Enabled = false;
                    timer1.Start();
                }
            }
            catch (Exception excepcion)
            {
                Console.WriteLine(excepcion.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
        }
    }
}
