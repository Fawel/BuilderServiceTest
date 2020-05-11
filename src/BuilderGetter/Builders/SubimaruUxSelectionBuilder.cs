using BuilderGetter.Model;
using BuilderGetter.Shared;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuilderGetter
{
    public class SubimaruUxSelectionBuilder
    {
        DbSelectionContext _db;
        private readonly int[] _selectionIds;
        private IQueryable<SubimaruIntermediateQuery> _selectionBaseSubimaruQuery;

        internal SubimaruUxSelectionBuilder(
            DbSelectionContext db,
            int[] selectionIds,
            IQueryable<Selection> selectionBaseQuery = null)
        {
            _db = db;
            _selectionIds = selectionIds;
            selectionBaseQuery = selectionBaseQuery ?? _db.Selections.Where(x => selectionIds.Contains(x.Id)).AsNoTracking();
            _selectionBaseSubimaruQuery = selectionBaseQuery.Where(x => x.Name.StartsWith(BuilderConstants.SubimaruUxNameStart))
                                                            .Join(_db.SubimaruSelections.Where(x => x.IsUx),
                                                                  selection => selection.Id,
                                                                  subimaruSelection => subimaruSelection.Id,
                                                                  (q, e) => new SubimaruIntermediateQuery(e, q));
        }

        public async Task<IEnumerable<SubimaruUx>> GetSubimaruUxAsync(CancellationToken token = default)
        {
            var subimaruUxSelections = await _selectionBaseSubimaruQuery.Select(x => new SubimaruUx(x.Base.Id, x.Base.Name)).ToArrayAsync(token);
            return subimaruUxSelections;
        }
    }
}
