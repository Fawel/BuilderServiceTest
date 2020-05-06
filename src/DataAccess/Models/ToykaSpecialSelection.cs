using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Models
{
    public class ToykaSpecialSelection
    {
        [Key]
        public int Id { get; set;}
        public int SelectionId { get; set; }
        public ToykaSpecialFlag Flag { get; set; }
    }

    public enum ToykaSpecialFlag
    {
        Torrento,
        Porkedo,
        Leopard
    }
}
