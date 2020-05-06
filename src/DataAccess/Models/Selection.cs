using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Selection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public SelectionType Type { get; set; }
        public bool IsTest { get; set; }
    }

    public enum SelectionType
    {
        Toyka,
        Subimaru
    }
}
