using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SortNumbers.Models;

namespace SortNumbers.Data
{
    public class SortNumbersContext : DbContext
    {
        //public SortNumbersContext()
        //{
        //}

        public SortNumbersContext (DbContextOptions<SortNumbersContext> options)
            : base(options)
        {
        }

        public DbSet<SortNumbers.Models.SortInput> SortInput { get; set; }
    }
}
