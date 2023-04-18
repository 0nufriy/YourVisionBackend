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
    public partial class EditNeedAudience : Form
    {
        Form1 form1;
        int id;
        int count;
        public EditNeedAudience(Form1 form1, string item, int id)
        {
            InitializeComponent();
            this.form1 = form1;
            this.id = id;
            this.count = Convert.ToInt32(item.Split("   x")[1]);
            numericUpDown1.Value = count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.audienceNeed[id] = form1.audienceNeed[id].Split("   x")[0] + "   x" + numericUpDown1.Value.ToString();
            form1.UpdateNeed();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
