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


        public SelectAudiencePack(Form1 form1, AudiencePackGetDTO packGetDTO)
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
            foreach (var audience in pack.Audiences)
            {
                Audiences.Items.Add(audience.AudienceId.ToString() + " " + audience.AudienceAge.ToString() + (audience.AudienceSex ? "Man" : "Woman"));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}