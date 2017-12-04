using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace wright2
{
    public partial class Form1 : Form
    {
        private static string rxtring = "";
        public Form1()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();
                button1.Enabled = false;
                button2.Enabled = true;
                textBox1.Enabled = true;
                


            }
            catch (UnauthorizedAccessException)
            {
                label1.Text = "Null value";
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            //textBox1.Text = "";
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void serialPort1_DataReceived(object sender,System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                rxtring = serialPort1.ReadExisting();
                this.Invoke(new EventHandler(displaytest));
            }
            catch(System.TimeoutException) {
                label1.Text = "data receive";
            }
        }
        private void displaytest(object s, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                label1.Text = "Port Open";
                string[] rxvalue = rxtring.Split(new char[1] { ' ' });
                foreach(string rxv in rxvalue)
                {
                    int rxvalue1 = int.Parse(rxv);
                    int[] rxsum=new int[5];
                    
                    
                    if (rxvalue1 > 0)
                    {
                        textBox1.Text = rxvalue1.ToString();
                    }
                    else
                    {
                        textBox1.Text = "0";
                    }   
                    //textBox1.Text = rxv;
                }
                //textBox1.Text = rxvalue;
                //textBox1.AppendText(rxtring);
                                
                
            }
            else
            {
                
                label1.Text = "port Close";
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("MM:mm:ss");
            label4.Text = time;
        }
        
    }
}
