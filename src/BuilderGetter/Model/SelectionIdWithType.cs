using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderGetter.Model
{
    public readonly struct SelectionIdWithType
    {
        public readonly int SelectionId;
        public readonly SelectionType Type;

        public SelectionIdWithType(int selectionId, SelectionType type)
        {
            SelectionId = selectionId;
            Type = type;
        }
    }
}
