using Backend.Core.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
    public partial class SelectAudiencePack : Form
    {
        Form1 Form1 { get; set; }
        int id { get; set; }

        AudiencePackGetDTO pack { get; set; }

        public SelectAudiencePack(Form1 form1, AudiencePackGetDTO packGetDTO, List<AudienceGetDTO> audienceList, bool enable)
        {
            InitializeComponent();
            Form1 = form1;
            this.id = id;

            pack = packGetDTO;

            if (pack == null)
            {
                this.Close();
            }
           
            textBox1.Text = pack.AudiencePackName;
            textBox2.Text = pack.Price.ToString();
            if (!enable)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                comboBox1.Enabled = false;
                numericUpDown1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                foreach (var item in audienceList)
                {
                    comboBox1.Items.Add(item.AudienceId.ToString() + " " + item.Age.ToString() + " " + (item.Sex ? "Man" : "Woman"));
                }
            }
            
            UpdateAudienceList();
        }

        public void UpdateAudienceList()
        {
            Audiences.Items.Clear();
            foreach (var audience in pack.Audiences)
            {
                Audiences.Items.Add(audience.AudienceId.ToString() + " " + audience.AudienceAge.ToString() + " " + (audience.AudienceSex ? "Man" : "Woman") + " x" + audience.AudienceCount.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                return;
            }
            pack.Audiences.Add(new AAPDTO
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
            pack.Audiences.RemoveAt(Audiences.SelectedIndex);
            UpdateAudienceList();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                await Form1._service.PatchAudiencePack(new AudiencePackPatchDTO()
                {
                    AudiencePackId = pack.AudiencePackId,
                    AudiencePackName = textBox1.Text,
                    Price = Convert.ToInt32(textBox2.Text),
                    Audiences = pack.Audiences
                });

                Form1.LodingDataBase();

                this.Close();

            }
            catch
            {
                return;
            }

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var message = MessageBox.Show("Дійсно видалити?", "Питання?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    bool del = await Form1._service.DeleteAudiencePack(pack.AudiencePackId);
                    if (del)
                    {
                        Form1.LodingDataBase();
                        this.Close();
                    }
                }

            }
            catch
            {
                return;
            }
        }
    }
}