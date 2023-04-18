using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOTI.Model
{
    public partial class AddAudience : Form
    {
        Form1 Form1 { get; set; }
        public AddAudience(Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }

            await Form1._service.PostAudience(new Backend.Core.Models.AudiencePostDTO() { Age = Convert.ToInt32(numericUpDown1.Value), Sex = comboBox1.SelectedIndex == 0 });
            Form1.LodingDataBase();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
