using Helper.Helper_Api;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;
using ProjoctApiCountry.Model.Mod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApi.Exercises_CountryReg.Region
{
    public partial class UpdateRegion : Form
    {
        protected readonly Regions _regions;
        protected readonly int _id;
        protected readonly HttpClient _client;
        protected readonly string _uri;
        protected readonly ModelHelper _model;

        public UpdateRegion(int id,Regions regions)
        {
            _client = new HttpClient();
            _uri = "http://localhost:5255/Region";
            _regions = regions;
            _model = new ModelHelper(_client, _uri);
            _id = id;
            InitializeComponent();

            textBox1.Text =_id.ToString();
            textit.PlaceholderText = _regions.Title;
            textShor.PlaceholderText = _regions.Short_title;
            textcod.PlaceholderText = _regions.Code;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            RegionDTO dTO = new RegionDTO();
            dTO.Title = textit.Text;
            dTO.Short_title = textShor.Text;
            dTO.Code = textcod.Text;
            dTO.CountryId = _id;
            DialogResult result = MessageBox.Show("Update ?",
                "Do you want a data update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if(result == DialogResult.Yes)
            {
                string reg = await _model.UpdateReg(_regions.Id, dTO);
                MessageBox.Show(reg);
            }
            else
            {
                
            }
        }
    }
}
