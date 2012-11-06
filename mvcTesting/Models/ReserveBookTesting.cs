using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvcTesting.Models
{
    public class ReserveBookTesting:DbContext
    {
        DbSet<InfoBook> InfoBook { get; set; }
    }
}