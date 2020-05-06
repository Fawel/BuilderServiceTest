using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class DbSelectionContext : DbContext
    {
        public DbSet<Selection> Selections;
        public DbSet<ToykaSelection> ToykaSelections;
        public DbSet<ToykaSpecialSelection> ToykaSpecialSelections;
        public DbSet<SubimaruSelection> SubimaruSelections;
        public DbSet<Participation> Participations;
    }
}
