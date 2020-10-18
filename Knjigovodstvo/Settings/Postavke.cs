﻿using Knjigovodstvo.Helpers;
using Knjigovodstvo.Models;
using System;
using System.Data;

namespace Knjigovodstvo.Settings
{
    class Postavke : IDbObject
    {
        public FormError ValidateData()
        {
            if (Vrijednost.ToString() == "")
            {
                return FormError.Prazno;
            }

            return FormError.None;
        }

        internal Postavke GetPostavkaById(int id)
        {
            string condition = $"Id={id};";
            DataTable postavka = new DbDataGet().GetTable(new Postavke(), condition);
            return new Postavke {
                Id = int.Parse(postavka.Rows[0][0].ToString()),
                Naziv = postavka.Rows[0][1].ToString(),
                Vrsta = postavka.Rows[0][2].ToString(),
                Vrijednost = float.Parse(postavka.Rows[0][3].ToString())
            };
        }

        internal bool UpdateData(int id)
        {
            Id = id;
            if (new DbDataUpdate().UpdateData(this))
                return true;

            return false;
        }

        public int Id { get; set; } = 0;
        public string Naziv { get; set; } = "";
        public string Vrsta { get; set; } = "";
        public float Vrijednost { get; set; } = 0;
    }    
}
