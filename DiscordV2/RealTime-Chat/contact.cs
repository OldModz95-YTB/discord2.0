using System;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Collections.Generic;// Copyright © 2021 ProtonDev. All rights reserved.
using System.ComponentModel;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Data;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Drawing;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Linq;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Text;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Threading.Tasks;// Copyright © 2021 ProtonDev. All rights reserved.
using System.Windows.Forms;// Copyright © 2021 ProtonDev. All rights reserved.
// Copyright © 2021 ProtonDev. All rights reserved.
namespace RealTime_Chat// Copyright © 2021 ProtonDev. All rights reserved.
{// Copyright © 2021 ProtonDev. All rights reserved.
    public partial class contact : Form// Copyright © 2021 ProtonDev. All rights reserved.
    {// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        bool suruklenmedurumu = false;// Copyright © 2021 ProtonDev. All rights reserved.
        Point ilkkonum;// Copyright © 2021 ProtonDev. All rights reserved.
        public contact()// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            InitializeComponent();// Copyright © 2021 ProtonDev. All rights reserved.
            banner.Visible = true;// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void btnExit_Click(object sender, EventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            this.Close();// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void btnRegister_Click(object sender, EventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            System.Diagnostics.Process.Start("https://discord.gg/3t2568W");// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void button1_Click(object sender, EventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            System.Diagnostics.Process.Start("https://shop.protondev.eu/fr/nous-contacter");// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void panel1_MouseMove(object sender, MouseEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            if (suruklenmedurumu)// Copyright © 2021 ProtonDev. All rights reserved.
            {// Copyright © 2021 ProtonDev. All rights reserved.
                this.Left = e.X + this.Left - (ilkkonum.X);// Copyright © 2021 ProtonDev. All rights reserved.
                this.Top = e.Y + this.Top - (ilkkonum.Y);// Copyright © 2021 ProtonDev. All rights reserved.
            }// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void panel1_MouseDown(object sender, MouseEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            suruklenmedurumu = true;// Copyright © 2021 ProtonDev. All rights reserved.
            this.Cursor = Cursors.SizeAll;// Copyright © 2021 ProtonDev. All rights reserved.
            ilkkonum = e.Location;// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
        // Copyright © 2021 ProtonDev. All rights reserved.
        private void panel1_MouseUp(object sender, MouseEventArgs e)// Copyright © 2021 ProtonDev. All rights reserved.
        {// Copyright © 2021 ProtonDev. All rights reserved.
            suruklenmedurumu = false;// Copyright © 2021 ProtonDev. All rights reserved.
            this.Cursor = Cursors.Default;// Copyright © 2021 ProtonDev. All rights reserved.
        }// Copyright © 2021 ProtonDev. All rights reserved.
    }// Copyright © 2021 ProtonDev. All rights reserved.
}// Copyright © 2021 ProtonDev. All rights reserved.
 // Copyright © 2021 ProtonDev. All rights reserved.