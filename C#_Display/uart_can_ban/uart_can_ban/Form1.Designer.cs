namespace uart_can_ban
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cBoxStopBit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cBoxDataBit = new System.Windows.Forms.ComboBox();
            this.cBoxParityBit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxPortName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Transmiter = new System.Windows.Forms.GroupBox();
            this.tBoxDisplaySend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.progressBar_run = new System.Windows.Forms.ProgressBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btResetPoint = new System.Windows.Forms.Button();
            this.btSetPoint = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtKdSet = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKiSet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKpSet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.timerGraph = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.Transmiter.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(243, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(800, 503);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cBoxStopBit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cBoxDataBit);
            this.groupBox1.Controls.Add(this.cBoxParityBit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cBoxBaudRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBoxPortName);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 163);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Serial Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Stop Bit";
            // 
            // cBoxStopBit
            // 
            this.cBoxStopBit.FormattingEnabled = true;
            this.cBoxStopBit.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cBoxStopBit.Location = new System.Drawing.Point(70, 136);
            this.cBoxStopBit.Name = "cBoxStopBit";
            this.cBoxStopBit.Size = new System.Drawing.Size(121, 21);
            this.cBoxStopBit.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Parity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data Bit";
            // 
            // cBoxDataBit
            // 
            this.cBoxDataBit.FormattingEnabled = true;
            this.cBoxDataBit.Location = new System.Drawing.Point(70, 82);
            this.cBoxDataBit.Name = "cBoxDataBit";
            this.cBoxDataBit.Size = new System.Drawing.Size(121, 21);
            this.cBoxDataBit.TabIndex = 5;
            // 
            // cBoxParityBit
            // 
            this.cBoxParityBit.FormattingEnabled = true;
            this.cBoxParityBit.Location = new System.Drawing.Point(70, 109);
            this.cBoxParityBit.Name = "cBoxParityBit";
            this.cBoxParityBit.Size = new System.Drawing.Size(121, 21);
            this.cBoxParityBit.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Baud Rate";
            // 
            // cBoxBaudRate
            // 
            this.cBoxBaudRate.FormattingEnabled = true;
            this.cBoxBaudRate.Location = new System.Drawing.Point(70, 55);
            this.cBoxBaudRate.Name = "cBoxBaudRate";
            this.cBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.cBoxBaudRate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PortName";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cBoxPortName
            // 
            this.cBoxPortName.FormattingEnabled = true;
            this.cBoxPortName.Location = new System.Drawing.Point(70, 28);
            this.cBoxPortName.Name = "cBoxPortName";
            this.cBoxPortName.Size = new System.Drawing.Size(121, 21);
            this.cBoxPortName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.btnDisconnect);
            this.groupBox2.Location = new System.Drawing.Point(12, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 65);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial Port Control";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(189, 10);
            this.progressBar1.TabIndex = 14;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(8, 35);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(115, 35);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 13;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBox1);
            this.groupBox4.Location = new System.Drawing.Point(11, 326);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 165);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Receiver";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(186, 134);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 492);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Transmiter
            // 
            this.Transmiter.Controls.Add(this.tBoxDisplaySend);
            this.Transmiter.Controls.Add(this.btnSend);
            this.Transmiter.Location = new System.Drawing.Point(18, 255);
            this.Transmiter.Name = "Transmiter";
            this.Transmiter.Size = new System.Drawing.Size(200, 49);
            this.Transmiter.TabIndex = 15;
            this.Transmiter.TabStop = false;
            this.Transmiter.Text = "Transmiter";
            // 
            // tBoxDisplaySend
            // 
            this.tBoxDisplaySend.Location = new System.Drawing.Point(3, 16);
            this.tBoxDisplaySend.Name = "tBoxDisplaySend";
            this.tBoxDisplaySend.Size = new System.Drawing.Size(109, 20);
            this.tBoxDisplaySend.TabIndex = 16;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(127, 13);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(67, 23);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(21, 297);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 15;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(123, 297);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 15;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // progressBar_run
            // 
            this.progressBar_run.Location = new System.Drawing.Point(102, 297);
            this.progressBar_run.Name = "progressBar_run";
            this.progressBar_run.Size = new System.Drawing.Size(15, 23);
            this.progressBar_run.TabIndex = 15;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btResetPoint);
            this.groupBox5.Controls.Add(this.btSetPoint);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txtVelocity);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox5.Location = new System.Drawing.Point(1050, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 127);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Set Velocity";
            // 
            // btResetPoint
            // 
            this.btResetPoint.Location = new System.Drawing.Point(107, 71);
            this.btResetPoint.Name = "btResetPoint";
            this.btResetPoint.Size = new System.Drawing.Size(77, 33);
            this.btResetPoint.TabIndex = 19;
            this.btResetPoint.Text = "Reset";
            this.btResetPoint.UseVisualStyleBackColor = true;
            this.btResetPoint.Click += new System.EventHandler(this.btResetPoint_Click);
            // 
            // btSetPoint
            // 
            this.btSetPoint.Location = new System.Drawing.Point(13, 71);
            this.btSetPoint.Name = "btSetPoint";
            this.btSetPoint.Size = new System.Drawing.Size(77, 33);
            this.btSetPoint.TabIndex = 17;
            this.btSetPoint.Text = "Set";
            this.btSetPoint.UseVisualStyleBackColor = true;
            this.btSetPoint.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(130, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "(RPM)";
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(47, 28);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(77, 26);
            this.txtVelocity.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Vel:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtKdSet);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.txtKiSet);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.txtKpSet);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(1063, 148);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 156);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "PID Parameters";
            // 
            // txtKdSet
            // 
            this.txtKdSet.Location = new System.Drawing.Point(44, 120);
            this.txtKdSet.Name = "txtKdSet";
            this.txtKdSet.Size = new System.Drawing.Size(77, 26);
            this.txtKdSet.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Kd";
            // 
            // txtKiSet
            // 
            this.txtKiSet.Location = new System.Drawing.Point(44, 75);
            this.txtKiSet.Name = "txtKiSet";
            this.txtKiSet.Size = new System.Drawing.Size(77, 26);
            this.txtKiSet.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Ki";
            // 
            // txtKpSet
            // 
            this.txtKpSet.Location = new System.Drawing.Point(44, 35);
            this.txtKpSet.Name = "txtKpSet";
            this.txtKpSet.Size = new System.Drawing.Size(77, 26);
            this.txtKpSet.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Kp";
            // 
            // timerGraph
            // 
            this.timerGraph.Interval = 10;
            this.timerGraph.Tick += new System.EventHandler(this.timerGraph_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 527);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.progressBar_run);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.Transmiter);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.Transmiter.ResumeLayout(false);
            this.Transmiter.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBoxStopBit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBoxDataBit;
        private System.Windows.Forms.ComboBox cBoxParityBit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxPortName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox Transmiter;
        private System.Windows.Forms.TextBox tBoxDisplaySend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.ProgressBar progressBar_run;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btSetPoint;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVelocity;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btResetPoint;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtKiSet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtKpSet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKdSet;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timerGraph;
    }
}

