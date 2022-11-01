using Newtonsoft.Json;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;
using WinApi.AddCountry;

namespace WinApi
{
    public partial class Form1 : Form
    {
        protected readonly HttpClient client1;
        protected readonly string Uri;
        public Form1()
        {
            HttpClient client = new HttpClient();
            client1 = client;
            string uri = "http://localhost:5255/Country";
            Uri = uri;
            InitializeComponent();
            pictureBox1.ImageLocation = "https://avatars.mds.yandex.net/i?id=06b34990d4cad7fb89b5197e484c73a1-4836671-images-thumbs&n=13";
        }
        private async Task<List<Countrys>> Get()
        {
            var responce = await client1.GetAsync(Uri);
            if (responce.IsSuccessStatusCode)
            {
                var con = responce.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var data = JsonConvert.DeserializeObject<List<Countrys>>(con);
                return data;
            }
            return null;
        }

        private void AddPanel(Countrys country)
        {
            winUser win = new winUser(country);
            win.Dock = DockStyle.Top;
            panel1.Controls.Add(win);
        }
       
        

        private async void button1_Click(object sender, EventArgs e)
        {

            var con = await Get();
            panel1.Controls.Clear();
            foreach (var country in con)
            {
                AddPanel(country);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCountrys add = new AddCountrys();
            add.Show();
        }
    }
}