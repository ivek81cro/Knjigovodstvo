﻿using Knjigovodstvo.Code.Validators;
using Knjigovodstvo.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Knjigovodstvo
{
    public class Partner
    {
        public bool ValidateData()
        {
            if (!new OibValidator().Validate(Oib))
                return false;
            if (Naziv.Length < 2)
                return false;
            if (Adresa.Length < 2)
                return false;
            if (Posta.Length != 5)
                return false;
            if (Grad.Length < 2)
                return false;
            if (!new IbanValidator().Validate(Iban))
                return false;
            if (Kupac != 'k' && Dobavljac != 'd')
                return false;

            return true;
        }

        public bool InsertNew()
        {
            if(new DbDataInsert().InsertPartner(this))
                return true;

            return false;
        }

        public bool EditPartner(int id)
        {
            Id = id;
            if (new DbDataUpdate().UpadatePartner(this))
                return true;

            return false;
        }

        public Partner GetPartnerById(int id)
        {
            DataTable partner = new DbDataGet().GetTable(String.Format("SELECT * FROM Partneri WHERE Id={0};",id));
            return new Partner
            {
                Id = int.Parse(partner.Rows[0][0].ToString()),
                Oib = partner.Rows[0][1].ToString(),
                Naziv = partner.Rows[0][2].ToString(),
                Adresa = partner.Rows[0][3].ToString(),
                Posta = partner.Rows[0][4].ToString(),
                Grad = partner.Rows[0][5].ToString(),
                Telefon = partner.Rows[0][6].ToString(),
                Fax = partner.Rows[0][7].ToString(),
                Mail = partner.Rows[0][8].ToString(),
                Iban = partner.Rows[0][9].ToString(),
                Mbo = partner.Rows[0][10].ToString(),
                Kupac = char.Parse(partner.Rows[0][11].ToString()),
                Dobavljac = char.Parse(partner.Rows[0][12].ToString())
            };
        }

        public int Id { get; set; }
        public string Oib { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Posta { get; set; }
        public string Grad { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        public string Iban { get; set; }
        public string Mbo { get; set; }
        public char Kupac { get; set; }
        public char Dobavljac { get; set; }
    }

}
