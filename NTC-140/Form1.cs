using SimpleBrowser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTC_140
{
    public partial class Form1 : Form
    {
        string contentType = "application/x-www-form-urlencoded";
        string modemIP = "http://192.168.1.1/";
        void configureACS()
        { string tr069uri = "TR069.html?server";
            Browser modem = new Browser();
            modem.Navigate(modemIP);
            //login in
            string postData = "src_page=&username=admin&password=admin";
           
            Uri _uri = new Uri(modemIP);
            modem.Navigate(_uri, postData, contentType);
            // you forgot to post username and password you FAT FUCK!!!
            string modemURL = modemIP + tr069uri;
            modem.Navigate(modemURL);

            //post ACS details
          
            postData = "tr069_enable=1&periodic_enable=1&tr069Enable=1&ACSURL=http%3A%2F%2Facs.netcommwireless.com%2Fcpe.php&username=cpe&password=cpe&Vpassword=cpe&ConReq_username=cpe&ConReq_password=cpe&ConReq_Vpassword=cpe&periodicEnable=1&periodic_interval=86398";
             _uri = new Uri(modemURL);
            modem.Navigate(_uri, postData, contentType);



        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            configureACS();
        }
    }
}
