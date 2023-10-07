using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev.Application.Common.Interfaces.IRepos
{
    public interface IFileStorageRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task Add(T entity);
    }
}
