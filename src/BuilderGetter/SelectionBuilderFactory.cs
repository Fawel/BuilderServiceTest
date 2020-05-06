using BuilderGetter.Model;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace BuilderGetter
{
    public class SelectionBuilderFactory
    {
        DbSelectionContext _db;

        public SelectionBuilder GetBuilder(params int[] selectionId)
        {
            return new SelectionBuilder(_db, selectionId);
        }
    }

    public class SelectionBuilder
    {
        DbSelectionContext _db;
        private readonly int[] _selectionIds;
        private SelectionIdWithType[] _selectionTypes;
        private IQueryable<Selection> _selectionBaseQuery;

        public SelectionBuilder(DbSelectionContext db, int[] selectionIds)
        {
            _db = db;
            _selectionIds = selectionIds;
            _selectionBaseQuery = _db.Selections.Where(x => selectionIds.Contains(x.Id));
        }

        public async Task<BaseSelection[]> GetBaseSelection(CancellationToken token = default)
        {
            var dbSelection = await _selectionBaseQuery.ToArrayAsync(token);
            var result = dbSelection.Select(x => new BaseSelection(x.Id, x.IsActive, x.Name)).ToArray();
            return result;
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
                var typeOfSelections = await _selectionBaseQuery.Select(x => new SelectionIdWithType(x.Id, x.Type)).ToArrayAsync(token);
                _selectionTypes = typeOfSelections;
            }

            return _selectionTypes;
        }

        public Task<ToyakaSelectionBuilder> AsToyakaBuilder()
        {
            var toyakaBuilder = new ToyakaSelectionBuilder();
            return Task.FromResult(toyakaBuilder);
        }
    }

    public class ToyakaSelectionBuilder
    {
        DbSelectionContext _db;
        public int _selectionId;
    }
}
