using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;
// Copyright © 2022 ProtonDev. All rights reserved.
namespace RealTime_Chat
{// Copyright © 2022 ProtonDev. All rights reserved.
    public partial class Login : Form
    {
        Random r = new Random();
        bool suruklenmedurumu = false;
        Point ilkkonum;
        public MySqlConnection db = new MySqlConnection("Server=localhost;Database=chat;Uid=root;Pwd='';");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataAdapter adtr;
        public MySqlDataReader dr;
        public DataSet ds;
        // Copyright © 2022 ProtonDev. All rights reserved.
        public Login()
        {
            InitializeComponent();
        }
        // Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        #region MouseMove
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {// Copyright © 2022 ProtonDev. All rights reserved.
            if (suruklenmedurumu) 
            {
                this.Left = e.X + this.Left - (ilkkonum.X);
                this.Top = e.Y + this.Top - (ilkkonum.Y);
            }
        }// Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
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
            Application.Exit();
        }
        #endregion
        // Copyright © 2022 ProtonDev. All rights reserved.
        private void btnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {// Copyright © 2022 ProtonDev. All rights reserved.
            Register reg = new Register();
            reg.Show();
            this.Hide();
            // Copyright © 2022 ProtonDev. All rights reserved.
        }// Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        private void btnLogin_Click(object sender, EventArgs e)
        {// Copyright © 2022 ProtonDev. All rights reserved.
            SignIn(txtUsername.Text, txtPassword.Text);
        }// Copyright © 2022 ProtonDev. All rights reserved.
        #region SignIn
        private void SignIn(String username, String password) {
            // Copyright © 2022 ProtonDev. All rights reserved.
            try
            {// Copyright © 2022 ProtonDev. All rights reserved.
                db.Close();
                db.Open();
                cmd = new MySqlCommand("Select *From user where username  ='" + username + "'", db);
                dr = cmd.ExecuteReader();
                if (username.Trim() != "" && password.Trim() != "")
                {// Copyright © 2022 ProtonDev. All rights reserved.
                    Ping ping = new Ping();
                    PingReply pingStatus = ping.Send(IPAddress.Parse("216.58.209.14"));
                    if (pingStatus.Status == IPStatus.Success)
                    {// Copyright © 2022 ProtonDev. All rights reserved.
                        if (dr.Read())
                        {// Copyright © 2022 ProtonDev. All rights reserved.
                            if (username.ToString() == dr["username"].ToString())
                            {// Copyright © 2022 ProtonDev. All rights reserved.
                                if (password.ToString() == dr["password"].ToString())
                                {// Copyright © 2022 ProtonDev. All rights reserved.
                                    String id = dr["id"].ToString();
                                    Properties.Settings.Default.id = Convert.ToInt16(dr["id"]);
                                    Properties.Settings.Default.username = dr["username"].ToString();
                                    Properties.Settings.Default.password = dr["password"].ToString();
                                    Properties.Settings.Default.email = dr["email"].ToString();
                                    Properties.Settings.Default.fullname = dr["fullname"].ToString();
                                    Properties.Settings.Default.secretanswer = dr["secretanswer"].ToString();
                                    Properties.Settings.Default.status = Convert.ToInt16(dr["status"]);
                                    Properties.Settings.Default.Save();
                                    db.Close();// Copyright © 2022 ProtonDev. All rights reserved.
                                    cmd = new MySqlCommand();// Copyright © 2022 ProtonDev. All rights reserved.
                                    db.Open();// Copyright © 2022 ProtonDev. All rights reserved.
                                    cmd.Connection = db;
                                    cmd.CommandText = "Update user set status='" + 1 + "' where id=" + id + "";// Copyright © 2022 ProtonDev. All rights reserved.
                                    cmd.ExecuteNonQuery();// Copyright © 2022 ProtonDev. All rights reserved.
                                    db.Close();// Copyright © 2022 ProtonDev. All rights reserved.
                                    Main main = new Main();// Copyright © 2022 ProtonDev. All rights reserved.
                                    main.Show();// Copyright © 2022 ProtonDev. All rights reserved.
                                    this.Hide();// Copyright © 2022 ProtonDev. All rights reserved.
                                }// Copyright © 2022 ProtonDev. All rights reserved.
                                else// Copyright © 2022 ProtonDev. All rights reserved.
                                {// Copyright © 2022 ProtonDev. All rights reserved.
                                    MessageBox.Show("Your password is missing or incorrect..", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    db.Close();
                                }// Copyright © 2022 ProtonDev. All rights reserved.
                            }// Copyright © 2022 ProtonDev. All rights reserved.
                            else
                            {// Copyright © 2022 ProtonDev. All rights reserved.
                                MessageBox.Show("Your username is missing or incorrect.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                db.Close();
                            }// Copyright © 2022 ProtonDev. All rights reserved.
                        }// Copyright © 2022 ProtonDev. All rights reserved.
                        else
                        {// Copyright © 2022 ProtonDev. All rights reserved.
                            MessageBox.Show("No such user.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);// Copyright © 2022 ProtonDev. All rights reserved.
                            db.Close();// Copyright © 2022 ProtonDev. All rights reserved.
                        }// Copyright © 2022 ProtonDev. All rights reserved.
                    }// Copyright © 2022 ProtonDev. All rights reserved.
                    else// Copyright © 2022 ProtonDev. All rights reserved.
                    {// Copyright © 2022 ProtonDev. All rights reserved.
                        MessageBox.Show("Check your Internet connection.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);// Copyright © 2022 ProtonDev. All rights reserved.
                        db.Close();// Copyright © 2022 ProtonDev. All rights reserved.
                    }// Copyright © 2022 ProtonDev. All rights reserved.
                }// Copyright © 2022 ProtonDev. All rights reserved.
            }// Copyright © 2022 ProtonDev. All rights reserved.
            catch (MySqlException ex)// Copyright © 2022 ProtonDev. All rights reserved.
            {// Copyright © 2022 ProtonDev. All rights reserved.
                MessageBox.Show(ex.Message.ToString());// Copyright © 2022 ProtonDev. All rights reserved.
            }// Copyright © 2022 ProtonDev. All rights reserved.
        }// Copyright © 2022 ProtonDev. All rights reserved.
        #endregion// Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        private void btnForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)// Copyright © 2022 ProtonDev. All rights reserved.
        {// Copyright © 2022 ProtonDev. All rights reserved.
            Forgot forgot = new Forgot();// Copyright © 2022 ProtonDev. All rights reserved.
            forgot.Show();// Copyright © 2022 ProtonDev. All rights reserved.
            this.Hide();// Copyright © 2022 ProtonDev. All rights reserved.
        }// Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        private void Login_Load(object sender, EventArgs e)// Copyright © 2022 ProtonDev. All rights reserved.
        {// Copyright © 2022 ProtonDev. All rights reserved.
            //If you want the program to open once, remove the lines.
            /*
             Mutex Mtx = new Mutex(false, "SINGLE_INSTANCE_APP_MUTEX");
            if (Mtx.WaitOne(0, false) == false)
            {
                Mtx.Close();
                Mtx = null;
                Application.Exit();
            }
             */
        }// Copyright © 2022 ProtonDev. All rights reserved.
        // Copyright © 2022 ProtonDev. All rights reserved.
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)// Copyright © 2022 ProtonDev. All rights reserved.
        {// Copyright © 2022 ProtonDev. All rights reserved.
         new contact().Show();// Copyright © 2022 ProtonDev. All rights reserved.
        }// Copyright © 2022 ProtonDev. All rights reserved.
    }// Copyright © 2022 ProtonDev. All rights reserved.
}// Copyright © 2022 ProtonDev. All rights reserved.
 // Copyright © 2022 ProtonDev. All rights reserved.
 // Copyright © 2022 ProtonDev. All rights reserved.
 // Copyright © 2022 ProtonDev. All rights reserved.
 // Copyright © 2022 ProtonDev. All rights reserved.
 // Copyright © 2022 ProtonDev. All rights reserved.
 // Copyright © 2022 ProtonDev. All rights reserved.