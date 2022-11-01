using Helper.Helper_Api;
using Microsoft.VisualStudio.Services.Profile;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApi.Country_Reg;

namespace WinApi.Exercises_CountryReg.Country
{
    public partial class UpdateCountry : Form
    {
        protected readonly Countrys _countrys;
        protected readonly HttpClient _client;
        protected readonly string _uri;
        protected readonly ModelHelper model;
        public UpdateCountry(Countrys countrys)
        {
            _client = new HttpClient();
            _uri = "http://localhost:5255/Country";
            model = new ModelHelper(_client, _uri);
            _countrys = countrys;
            InitializeComponent();
            textBox1.Text = _countrys.Id.ToString();
            textBox2.PlaceholderText = _countrys.Title;
            textBox3.PlaceholderText = _countrys.Short_title;
            textBox4.PlaceholderText = _countrys.Code;
        }

        private async void UpdateCon(object sender, EventArgs e)
        {
            CountryDTO dTO = new CountryDTO();
            dTO.Title = textBox2.Text;
            dTO.Short_title = textBox3.Text;
            dTO.Code = textBox4.Text;
            DialogResult result = MessageBox.Show("Update?",
                "Do you want a data update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                string con = await model.Update(int.Parse(textBox1.Text), dTO);
                MessageBox.Show(con);
            }
            else
            {
                UpdateCountry update = new UpdateCountry(_countrys);
                update.Close();
            }
        }
    }
}
