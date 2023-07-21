using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Api_Client
{
    public partial class Form1 : Form
    {
        HttpClient httpClient;
        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("https://localhost:44391/api/User");
        }

        private  void BtnLoad_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            // Make the API request and get the response
            var _response =  httpClient.GetAsync("https://localhost:44391/api/User/GetAdmin");
            
            //var _response = httpClient.GetAsync("/");   
            _response.Wait();

            var _result = _response.Result;
            if (_result.IsSuccessStatusCode)
            {
                var data = _result.Content.ReadAsAsync<List<LoginData>>();
                data.Wait();    
                List<LoginData> _data = data.Result;
                foreach(LoginData i in _data)
                {
                    Debug.WriteLine(i.Username+' '+i.Password+' '+i.Roles);
                }
                result.ForeColor = Color.Green;
                result.Text = "Data Loaded!!!";
                ResultForm rf = new ResultForm(_data);
                rf.ShowDialog();
            }
            else if (_result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                result.ForeColor = Color.Red;
                result.Text = "Invalid credintials";
            }
            else
            {
                result.ForeColor = Color.Red;
                result.Text = "Data Not Loaded!!!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateResouce res = new CreateResouce();
            res.ShowDialog();
        }
    }
}
