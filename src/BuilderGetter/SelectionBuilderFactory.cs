using DataAccess;
using System.Security.Cryptography.X509Certificates;

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
}
