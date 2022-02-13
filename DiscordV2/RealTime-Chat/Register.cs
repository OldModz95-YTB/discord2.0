using System;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Collections.Generic;// Copyright © 2021 ProtonDev. All rights reserved.
using System.ComponentModel;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Data;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Drawing;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Linq;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Text;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Threading.Tasks;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Windows.Forms;// Copyright © 2021 ProtonDev. All rights reserved.
using MySql.Data;// Copyright © 2021 ProtonDev. All rights reserved.
using MySql.Data.MySqlClient;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Net.NetworkInformation;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Net;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Threading;// Copyright © 2021 ProtonDev. All rights reserved.
// Copyright © 2021 ProtonDev. All rights reserved.
namespace RealTime_Chat
{// Copyright © 2021 ProtonDev. All rights reserved.
    public partial class Register : Form// Copyright © 2021 ProtonDev. All rights reserved.
    {// Copyright © 2021 ProtonDev. All rights reserved.
        Random r = new Random();// Copyright © 2021 ProtonDev. All rights reserved.
        bool suruklenmedurumu = false;// Copyright © 2021 ProtonDev. All rights reserved.
        Point ilkkonum;// Copyright © 2021 ProtonDev. All rights reserved.
        public MySqlConnection db = new MySqlConnection("Server=localhost;Database=discordchat;Uid=root;Pwd='';");// Copyright © 2021 ProtonDev. All rights reserved.
        public MySqlCommand cmd = new MySqlCommand();// Copyright © 2021 ProtonDev. All rights reserved.
        public MySqlDataAdapter adtr;// Copyright © 2021 ProtonDev. All rights reserved.
        public MySqlDataReader dr;// Copyright © 2021 ProtonDev. All rights reserved.
        public DataSet ds;// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        public Register()// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            InitializeComponent();// Copyright © 2021 ProtonDev. All rights reserved.
            timeip.Start();// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        #region MouseMove
        private void panel1_MouseMove(object sender, MouseEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            if (suruklenmedurumu)// Copyright © 2021 ProtonDev. All rights reserved.
            {// Copyright © 2021 ProtonDev. All rights reserved.
                this.Left = e.X + this.Left - (ilkkonum.X);// Copyright © 2021 ProtonDev. All rights reserved.
                this.Top = e.Y + this.Top - (ilkkonum.Y);// Copyright © 2021 ProtonDev. All rights reserved.
            }// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = true;
            this.Cursor = Cursors.SizeAll;
            ilkkonum = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = false;
            this.Cursor = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();

        }
        #endregion

