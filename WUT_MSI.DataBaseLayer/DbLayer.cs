﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUT_MSI.DataBaseLayer.Tables;

namespace WUT_MSI.DataBaseLayer
{
    internal class DbLayer: DbContext
    {
        public DbSet<DbCountry> Countries { get; set; }
        public DbSet<DbAttribute> Attributes { get; set; }
        public DbSet<DbAttributeValue> AttributeValues { get; set; }
        public DbSet<DbCountryAttributes> CountryAttributes { get; set; }
    }
}