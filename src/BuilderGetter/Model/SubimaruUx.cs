using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuilderGetter.Shared;

namespace BuilderGetter.Model
{
    public class SubimaruUx
    {
        public readonly int Id;
        public readonly string Name;

        public SubimaruUx(int id, string name)
        {
            if (string.IsNullOrEmpty(name) || !name.StartsWith(BuilderConstants.SubimaruUxNameStart))
                throw new ArgumentException($"Subimaru selection name for UX type must have value starting with \"{BuilderConstants.SubimaruUxNameStart}\"");

            Id = id;
            var skipCount = BuilderConstants.SubimaruUxNameStart.Length;
            Name = name[skipCount..];
        }
    }
}
