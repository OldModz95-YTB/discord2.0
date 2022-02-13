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
namespace RealTime_Chat// Copyright © 2021 ProtonDev. All rights reserved.
{// Copyright © 2021 ProtonDev. All rights reserved.
    public partial class Forgot : Form// Copyright © 2021 ProtonDev. All rights reserved.
    {// Copyright © 2021 ProtonDev. All rights reserved.
        Random r = new Random();// Copyright © 2021 ProtonDev. All rights reserved.
        bool suruklenmedurumu = false;// Copyright © 2021 ProtonDev. All rights reserved.
        Point ilkkonum;// Copyright © 2021 ProtonDev. All rights reserved.
        public MySqlConnection db = new MySqlConnection("Server=localhost;Database=chatc;Uid=root;Pwd='';");// Copyright © 2021 ProtonDev. All rights reserved.
        public MySqlCommand cmd = new MySqlCommand();// Copyright © 2021 ProtonDev. All rights reserved.
        public MySqlDataAdapter adtr;// Copyright © 2021 ProtonDev. All rights reserved.
        public MySqlDataReader dr;// Copyright © 2021 ProtonDev. All rights reserved.
        public DataSet ds;// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        public Forgot()// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            InitializeComponent();// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        #region MouseMove
        private void panel1_MouseMove(object sender, MouseEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            if (suruklenmedurumu) // Copyright © 2021 ProtonDev. All rights reserved.
            {// Copyright © 2021 ProtonDev. All rights reserved.
                this.Left = e.X + this.Left - (ilkkonum.X);// Copyright © 2021 ProtonDev. All rights reserved.
                this.Top = e.Y + this.Top - (ilkkonum.Y);// Copyright © 2021 ProtonDev. All rights reserved.
            }// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void panel1_MouseDown(object sender, MouseEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            suruklenmedurumu = true; // Copyright © 2021 ProtonDev. All rights reserved.
            this.Cursor = Cursors.SizeAll; // Copyright © 2021 ProtonDev. All rights reserved.
            ilkkonum = e.Location; // Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void panel1_MouseUp(object sender, MouseEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            suruklenmedurumu = false; // Copyright © 2021 ProtonDev. All rights reserved.
            this.Cursor = Cursors.Default; // Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void btnExit_Click(object sender, EventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            Login log = new Login();// Copyright © 2021 ProtonDev. All rights reserved.
            log.Show();// Copyright © 2021 ProtonDev. All rights reserved.
            this.Close();// Copyright © 2021 ProtonDev. All rights reserved.
            // Copyright © 2021 ProtonDev. All rights reserved.
        }
        #endregion// Copyright © 2021 ProtonDev. All rights reserved.

        private void btnRegister_Click(object sender, EventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            try// Copyright © 2021 ProtonDev. All rights reserved.
            {// Copyright © 2021 ProtonDev. All rights reserved.
                db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                db.Open();// Copyright © 2021 ProtonDev. All rights reserved.
                cmd = new MySqlCommand("Select *From user where username  ='" + txtUsername.Text + "' AND email = '"+txtEmail.Text +"' AND secretanswer ='"+txtSecretanser.Text+"'", db);// Copyright © 2021 ProtonDev. All rights reserved.
                dr = cmd.ExecuteReader();// Copyright © 2021 ProtonDev. All rights reserved.
                Ping ping = new Ping();// Copyright © 2021 ProtonDev. All rights reserved.
                PingReply pingStatus = ping.Send(IPAddress.Parse("216.58.209.14"));// Copyright © 2021 ProtonDev. All rights reserved.
                if (pingStatus.Status == IPStatus.Success)// Copyright © 2021 ProtonDev. All rights reserved.
                {// Copyright © 2021 ProtonDev. All rights reserved.
                    if (dr.Read())// Copyright © 2021 ProtonDev. All rights reserved.
                    {// Copyright © 2021 ProtonDev. All rights reserved.
                        if (txtUsername.Text.ToString() == dr["username"].ToString())// Copyright © 2021 ProtonDev. All rights reserved.
                        {// Copyright © 2021 ProtonDev. All rights reserved.
                            if (txtEmail.Text.ToString() == dr["email"].ToString())// Copyright © 2021 ProtonDev. All rights reserved.
                            {// Copyright © 2021 ProtonDev. All rights reserved.
                                if (txtSecretanser.Text.ToString() == dr["secretanswer"].ToString())// Copyright © 2021 ProtonDev. All rights reserved.
                                {// Copyright © 2021 ProtonDev. All rights reserved.
                                    MessageBox.Show("Your Password : " + dr["password"].ToString());// Copyright © 2021 ProtonDev. All rights reserved.
                                    db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                                    Login log = new Login();// Copyright © 2021 ProtonDev. All rights reserved.
                                    log.Show();// Copyright © 2021 ProtonDev. All rights reserved.
                                    this.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                                    // Copyright © 2021 ProtonDev. All rights reserved.
                                }// Copyright © 2021 ProtonDev. All rights reserved.
                            }// Copyright © 2021 ProtonDev. All rights reserved.
                            // Copyright © 2021 ProtonDev. All rights reserved.
                        }// Copyright © 2021 ProtonDev. All rights reserved.
                        // Copyright © 2021 ProtonDev. All rights reserved.
                    }// Copyright © 2021 ProtonDev. All rights reserved.
                }// Copyright © 2021 ProtonDev. All rights reserved.
                else// Copyright © 2021 ProtonDev. All rights reserved.
                {// Copyright © 2021 ProtonDev. All rights reserved.
                    MessageBox.Show("Check your Internet connection.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);// Copyright © 2021 ProtonDev. All rights reserved.
                    db.Close();// Copyright © 2021 ProtonDev. All rights reserved.
                }// Copyright © 2021 ProtonDev. All rights reserved.
            }// Copyright © 2021 ProtonDev. All rights reserved.
            catch (MySqlException ex)// Copyright © 2021 ProtonDev. All rights reserved.
            {// Copyright © 2021 ProtonDev. All rights reserved.
                MessageBox.Show(ex.Message.ToString());// Copyright © 2021 ProtonDev. All rights reserved.
            }// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            Login log = new Login();// Copyright © 2021 ProtonDev. All rights reserved.
            log.Show();// Copyright © 2021 ProtonDev. All rights reserved.
            this.Hide();// Copyright © 2021 ProtonDev. All rights reserved.
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
 // Copyright © 2021 ProtonDev. All rights reserved.
// Copyright © 2021 ProtonDev. All rights reserved.
// Copyright © 2021 ProtonDev. All rights reserved.