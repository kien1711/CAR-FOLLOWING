using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.IO.Ports;
using System.Collections;

namespace uart_can_ban
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //////////// khoi tao do thi /////////////
        ///
        private void Form1_Load(object sender, EventArgs e)
        {
            ZedGraph_Initialize();
            SerialPort_Initialize();

        }
        string[] baud = { "1200", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200" };
        string[] databit = { "5", "6", "7", "8" };
        private void SerialPort_Initialize()
        {
            string[] myport = SerialPort.GetPortNames();
            cBoxPortName.Items.AddRange(myport);
            cBoxBaudRate.Items.AddRange(baud);
            cBoxDataBit.Items.AddRange(databit);
            cBoxParityBit.Items.AddRange(Enum.GetNames(typeof(Parity)));

        }
        private void ZedGraph_Initialize()
        {
            GraphPane mypanne = zedGraphControl1.GraphPane;

            mypanne.Title.FontSpec.Size = 12;       //
            mypanne.XAxis.Title.FontSpec.Size = 11; //
            mypanne.YAxis.Title.FontSpec.Size = 11; //
            mypanne.Title.Text = "Velocity Graph";
            mypanne.YAxis.Title.Text = "Right Motor Speed (RPM)";
            mypanne.XAxis.Title.Text = "Time (s)";
            mypanne.XAxis.MajorGrid.IsVisible = true;   //
            mypanne.YAxis.MajorGrid.IsVisible = true;   //
            mypanne.Chart.Fill = new Fill(Color.White);    //
            mypanne.Fill = new Fill(Color.White, Color.White, 45.0f);   //
            RollingPointPairList list1 = new RollingPointPairList(60000);
            RollingPointPairList list2 = new RollingPointPairList(60000);


            LineItem duongline1 = mypanne.AddCurve("Real Velocity", list1, Color.Red, SymbolType.None);
            LineItem duongline2 = mypanne.AddCurve("Set Velocity", list2, Color.Blue, SymbolType.None);

            mypanne.XAxis.Scale.Min = 0;
            mypanne.XAxis.Scale.Max = 100;
            mypanne.XAxis.Scale.MinorStep = 0.001;
            mypanne.XAxis.Scale.MajorStep = 1;
            mypanne.YAxis.Scale.Min = 0;
            mypanne.YAxis.Scale.Max = 400;
            mypanne.YAxis.Scale.MinorStep = 1;
            mypanne.YAxis.Scale.MajorStep = 5;
            zedGraphControl1.AxisChange();


        }
            /*-------------------------------ve do thi---------------------------*/
            // int tong = 0;
            int tickStart = 0;
        public void draw(float realVel, float set_vel)
        {
            if (zedGraphControl1.GraphPane.CurveList.Count <= 0) return;

            LineItem duongline1 = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            LineItem duongline2 = zedGraphControl1.GraphPane.CurveList[1] as LineItem;
            
            if (duongline1 == null) return;
            if (duongline2 == null) return;

            IPointListEdit list1 = duongline1.Points as IPointListEdit;
            IPointListEdit list2 = duongline2.Points as IPointListEdit;
            if (list1 == null)  return;
            if (list2 == null)  return;

            double time = (Environment.TickCount - tickStart) / 1000.0;

           // list1.Add(tong, realVel);
            //list2.Add(tong, set_vel);
            list1.Add(time, realVel);
            list2.Add(time, set_vel);
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            time += 1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                /*serialPort1.PortName = cBoxPortName.Text;
                serialPort1.BaudRate = int.Parse(cBoxBaudRate.Text);
                serialPort1.DataBits = int.Parse(cBoxDataBit.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cBoxParityBit.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cBoxStopBit.Text);*/

                serialPort1.PortName = "COM4";
                serialPort1.BaudRate = 115200;
                serialPort1.DataBits = 8;
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");

                serialPort1.Open();

                progressBar1.Value = 100;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                progressBar1.Value = 0;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        string data = String.Empty;
        float setvel;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                data = serialPort1.ReadLine();
                if(data != String.Empty)
                {
                    Invoke(new MethodInvoker(() => listBox1.Items.Add(data)));
                    //Invoke(new MethodInvoker(() => draw(int.Parse(data), (setvel))));
                    //data = String.Empty;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //data = serialPort1.ReadExisting();

            /*Invoke(new MethodInvoker(() => listBox1.Items.Add(data)));
            Invoke(new MethodInvoker(() => draw(int.Parse(data))));
            data = "";*/


            }
        private Timer sendTimer;
        private string sendData;
        private int sendInterval = 1000; // Thời gian gửi (ms)
       /* private void btnSend_Click(object sender, EventArgs e)
        {
            sendData = tBoxDisplaySend.Text;

            // Khởi tạo và cấu hình Timer
            sendTimer = new Timer();
            sendTimer.Interval = sendInterval;
            sendTimer.Tick += SendTimer_Tick;
            sendTimer.Start();
        }

        private void SendTimer_Tick(object sender, EventArgs e)
        {
            // Gửi dữ liệu
            serialPort1.Write(sendData);
        }*/
        private void btnSend_Click(object sender, EventArgs e)
        {
            serialPort1.Write(tBoxDisplaySend.Text);
        }
       /* private void btn_stop_Click(object sender, EventArgs e)
        {
            StopSending();
        }

        private void StopSending()
        {
            if (sendTimer != null)
            {
                sendTimer.Stop();
                sendTimer.Dispose();
                sendTimer = null;
            }
        }*/

        private void btn_run_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                progressBar_run.Value = 100;
                btn_run.Enabled = false;
                btn_stop.Enabled = true;
                serialPort1.Write("r");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            try
            {
                timerGraph.Enabled = true;
                tickStart = Environment.TickCount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void btn_stop_Click(object sender, EventArgs e)
        {
                try
            {
                serialPort1.Write(tBoxDisplaySend.Text);
                progressBar_run.Value = 0;
                btn_stop.Enabled = false;
                btn_run.Enabled = true;
                timerGraph.Enabled = false;
                serialPort1.Write("s");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btResetPoint_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            ZedGraph_Initialize();
            timerGraph.Enabled = false;
            ZedGraph_Initialize();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            setvel = Convert.ToSingle(txtVelocity.Text);
            //serialPort1.Write(txtVelocity.Text + "v");
        }
        private void timerGraph_Tick(object sender, EventArgs e)
        {

            float realvel_dc;
            float.TryParse(data, out realvel_dc);
            Invoke(new MethodInvoker(() => draw((realvel_dc), (setvel))));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
