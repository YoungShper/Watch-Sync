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

namespace Watch_Sync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] ports = SerialPort.GetPortNames();
            foreach(string s in ports)
            {
                comboBox1.Items.Add(s);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(DateTime.Now);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SerialPort serialPort = new SerialPort(comboBox1.Text);
                serialPort.BaudRate = 9600;
                serialPort.Open();
                serialPort.WriteLine(Convert.ToString(DateTime.Now.Second));
                serialPort.WriteLine(Convert.ToString(DateTime.Now.Minute));
                serialPort.WriteLine(Convert.ToString(DateTime.Now.Hour));
                serialPort.WriteLine(Convert.ToString(DateTime.Now.Day));
                serialPort.WriteLine(Convert.ToString(DateTime.Now.Month));
                serialPort.WriteLine(Convert.ToString(DateTime.Now.Year - 2000));
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Sunday: serialPort.WriteLine("0"); break;
                    case DayOfWeek.Monday: serialPort.WriteLine("0"); break;
                    case DayOfWeek.Tuesday: serialPort.WriteLine("0"); break;
                    case DayOfWeek.Wednesday: serialPort.WriteLine("0"); break;
                    case DayOfWeek.Thursday: serialPort.WriteLine("0"); break;
                    case DayOfWeek.Friday: serialPort.WriteLine("0"); break;
                    case DayOfWeek.Saturday: serialPort.WriteLine("0"); break;
                }
                serialPort.Close();
                Console.WriteLine(DateTime.Now);
                MessageBox.Show("Время синхронизировано, проверьте часы");
            }
            catch { MessageBox.Show("Ошибка");  }
        }
    }
}



