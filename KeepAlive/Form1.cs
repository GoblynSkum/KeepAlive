using System;
using System.Linq;
using System.Windows.Forms;

namespace KeepAlive
{
    public partial class Form1 : Form
    {
    	
        public bool exitLoop = true;
        // Set These 2 vars to change key and timing
        public String keyStroke = "{F5}";
        public int timeSeconds = 60;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            long countMinutes = 0 ;
            this.Show();
            while (exitLoop)
            {
                System.Windows.Forms.SendKeys.Send(keyStroke);
                label1.Text = countMinutes.ToString();
                DateTime Tthen = DateTime.Now;
                do
                {
                    Application.DoEvents();
                } while (Tthen.AddSeconds(timeSeconds) > DateTime.Now);
                countMinutes += 1;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
        	// note the while loop will exit next cycle after app exit 
            exitLoop = false;
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            exitLoop = false;
            Application.Exit();          
        }
    }
}
