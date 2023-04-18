using Backend.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOTI.Model.AudiencePack
{
    public partial class AddAudiencePack : Form
    {
        Form1 Form1 { get; set; }

        List<AAPDTO> pack { get; set; }

        public AddAudiencePack(Form1 form1, List<AudienceGetDTO> audienceList)
        {
            InitializeComponent();
            Form1 = form1;
            pack = new List<AAPDTO>();
            foreach (var item in audienceList)
            {
                comboBox1.Items.Add(item.AudienceId.ToString() + " " + item.Age.ToString() + " " + (item.Sex ? "Man" : "Woman"));
            }
        }

        public void UpdateAudienceList()
        {
            Audiences.Items.Clear();
            foreach (var audience in pack)
            {
                Audiences.Items.Add(audience.AudienceId.ToString() + " " + audience.AudienceAge.ToString() + " " + (audience.AudienceSex ? "Man" : "Woman") + " x" + audience.AudienceCount.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }
            pack.Add(new AAPDTO
            {
                AudienceAge = Convert.ToInt32(comboBox1.SelectedItem.ToString().Split(" ")[1]),
                AudienceCount = Convert.ToInt32(numericUpDown1.Value),
                AudienceId = Convert.ToInt32(comboBox1.SelectedItem.ToString().Split(" ")[0]),
                AudienceSex = comboBox1.SelectedItem.ToString().Split(" ")[2] == "Man"
            });
            UpdateAudienceList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Audiences.SelectedItems.Count == 0)
            {
                return;
            }
            pack.RemoveAt(Audiences.SelectedIndex);
            UpdateAudienceList();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var add = await Form1._service.PostAudiencePack(new AudiencePackPostDTO()
                {
                    AudiencePackName = textBox1.Text,
                    Price = Convert.ToInt32(textBox2.Text),
                    Audiences = pack
                });
                if (add != null)
                {
                    Form1.LodingDataBase();
                    //this.Close();
                }
            }
            catch
            {
                return;
            }
        }
    }
}
