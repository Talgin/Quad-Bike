using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Management;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.IO.Ports;


namespace RunJoyStickOnLocalMachine
{
    public partial class Form1 : Form
    {
        private Joystick joystick;
        private bool[] joystickButtons;
        public Form1()
        {
            InitializeComponent();
            joystick = new Joystick(this.Handle);
            connectToJoystick(joystick);
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        //---------------------------------------------------------------------
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

        private void joystickTimer_Tick_1(object sender, EventArgs e)
        {
            try
            {
                joystick.UpdateStatus();
                joystickButtons = joystick.buttons;
               
                if (joystick.Xaxis == 0)
                {                    
                    try
                    {
                        SP.Open();
                        SP.Write("e");
                        Thread.Sleep(1);
                        SP.Close();
                    }
                    catch
                    {
                        MessageBox.Show("ERROR");
                    }

                    output.Text += "Left\n";
                }

                if (joystick.Xaxis == 65535) //right
                {
                    try
                    {
                        SP.Open();
                        SP.Write("f");
                        Thread.Sleep(1);
                        SP.Close();
                    }
                    catch
                    {
                        MessageBox.Show("ERROR");
                    }
                    
                    output.Text += "Right\n";
                }

                if (joystick.Yaxis == 0)
                {
                    try
                    {
                        SP.Open();
                        SP.Write("a");
                        Thread.Sleep(5);
                        SP.Close();
                    }
                    catch
                    {
                        MessageBox.Show("ERROR");
                    }
                    
                    output.Text += "Down\n";
                }                
                if (joystick.Yaxis == 65535)
                {
                    try
                    {
                        SP.Open();
                        SP.Write("b");
                        Thread.Sleep(5);
                        SP.Close();
                    }
                    catch
                    {
                        MessageBox.Show("ERROR");
                    }

                    output.Text += "Up\n";
                }
                
                if (joystick.jsPOV[0] == 27000)
                {
                    try
                    {
                        SP.Open();
                        SP.Write("c");
                        Thread.Sleep(5);
                        SP.Close();
                    }
                    catch
                    {
                        MessageBox.Show("ERROR");
                    }

                    output.Text += Convert.ToString(joystick.jsPOV[0]) + "\n";
                }

                if (joystick.jsPOV[0] == 9000)
                {
                    try
                    {
                        SP.Open();
                        SP.Write("d");
                        Thread.Sleep(5);
                        SP.Close();
                    }
                    catch
                    {
                        MessageBox.Show("ERROR");
                    }

                    output.Text += Convert.ToString(joystick.jsPOV[0]) + "\n";
                }

                if (joystick.jsPOV[0] == 18000)
                {
                    try
                    {
                        SP.Open();
                        SP.Write("g");
                        Thread.Sleep(5);
                        SP.Close();
                    }
                    catch
                    {
                        MessageBox.Show("ERROR");
                    }

                    output.Text += Convert.ToString(joystick.jsPOV[0]) + "\n";
                }
                
                for (int i = 0; i < joystickButtons.Length; i++)
                {
                    if(joystickButtons[i] == true)
                        output.Text+="Button " + i + " Pressed\n";
                }
                SP.Dispose();
            }
            catch
            {
                joystickTimer.Enabled = false;
                connectToJoystick(joystick);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            output.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SP.PortName = comboBox1.Text.ToString();
        }

        private void output_TextChanged(object sender, EventArgs e)
        {
            output.SelectionStart = output.Text.Length;
            output.ScrollToCaret();
        }

       
    }
}
