using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsitmeSozluk.Models
{
    public class SozlukContext:DbContext
    {
        public SozlukContext(DbContextOptions<SozlukContext> options)
            : base(options)
        {

        }

        public DbSet<Sozluk> Sozluks { get; set; }
    }
}
