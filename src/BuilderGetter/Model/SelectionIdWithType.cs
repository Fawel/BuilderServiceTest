using BuilderGetter.Shared;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderGetter.Model
{
    public readonly struct SelectionIdWithType
    {
        public readonly int SelectionId;
        public readonly SurveyType Type;

        public SelectionIdWithType(int selectionId, SurveyType type)
        {
            SelectionId = selectionId;
            Type = type;
        }
    }
}
