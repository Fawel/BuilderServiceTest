using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class DbSelectionContext : DbContext
    {
        public DbSet<Survey> Surveys;
        public DbSet<Selection> Selections;
        public DbSet<ToyakaSelection> ToykaSelections;
        public DbSet<ToyakaSpecialSelection> ToykaSpecialSelections;
        public DbSet<SubimaruSelection> SubimaruSelections;
        public DbSet<Participation> Participations;
    }
}
