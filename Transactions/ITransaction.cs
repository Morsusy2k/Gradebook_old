using System.Data;

namespace Gradebook.RepositoryLayer.Transactions
{
        public interface ITransaction
        {
            IDbConnection Connection { get; }
            IDbTransaction Transaction { get; }

            void Begin();
            void Commit();
            void Rollback();
        }   
}
