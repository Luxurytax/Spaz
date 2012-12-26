using System;
using System.Drawing;
using System.Windows.Forms;

namespace Spaz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = txtSpeed.Text == string.Empty ? 500 : Convert.ToInt32(txtSpeed.Text);
            timer1.Enabled = true;
        }

        public void SwitchColors()
        {
            try
            {
                timer1.Interval = txtSpeed.Text == string.Empty ? 500 : Convert.ToInt32(txtSpeed.Text);

                if (chkRainbow.Checked == false)
                {
                    if (button1.BackColor == Color.Red)
                        button1.BackColor = Color.Blue;
                    else if (button1.BackColor == Color.Blue)
                        button1.BackColor = Color.Red;
                    else if (button1.BackColor != Color.Red)
                        button1.BackColor = Color.Blue;
                }
                else
                {
                    button1.BackColor = ColorTranslator.FromHtml(GetColor());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SwitchColors();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Interval = txtSpeed.Text == string.Empty ? 500 : Convert.ToInt32(txtSpeed.Text);
            timer1.Enabled = true;
        }

        private string GetColor()
        {
            var random = new Random();
            var color = String.Format("#{0:X6}", random.Next(0x1000000));

            return color;
        }

        private void txtSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            //allows backspace key
            if (e.KeyChar != '\b')
            {
                //allows just number keys
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }
    }
}