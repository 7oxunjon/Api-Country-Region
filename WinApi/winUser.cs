
using Helper.Helper_Api;
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
using WinApi.Exercises_CountryReg.Country;

namespace WinApi
{
    public partial class winUser : UserControl
    {
      private readonly Countrys country1;
        private readonly ModelHelper model; 
        private readonly HttpClient client1;
        private readonly string _uri;
        public winUser(Countrys country)
        {
            HttpClient client = new HttpClient();
            string uri = "http://localhost:5255/Country";
            client1 = client;
            _uri = uri;
            country1 = country;
            ModelHelper helper = new ModelHelper(client1,_uri);
            model = helper;
            InitializeComponent();
            label2.Text = country1.Title;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Country_Title title = new Country_Title( country1);
             title.Show();

        }

        private async void Delete(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete?",
                "A Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                string s = await model.Delete(country1.Id);
                MessageBox.Show(s);
            }
            else
            {
                Country_Title _Title = new Country_Title(country1);
                _Title.Close();
            }

        }

        private void Update(object sender, EventArgs e)
        {
            UpdateCountry update = new UpdateCountry(country1);
            update.Show();
        }
    }
}
