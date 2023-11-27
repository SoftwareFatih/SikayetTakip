using SikayetTakip.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SikayetTakip.Data
{
    public class SikayetContext : DbContext
    {
        public SikayetContext():base("default-database")
        {
            
        }

        public virtual DbSet<Musteri> Musteriler { get; set; }
        public virtual DbSet<Sikayet> Sikayetler { get; set; }
    }
}