using BuilderGetter.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Models
{
    public class ToyakaSpecialSelection
    {
        [Key]
        public int Id { get; set;}
        public int SelectionId { get; set; }
        public ToykaSpecialFlag Flag { get; set; }
    }
}
