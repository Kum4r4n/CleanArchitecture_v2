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

        public AppSettingService(IRepository<AppSetting> appSettingRepository)
        {
            _appSettingRepository = appSettingRepository;
        }

        public async Task<List<AppSetting>> GetAll()
        {
            var data = _appSettingRepository.GetAll();
            return data.ToList();
        }
    }
}
