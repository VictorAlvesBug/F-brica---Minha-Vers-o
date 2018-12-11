using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Windows.Forms.Client
{
    public partial class frmPostman : Form
    {
        public frmPostman()
        {
            InitializeComponent();
        }

        private string _url = "";

        private void btnSend_Click(object sender, EventArgs e)
        {
            _url = txtUrl.Text;

            var ponto = new Point(3, 4);

            string json = JsonConvert.SerializeObject(ponto, Formatting.None);
            Console.WriteLine(json);
            json = JsonConvert.SerializeObject(ponto, Formatting.Indented);
            Console.WriteLine(json);

            switch (cmbMethod.SelectedItem)
            {
                case "Get":
                    Get();
                    break;

                case "Post":
                    Post();
                    break;

                case "Put":
                    Put();
                    break;

                case "Delete":
                    Delete();
                    break;
            }
        }

        private void Get()
        {

        }

        private void Post()
        {

        }

        private void Put()
        {

        }

        private void Delete()
        {

        }
    }
}
