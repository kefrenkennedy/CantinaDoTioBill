﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CantinaDoTioBill
{
    public partial class Welcome : Form
    {
        public Welcome(string username)
        {
            InitializeComponent();
            welcomeLabel.Text = "Bem-vindo, " + username + "!";
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

        }
    }
}
