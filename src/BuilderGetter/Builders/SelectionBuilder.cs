using BuilderGetter.Model;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BuilderGetter
{
    public class SelectionBuilder
    {
        DbSelectionContext _db;
        private readonly int[] _selectionIds;
        private SelectionIdWithType[] _selectionTypes;
        private IQueryable<Selection> _selectionBaseQuery;

        internal SelectionBuilder(DbSelectionContext db, int[] selectionIds)
        {
            _db = db;
            _selectionIds = selectionIds;
            _selectionBaseQuery = _db.Selections.Where(x => selectionIds.Contains(x.Id)).AsNoTracking();
        }

        public async Task<BaseSelection[]> GetBaseSelection(CancellationToken token = default)
        {
            var dbSelection = await _selectionBaseQuery.Select(x => new BaseSelection(x.Id, x.IsActive, x.Name)).ToArrayAsync(token);
            return dbSelection;
        }

        public SelectionBuilder ActiveOnly()
        {
            _selectionBaseQuery = _selectionBaseQuery.Where(x => x.IsActive);
            return this;
        }

        public async ValueTask<SelectionIdWithType[]> GetSelectionType(CancellationToken token = default)
        {
            if (_selectionTypes is null)
            {
                var typeOfSelections = await _selectionBaseQuery.Select(x => new SelectionIdWithType(x.Id, x.Survey.Type)).ToArrayAsync(token);
                _selectionTypes = typeOfSelections;
            }

            return _selectionTypes;
        }

        public ToyakaSelectionBuilder AsToyakaBuilder()
        {
            var toyakaBuilder = new ToyakaSelectionBuilder(_db, _selectionIds, _selectionBaseQuery);
            return toyakaBuilder;
        }

        public SubimaruSelectionBuilder AsSubimaruBuilder()
        {
            var subimaruBuilder = new SubimaruSelectionBuilder(_db, _selectionIds, _selectionBaseQuery);
            return subimaruBuilder;
        }

        public SubimaruUxSelectionBuilder AsSubimaruUxBuilder()
        {
            var subimaruUxBuilder = new SubimaruUxSelectionBuilder(_db, _selectionIds, _selectionBaseQuery);
            return subimaruUxBuilder;
        }
    }
}
