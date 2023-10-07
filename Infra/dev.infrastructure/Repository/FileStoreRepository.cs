using dev.Application.Common.Interfaces.IRepos;
using dev.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev.Infrastructure.Repository
{
    public class FileStoreRepository<T> : IFileStorageRepository<T> where T : class
    {
        private readonly ApplicationJsonDataContext<T> _jsonDataContext;

        public FileStoreRepository(ApplicationJsonDataContext<T> jsonDataContext)
        {
            _jsonDataContext = jsonDataContext;
        }

        public async Task<List<T>> GetAll()
        {
            var data = await _jsonDataContext.GetAll();
            return data;
        }

        public async Task Add(T entity)
        {
            await _jsonDataContext.Add(entity);
        }
    }
}
