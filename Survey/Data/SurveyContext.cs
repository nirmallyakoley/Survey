using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Survey.Models;

namespace Survey.Data
{
    public class SurveyContext : DbContext
    {
        public SurveyContext (DbContextOptions<SurveyContext> options)
            : base(options)
        {
        }

        public DbSet<Survey.Models.SurveyBO> SurveyBO { get; set; }
    }
}
