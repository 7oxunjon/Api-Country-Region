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
    public partial class Country_Title : Form
    {
        private readonly Countrys _country;
        public Country_Title(Countrys country)
        {
            _country = country;
            InitializeComponent();
            label1.Text = _country.Title;
            label2.Text = _country.Short_title;
            label3.Text = _country.Code;
            foreach(var item in country.Regions)
            {
                AddPanel(item, item.Id);
            }
        }

       private void AddPanel(Regions regions, int id)
        {
            RegionControl region = new RegionControl(regions, id);
            region.Dock = DockStyle.Top;
            panel1.Controls.Add(region);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddReg add = new AddReg(_country.Id);
            add.Show();
        }
    }
}
