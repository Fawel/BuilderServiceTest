using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Models
{
    public class ToykaSelection
    {
        [Key]
        public int Id { get; set; }
        public int SelectionId { get; set; }
        
        public bool IsBase { get; set; }
    }
}
