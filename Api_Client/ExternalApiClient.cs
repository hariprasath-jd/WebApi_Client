using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Api_Client
{
    public partial class ExternalApiClient : Form
    {
        public ExternalApiClient()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            var details = await client.GetAsync("http://universities.hipolabs.com/search?country=india");

            if(details.IsSuccessStatusCode)
            {

            }

        }
    }
}
