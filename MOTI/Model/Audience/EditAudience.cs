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
    public partial class EditAudience : Form
    {
        Form1 Form1 { get; set; }
        int Age { get; set; }
        bool Sex { get; set; }
        int Id { get; set; }
        public EditAudience(Form1 form1, int age, bool sex, int id)
        {
            InitializeComponent();
            Form1 = form1;
            Age = age;
            Sex = sex;
            Id = id;
            numericUpDown1.Value = age;
            comboBox1.SelectedIndex = Sex ? 0 : 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex < 0)
            {
                return;
            }
            try
            {
                await Form1._service.PatchAudience(new Backend.Core.Models.AudienceGetDTO() { Age = Convert.ToInt32(numericUpDown1.Value), AudienceId = Id, Sex = comboBox1.SelectedIndex  == 0});

            }
            catch
            {
                return;
            }
            Form1.LodingDataBase();
            this.Close() ;
        }
    }
}
