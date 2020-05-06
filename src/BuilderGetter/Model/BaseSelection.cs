using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderGetter.Model
{
    public class BaseSelection
    {
        public readonly int Id;
        public readonly bool IsActive;
        public readonly string Name;

        public BaseSelection(int id, bool isActive, string name)
        {
            Id = id;
            IsActive = isActive;
            Name = name;
        }
    }
}
