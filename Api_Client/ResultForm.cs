using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Api_Client
{
    public partial class ResultForm : Form
    {
        List<LoginData> data;
        public ResultForm(List<LoginData> data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            foreach(LoginData i in data)
            {
                dgv.Rows.Add(i.Id,i.Username,i.Password,i.Roles);
            }
        }
    }
}
