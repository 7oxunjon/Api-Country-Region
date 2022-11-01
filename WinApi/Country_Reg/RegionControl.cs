using Helper.Helper_Api;
using Microsoft.VisualStudio.Services.Profile;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;
using ProjoctApiCountry.Model.Mod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApi.Exercises_CountryReg.Region;

namespace WinApi.Country_Reg
{
    public partial class RegionControl : UserControl
    {
        private readonly string _uri;
        private readonly int _CountryId;
        private readonly HttpClient _client;
        private readonly Regions _region;
        private readonly ModelHelper _Model;
        public RegionControl(Regions region, int id)
        {
            _uri = "http://localhost:5255/Region";
            _CountryId = id;
            InitializeComponent();
            _Model = new ModelHelper(_client, _uri);
            _client = new HttpClient();
            _region = region;
            label1.Text = _region.Title;
            label2.Text = _region.Short_title;
            label3.Text = _region.Code;
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
             await _Model.DeleteReg(_region.Id);
            DialogResult result = MessageBox.Show("Delete?",
                "A Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                string s =  await _Model.DeleteReg(_region.Id);
                MessageBox.Show(s);
            }
            else
            {
              
            }

        }

        private void Update(object sender, EventArgs e)
        {
            UpdateRegion region = new UpdateRegion(_region.Id,_region);
            region.Show();
        }
    }
}