        private void btnRegister_Click(object sender, EventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            Create(txtUsername.Text, txtPassword.Text, txtEmail.Text, txtFullname.Text, txtSecretanswer.Text, txtip.Text);// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        #region RegisterForm
        private void Create(String username, String password, String email, String fullname, String secretanswer, String ip)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            if (txtUsername.Text.Trim() != "" &&// Copyright © 2021 ProtonDev. All rights reserved.
             txtPassword.Text.Trim() != "" &&// Copyright © 2021 ProtonDev. All rights reserved.
             txtEmail.Text.Trim() != "" &&// Copyright © 2021 ProtonDev. All rights reserved.
             txtFullname.Text.Trim() != "" &&// Copyright © 2021 ProtonDev. All rights reserved.
             txtSecretanswer.Text.Trim() != "" &&// Copyright © 2021 ProtonDev. All rights reserved.
             txtip.Text.Trim() != "")// Copyright © 2021 ProtonDev. All rights reserved.
            {// Copyright © 2021 ProtonDev. All rights reserved.
                // Copyright © 2021 ProtonDev. All rights reserved.
                Ping ping = new Ping();// Copyright © 2021 ProtonDev. All rights reserved.
                PingReply pingStatus = ping.Send(IPAddress.Parse("216.58.209.14")); // ping connectiın google 
                if (pingStatus.Status == IPStatus.Success)// Copyright © 2021 ProtonDev. All rights reserved.
                {// Copyright © 2021 ProtonDev. All rights reserved.
                    try// Copyright © 2021 ProtonDev. All rights reserved.
                    {// Copyright © 2021 ProtonDev. All rights reserved.
                        db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                        db.Open();// Copyright © 2021 ProtonDev. All rights reserved.
                        cmd = new MySqlCommand("Insert Into user(username,password,email,fullname,secretanswer,ip,status) Values ('"
                           + username.Trim() + "','"
                           + password.Trim() + "','"
                           + email.Trim() + "','"
                           + fullname.Trim() + "','"
                           + secretanswer.Trim() + "','"
                           + ip.Trim() + "','"
                           + 0 + "')", db);// Copyright © 2021 ProtonDev. All rights reserved.
                        object sonuc = null;// Copyright © 2021 ProtonDev. All rights reserved.
                        sonuc = cmd.ExecuteNonQuery();// Copyright © 2021 ProtonDev. All rights reserved.
                        db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                        if (sonuc != null)// Copyright © 2021 ProtonDev. All rights reserved.
                        {// Copyright © 2021 ProtonDev. All rights reserved.
                            MessageBox.Show("successful", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);// Copyright © 2021 ProtonDev. All rights reserved.
                            txtUsername.Text = "";// Copyright © 2021 ProtonDev. All rights reserved.
                            txtPassword.Text = "";// Copyright © 2021 ProtonDev. All rights reserved.
                            txtEmail.Text = "";// Copyright © 2021 ProtonDev. All rights reserved.
                            txtFullname.Text = "";// Copyright © 2021 ProtonDev. All rights reserved.
                            txtSecretanswer.Text = "";// Copyright © 2021 ProtonDev. All rights reserved.
                            txtip.Text = "";// Copyright © 2021 ProtonDev. All rights reserved.
                            this.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                            Login log = new Login();// Copyright © 2021 ProtonDev. All rights reserved.
                            log.Show();// Copyright © 2021 ProtonDev. All rights reserved.
                            db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                        }// Copyright © 2021 ProtonDev. All rights reserved.
                        else// Copyright © 2021 ProtonDev. All rights reserved.
                        {// Copyright © 2021 ProtonDev. All rights reserved.
                            MessageBox.Show("Could not add to add.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);// Copyright © 2021 ProtonDev. All rights reserved.
                            db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                        }// Copyright © 2021 ProtonDev. All rights reserved.
                    }// Copyright © 2021 ProtonDev. All rights reserved.
                    catch (Exception ex)// Copyright © 2021 ProtonDev. All rights reserved.
                    {// Copyright © 2021 ProtonDev. All rights reserved.
                        MessageBox.Show("Take another email or username", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);// Copyright © 2021 ProtonDev. All rights reserved.
                        MessageBox.Show(ex.Message.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);// Copyright © 2021 ProtonDev. All rights reserved.
                        db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                    }// Copyright © 2021 ProtonDev. All rights reserved.
                }// Copyright © 2021 ProtonDev. All rights reserved.
                else// Copyright © 2021 ProtonDev. All rights reserved.
                {// Copyright © 2021 ProtonDev. All rights reserved.
                    MessageBox.Show("Check your internet connection.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);// Copyright © 2021 ProtonDev. All rights reserved.
                    db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                }// Copyright © 2021 ProtonDev. All rights reserved.
            }// Copyright © 2021 ProtonDev. All rights reserved.
            else// Copyright © 2021 ProtonDev. All rights reserved.
            {// Copyright © 2021 ProtonDev. All rights reserved.
                MessageBox.Show("can not be empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);// Copyright © 2021 ProtonDev. All rights reserved.
                db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
            }// Copyright © 2021 ProtonDev. All rights reserved.
            // Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        #endregion// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            Login log = new Login();// Copyright © 2021 ProtonDev. All rights reserved.
            log.Show();// Copyright © 2021 ProtonDev. All rights reserved.
            this.Hide();// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            if (e.KeyCode == Keys.Enter)// Copyright © 2021 ProtonDev. All rights reserved.
            {// Copyright © 2021 ProtonDev. All rights reserved.
                btnRegister.PerformClick();// Copyright © 2021 ProtonDev. All rights reserved.
                e.Handled = true;// Copyright © 2021 ProtonDev. All rights reserved.
            }// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void timeip_Tick(object sender, EventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            UTF8Encoding utf8 = new UTF8Encoding();// Copyright © 2021 ProtonDev. All rights reserved.
            WebClient webClient = new WebClient();// Copyright © 2021 ProtonDev. All rights reserved.
            String externalIp = utf8.GetString(webClient.DownloadData("https://v4.ident.me/"));// Copyright © 2021 ProtonDev. All rights reserved.
            txtip.Text = externalIp;// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            new contact().Show();// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
    }// Copyright © 2021 ProtonDev. All rights reserved.
}// Copyright © 2021 ProtonDev. All rights reserved.
 // Copyright © 2021 ProtonDev. All rights reserved.
 // Copyright © 2021 ProtonDev. All rights reserved.
 // Copyright © 2021 ProtonDev. All rights reserved.
 // Copyright © 2021 ProtonDev. All rights reserved.
 // Copyright © 2021 ProtonDev. All rights reserved.
 // Copyright © 2021 ProtonDev. All rights reserved.
 // Copyright © 2021 ProtonDev. All rights reserved.
 // Copyright © 2021 ProtonDev. All rights reserved.