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
    public class ToyakaSelectionBuilder
    {
        DbSelectionContext _db;
        private readonly int[] _selectionIds;
        private IQueryable<ToyakaIntermediateQuery> _selectionBaseToyakaQuery;

        internal ToyakaSelectionBuilder(DbSelectionContext db,
                                      int[] selectionIds,
                                      IQueryable<Selection> selectionBaseQuery = null)
        {
            _db = db;
            _selectionIds = selectionIds;

            // обновим наш запрос для toyka
            selectionBaseQuery = selectionBaseQuery ?? _db.Selections.Where(x => selectionIds.Contains(x.Id)).AsNoTracking();
            _selectionBaseToyakaQuery = selectionBaseQuery.Where(x => x.Survey.Type == Shared.SurveyType.Toyaka)
                                                          .Join(_db.ToykaSelections, 
                                                                selection => selection.Id, 
                                                                toykaSelection => toykaSelection.SelectionId, 
                                                                (q, e) => new ToyakaIntermediateQuery(e, q));
        }

        public ToyakaSelectionBuilder BaseOnly()
        {
            _selectionBaseToyakaQuery = _selectionBaseToyakaQuery.Where(x => x.Toyaka.IsBase);
            return this;
        }

        public ToyakaSelectionBuilder TakeParentSelections()
        {
            // необходимо иметь query для базового подбора + query для фильтров
            // тогда мы можем менять критерий подбора базовых выборок

            //либо сразу как-то указывать условия по которым нужно получить базовый набор выборок

            return this;
        }

        public async Task<IEnumerable<Toyaka>> GetToyakaSelectionAsync(CancellationToken token = default)
        {
            var result = await _selectionBaseToyakaQuery.Select(x => new Toyaka(x.Toyaka.Id, x.Toyaka.IsBase, x.Base.Name, x.Base.IsActive))
                                                        .ToArrayAsync(token);
            return result;
        }
    }
}
