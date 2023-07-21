using Newtonsoft.Json;
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
    public partial class CreateResouce : Form
    {
        HttpClient client;
        public CreateResouce()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiLink = "https://localhost:44391/api/User/Post";
            LoginData data = new LoginData() { Username = txtUsername.Text, Password = txtPasswd.Text, Roles = txtRoles.Text };
            string ser_data = JsonConvert.SerializeObject(data);
            HttpContent content = new StringContent(ser_data, Encoding.UTF8, "application/json");

            var request  = await client.PostAsync(apiLink, content);
            txtresult.Text = "resource Sent!!";
            if (request.IsSuccessStatusCode)
            {
                string response = await request.Content.ReadAsStringAsync();
                txtresult.Text = "Done :)";
                txtResult2.Text = "Message: " + response;
            }
            else
            {
                txtresult.Text = "Error";
                txtResult2.Text = "Request failed with status code: "+ request.StatusCode ;
            }
        }

        
    }
}
