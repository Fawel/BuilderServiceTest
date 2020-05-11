using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderGetter.Model
{
    public class Subimaru
    {
        public readonly int Id;
        public readonly string Name;

        public Subimaru(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class SubimaruIntermediateQuery
    {
        public readonly SubimaruSelection Subimaru;
        public readonly Selection Base;

        public SubimaruIntermediateQuery(SubimaruSelection toyaka, Selection @base)
        {
            Subimaru = toyaka;
            Base = @base;
        }
    }
}
