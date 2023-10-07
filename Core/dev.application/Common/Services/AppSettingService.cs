using dev.Application.Common.Interfaces.IRepos;
using dev.Application.Common.Interfaces.IServices;
using dev.Domain.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev.Application.Common.Services
{
    public class AppSettingService : IAppSettingService
    {
        private readonly IRepository<AppSetting> _appSettingRepository;
        private readonly IFileStorageRepository<AppSetting> _fileStorageRepository;

        public AppSettingService(IRepository<AppSetting> appSettingRepository, IFileStorageRepository<AppSetting> fileStorageRepository)
        {
            _appSettingRepository = appSettingRepository;
            _fileStorageRepository = fileStorageRepository;
        }

        public async Task<List<AppSetting>> GetAll()
        {
            var data = _appSettingRepository.GetAll();
            return data.ToList();
        }

        public async Task<List<AppSetting>> GetAllFromJson()
        {
            var data = await _fileStorageRepository.GetAll();
            return data;
        }

        public async Task Add(AppSetting appSetting)
        {
            var data = await _fileStorageRepository.GetAll();
            appSetting.Id = data.Select(s => s.Id).Max(m => m) + 1;
            await _fileStorageRepository.Add(appSetting);
        }
    }
}
