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

namespace WinApi.AddCountry
{
    public partial class AddCountrys : Form
    {
        
        protected readonly string _uri;
        protected readonly ModelHelper model;
        protected readonly HttpClient _client;
        public AddCountrys()
        {
            HttpClient client = new HttpClient();
            _client = client;
            _uri ="http://localhost:5255/Country";
            model = new ModelHelper(client, _uri);

            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            CountryDTO countryDTO = new CountryDTO();
            countryDTO.Title = textit.Text;
            countryDTO.Short_title = textShor.Text;
            countryDTO.Code = textcod.Text;
            
            DialogResult result = MessageBox.Show("Insert?",
                "A Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                string inser = await model.Insert(countryDTO);
                MessageBox.Show(inser);
            }
            else
            {
                
            }
        }
    }
}
