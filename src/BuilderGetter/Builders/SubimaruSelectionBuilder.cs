using BuilderGetter.Model;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuilderGetter
{
    public class SubimaruSelectionBuilder
    {
        DbSelectionContext _db;
        private readonly int[] _selectionIds;
        private IQueryable<SubimaruIntermediateQuery> _selectionBaseSubimaruQuery;

        internal SubimaruSelectionBuilder(
            DbSelectionContext db,
            int[] selectionIds,
            IQueryable<Selection> selectionBaseQuery = null)
        {
            _db = db;
            _selectionIds = selectionIds;
            selectionBaseQuery = selectionBaseQuery ?? _db.Selections.Where(x => selectionIds.Contains(x.Id)).AsNoTracking();
            _selectionBaseSubimaruQuery = selectionBaseQuery.Join(_db.SubimaruSelections.Where(x => !x.IsUx),
                                                                  selection => selection.Id,
                                                                  subimaruSelection => subimaruSelection.Id,
                                                                  (q, e) => new SubimaruIntermediateQuery(e, q));
        }

        public async Task<IEnumerable<Subimaru>> GetSubimaruSelectionAsync(CancellationToken token = default)
        {
            var result = await _selectionBaseSubimaruQuery.Select(x => new Subimaru(x.Base.Id, x.Base.Name))
                                                          .ToArrayAsync(token);
            return result;
        }
    }
}
