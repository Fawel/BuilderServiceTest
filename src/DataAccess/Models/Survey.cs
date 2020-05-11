using BuilderGetter.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public SurveyType Type { get; set; }
    }
}
