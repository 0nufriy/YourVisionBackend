using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOTI.Model.Audience
{
    public partial class SelectAudience : Form
    {

        public int Id;
        public Form1 Form1;

        public SelectAudience(int id, Form1 form1)
        {
            InitializeComponent();
            Id = id;
            Form1 = form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.count = 0;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.count = Convert.ToInt32(numericUpDown1.Value);
            this.Close();
        }
    }
}
