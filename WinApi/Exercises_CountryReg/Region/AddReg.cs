using Helper.Helper_Api;
using ProjoctApiCountry.DTO;
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

namespace WinApi.Exercises_CountryReg.Region
{
    public partial class AddReg : Form
    {
        protected readonly string _uri;
        protected readonly ModelHelper _model;
        protected readonly HttpClient _client;
        protected readonly int _id;
        public AddReg(int id)
        {
            _client = new HttpClient();
            _uri = "http://localhost:5255/Region";
            _model = new ModelHelper(_client, _uri);
            _id = id;
            InitializeComponent();
            textcountid.Text = _id.ToString();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            RegionDTO _regionDTO = new RegionDTO();
            _regionDTO.Title = textit.Text;
            _regionDTO.Short_title = textShor.Text;
            _regionDTO.Code = textcod.Text;
            _regionDTO.CountryId = _id;

            DialogResult result = MessageBox.Show("Update ?",
               "Do you want a data update",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question,
               MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                string reg = await _model.InsertReg(_regionDTO);
                MessageBox.Show(reg);
            }
            else
            {

            }
        }
    }
}
