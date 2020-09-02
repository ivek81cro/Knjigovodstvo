﻿using Knjigovodstvo.Code;
using Knjigovodstvo.Gui;
using Knjigovodstvo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knjigovodstvo
{
    public partial class partnersForm : Form
    {
        public partnersForm()
        {
            InitializeComponent();
            LoadDatagrid();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Partner searchPartner = new Partner();
            List<Partner> partners = searchPartner.GetPartners(namePartnerTextBox.Text);
            //TODO Partner search https://www.youtube.com/watch?v=Et2khGnrIqc&list=PLLWMQd6PeGY3b89Ni7xsNZddi9wD5Esv2
        }

        private void BtnNewPartner_Click(object sender, EventArgs e)
        {
            PartnersNew form = new PartnersNew();
            form.ShowDialog();
        }

        private void LoadDatagrid()
        {
            DbDataGet data = new DbDataGet();
            dataGridView1.DataSource = data.GetTable("SELECT * FROM Partneri;");
        }
    }
}
