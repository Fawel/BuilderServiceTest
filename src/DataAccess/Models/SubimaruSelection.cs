using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Models
{
    public class SubimaruSelection
    {
        [Key]
        public int Id { get; set; }
        public bool IsUx { get; set; }
    }
}
