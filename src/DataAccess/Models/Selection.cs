﻿using BuilderGetter.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class Selection
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsTest { get; set; }
    }
}
