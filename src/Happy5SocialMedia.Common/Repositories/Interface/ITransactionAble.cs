using System;
using System.Collections.Generic;
using System.Text;

namespace Happy5SocialMedia.Common.Repositories.Interface
{
    public interface ITransactionAble
    {        
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void DisposeTransaction();
    }
}
