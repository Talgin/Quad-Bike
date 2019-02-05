using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Management;
using System.Drawing.Imaging;
using System.Collections;

namespace com_port
{
    public partial class Form1 : Form
    {
        private SerialPort port;
        private Boolean connected;
        //private int position;
        private Boolean btn1 = false;
        //string cbState;
        private string[] ports;
        private Joystick joystick;
        private bool[] joystickButtons;        
        public Form1()
        {
            InitializeComponent();
            listPorts();
            joystick = new Joystick(this.Handle);
            connectToJoystick(joystick);
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);           
        }
        private void defineStatus(bool status) //  connected/disconnected
        {
            if (status == true)
            {
                label2.Text = "Connected";
                label2.ForeColor = Color.Green;
                connected = true;
            }
            else
            {
                label2.Text = "Disconnected";
                label2.ForeColor = Color.Red;
                connected = false;
            }
        }
        private void listPorts() // vyvod spiska portov
        {
            ports = SerialPort.GetPortNames();

            SerialPort[] myPorts = new SerialPort[ports.Length];
            if (ports.Length > 0) // esli k kakomu-to portu podsoedineno
            {
                comboBox1.Items.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

                foreach (string s in SerialPort.GetPortNames())
                {
                    comboBox1.Items.Add(s);
                 //   comboBox2.Items.Add(s);
                }

                defineStatus(false);

                permissions(true, true, false, true, true, false, false);
            }
            else
            {
                defineStatus(false);
                 permissions(false, false, false, false, true, false, false);
               
                MessageBox.Show(this, "No connected ports", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void permissions(bool ports, bool connected, bool disconnected,
            bool baudrate, bool checkd, bool bright, bool bleft) // chto mozhno vypolnyat' 
        {
            comboBox1.Enabled = ports;
            btC.Enabled = connected;
            btD.Enabled = disconnected;
            comboBox2.Enabled = baudrate;
            btCheck.Enabled = checkd;
           // btRight.Enabled = bright;
            // btLeft.Enabled = bleft;
        }
        private void fetchPort() // prochityvaem sostoyanie porta
        {
            if (port != null && port.IsOpen && btn1)
            {
                port.Close();
                port = null;
                defineStatus(false);
                listPorts();
            }
        }
        private void connectToJoystick(Joystick joystick)
        {
            while (true)
            {
                string sticks = joystick.FindJoysticks();
                if (sticks != null)
                {
                    if (joystick.AcquireJoystick(sticks))
                    {
                        enableTimer();
                        break;
                    }
                }
            }
        }
        private void enableTimer()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new ThreadStart(delegate()
                {
                    joystickTimer.Enabled = true;
                }));
            }
            else
                joystickTimer.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                wbPlatformCam.Navigate("http://192.168.0.143");
                //joystickTimer.Enabled = true;
                System.ComponentModel.IContainer components = new System.ComponentModel.Container();
                if (comboBox1.SelectedIndex != -1)
                {
                    port = new System.IO.Ports.SerialPort(components);
                    port.PortName = comboBox1.SelectedItem.ToString();
                    port.BaudRate = Convert.ToInt32(comboBox2.SelectedItem);//9600;//Int32.Parse(comboBoxBaudRate.SelectedItem.ToString());
                    port.DtrEnable = true;
                    
                }
                else
                {
                    throw new Exception("Select right BAUD rate!");
                }

                if (!port.IsOpen)
                {
                    port.Open();
                    //position = 0;
                    port.WriteLine("150");
                    Thread.Sleep(100);

                    permissions(false, false, true, false, false, true, true);
                    defineStatus(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Could not connect to port. \nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message m, Keys keyData) // obrabotka podannyh komand i nazhatiya klavish
        {
            try
            {                
                if (connected == true)
                {
                    joystick.UpdateStatus();
                    joystickButtons = joystick.buttons;
                    bool visit = false;
                    bool blnProcess = false;                    
                    // start 1234 commands
                    if (keyData == Keys.Right && joystick.Xaxis == 0 && joystick.Yaxis == 65535 && keyData == Keys.Up) // aceg - left+left+down+forward
                    {
                        outputWindow.Text += "aceg\n";
                        port.WriteLine("j");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Right && joystick.Xaxis == 0 && joystick.Yaxis == 0 && keyData == Keys.Up) // acfg - left+left+up+forward
                    {
                        outputWindow.Text += "acfg\n";
                        port.WriteLine("k");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Right && joystick.Xaxis == 65535 && joystick.Yaxis == 65535 && keyData == Keys.Up) // adeg - left+right+down+forward
                    {
                        outputWindow.Text += "adeg\n";
                        port.WriteLine("l");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Right && joystick.Xaxis == 65535 && joystick.Yaxis == 0 && keyData == Keys.Up) // adfg - left+right+up+forward
                    {
                        outputWindow.Text += "adfg\n";
                        port.WriteLine("m");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Left && joystick.Xaxis == 0 && joystick.Yaxis == 65535 && keyData == Keys.Up) // bceg - right+left+down+forward
                    {
                        outputWindow.Text += "bceg\n";
                        port.WriteLine("n");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Left && joystick.Xaxis == 0 && joystick.Yaxis == 0 && keyData == Keys.Up) // bcfg - right+left+up+forward
                    {
                        outputWindow.Text += "bcfg\n";
                        port.WriteLine("o");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Left && joystick.Xaxis == 65535 && joystick.Yaxis == 65535 && keyData == Keys.Up) // bdeg - right+right+down+forward
                    {
                        outputWindow.Text += "bdeg\n";
                        port.WriteLine("p");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Left && joystick.Xaxis == 65535 && joystick.Yaxis == 0 && keyData == Keys.Up) // bdfg - right+right+up+forward
                    {
                        outputWindow.Text += "bdfg\n";
                        port.WriteLine("q");
                        blnProcess = true;
                        visit = true;
                    }
                    // end of 1234 commands; 234
                    if (joystick.Xaxis == 0 && joystick.Yaxis == 65535 && keyData == Keys.Up) // ceg - left+down+forward
                    {
                        outputWindow.Text += "ceg\n";
                        port.WriteLine("r");
                        blnProcess = true;
                        visit = true;
                    }
                    if (joystick.Xaxis == 0 && joystick.Yaxis == 0 && keyData == Keys.Up) // cfg - left+up+forward
                    {
                        outputWindow.Text += "cfg\n";
                        port.WriteLine("s");
                        blnProcess = true;
                        visit = true;
                    }
                    if (joystick.Xaxis == 65535 && joystick.Yaxis == 65535 && keyData == Keys.Up) // deg - right+down+forward
                    {
                        outputWindow.Text += "deg\n";
                        port.WriteLine("t");
                        blnProcess = true;
                        visit = true;
                    }
                    if (joystick.Xaxis == 65535 && joystick.Yaxis == 0 && keyData == Keys.Up) // dfg - right+up+forward
                    {
                        outputWindow.Text += "dfg\n";
                        port.WriteLine("u");
                        blnProcess = true;
                        visit = true;
                    }
                    // 134
                    if (keyData == Keys.Right && joystick.Yaxis == 65535 && keyData == Keys.Up) // aeg - left+down+forward
                    {
                        outputWindow.Text += "aeg\n";
                        port.WriteLine("v");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Right && joystick.Yaxis == 0 && keyData == Keys.Up) // afg - left+up+forward
                    {
                        outputWindow.Text += "afg\n";
                        port.WriteLine("w");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Left && joystick.Yaxis == 65535 && keyData == Keys.Up) // beg - right+down+forward
                    {
                        outputWindow.Text += "beg\n";
                        port.WriteLine("x");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Left && joystick.Yaxis == 0 && keyData == Keys.Up) // bfg - right+up+forward
                    {
                        outputWindow.Text += "bfg\n";
                        port.WriteLine("y");
                        blnProcess = true;
                        visit = true;
                    }     
                    // 134; 124
                    if (keyData == Keys.Right && joystick.Xaxis == 0 && keyData == Keys.Up) // acg - left+up+forward
                    {
                        outputWindow.Text += "acg\n";
                        port.WriteLine("z");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Right && joystick.Xaxis == 65535 && keyData == Keys.Up) // adg - left+down+forward
                    {
                        outputWindow.Text += "adg\n";
                        port.WriteLine("A");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Left && joystick.Xaxis == 0 && keyData == Keys.Up) // bcg - right+up+forward
                    {
                        outputWindow.Text += "bcg\n";
                        port.WriteLine("B");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Left && joystick.Xaxis == 65535 && keyData == Keys.Up) // bdg - right+down+forward
                    {
                        outputWindow.Text += "bdg\n";
                        port.WriteLine("C");
                        blnProcess = true;
                        visit = true;
                    }
                    // 124; 23
                    if (joystick.Xaxis == 0 && joystick.Yaxis == 65535) // ce - left+down
                    {
                        outputWindow.Text += "ce\n";
                        port.WriteLine("D");
                        blnProcess = true;
                        visit = true;
                    }
                    if (joystick.Xaxis == 0 && joystick.Yaxis == 0) // cf - left+up
                    {
                        outputWindow.Text += "cf\n";
                        port.WriteLine("E");
                        blnProcess = true;
                        visit = true;
                    }
                    if (joystick.Xaxis == 65535 && joystick.Yaxis == 65535) // de - right+down
                    {
                        outputWindow.Text += "de\n";
                        port.WriteLine("F");
                        blnProcess = true;
                        visit = true;
                    }
                    if (joystick.Xaxis == 65535 && joystick.Yaxis == 0) // df - right+up
                    {
                        outputWindow.Text += "df\n";
                        port.WriteLine("G");
                        blnProcess = true;
                        visit = true;
                    }
                    // 23; 14
                    if (keyData == Keys.Right && keyData == Keys.Up) // ag - left+forward
                    {
                        outputWindow.Text += "ag\n";
                        port.WriteLine("H");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.Left && keyData == Keys.Up) // bg - right+forward
                    {
                        outputWindow.Text += "bg\n";
                        port.WriteLine("I");
                        blnProcess = true;
                        visit = true;
                    }
                    // 14; 24
                    if (joystick.Xaxis == 0 && keyData == Keys.Up) // cg - left+forward
                    {
                        outputWindow.Text += "cg\n";
                        port.WriteLine("J");
                        blnProcess = true;
                        visit = true;
                    }
                    if (joystick.Xaxis == 65535 && keyData == Keys.Up) // dg - right+forward
                    {
                        outputWindow.Text += "dg\n";
                        port.WriteLine("K");
                        blnProcess = true;
                        visit = true;
                    } 
                    // 24; 34
                    if (joystick.Yaxis == 65535 && keyData == Keys.Up) // eg - down+forward
                    {
                        outputWindow.Text += "eg\n";
                        port.WriteLine("L");
                        blnProcess = true;
                        visit = true;
                    }
                    if (joystick.Yaxis == 0 && keyData == Keys.Up) // fg - up+forward
                    {
                        outputWindow.Text += "fg\n";
                        port.WriteLine("M");
                        blnProcess = true;
                        visit = true;
                    }
                    if (keyData == Keys.W)
                    {
                        outputWindow.Text += "Speed up\n";
                        port.WriteLine("W");
                        blnProcess = true;
                    }
                    if(keyData == Keys.S)
                    {
                        outputWindow.Text += "Speed down\n";
                        port.WriteLine("S");
                        blnProcess = true;
                    }
                    // 34; 
                    if (joystick.Yaxis == 0)
                    {
                        outputWindow.Text += "Up\n";
                        port.WriteLine("e");
                        blnProcess = true;
                    }
                    if (joystick.Yaxis == 65535)
                    {
                        outputWindow.Text += "Down\n";
                        port.WriteLine("f");
                        blnProcess = true;
                    }
                    if (joystick.Xaxis == 0)
                    {
                        outputWindow.Text += "Left\n";
                        port.WriteLine("c");
                        blnProcess = true;
                    }
                    if (joystick.Xaxis == 65535)
                    {
                        outputWindow.Text += "Right\n";
                        port.WriteLine("d");
                        blnProcess = true;
                    }
                    //single keys                    
                    else if (keyData == Keys.Right && !visit)
                    {
                        outputWindow.Text += "Right turn\n";
                        port.WriteLine("b");
                        blnProcess = true;
                    }
                    else if (keyData == Keys.Left && !visit)
                    {
                        outputWindow.Text += "Left turn\n";
                        port.WriteLine("a");
                        blnProcess = true;
                    }
                    else if (keyData == Keys.Up && !visit)
                    {
                        outputWindow.Text += "Forward\n";
                        port.WriteLine("g");
                        blnProcess = true;
                    }
                    else if (keyData == Keys.R && !visit)
                    {
                        outputWindow.Text += "Back trans\n";
                        port.WriteLine("h");
                        blnProcess = true;
                    }
                    else if (keyData == Keys.D && !visit)
                    {
                        outputWindow.Text += "Forward trans\n";
                        port.WriteLine("i");
                        blnProcess = true;
                    }                                 
                    if (blnProcess == true)
                    {
                        return true;
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref m, keyData);
                    }
                    //visit = false;                                 
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                joystickTimer.Enabled = false;
                connectToJoystick(joystick);
                return false;
            }            
        }
        private void btCheck_Click(object sender, EventArgs e)
        {
            listPorts();
        }
        private void btD_Click(object sender, EventArgs e)
        {
            btn1 = true;
            fetchPort();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void Form1_FormClosing(object sender, EventArgs e)
        {
            //if (port.IsOpen)
            //port.Close();      
            fetchPort();
        }

        /* - correcting system
         * - range sensor 
         * 
        
         */
    }
}
