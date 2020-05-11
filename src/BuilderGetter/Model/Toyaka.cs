using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderGetter.Model
{
    public class Toyaka
    {
        public readonly int Id;
        public readonly bool IsBase;
        public readonly string Name;
        public readonly bool IsActive;

        public Toyaka(int id, bool isBase, string name, bool isActive)
        {
            Id = id;
            IsBase = isBase;
            Name = name;
            IsActive = isActive;
        }
    }

    public class ToyakaIntermediateQuery
    {
        public readonly ToyakaSelection Toyaka;
        public readonly Selection Base;

        public ToyakaIntermediateQuery(ToyakaSelection toyaka, Selection @base)
        {
            Toyaka = toyaka;
            Base = @base;
        }
    }
}
