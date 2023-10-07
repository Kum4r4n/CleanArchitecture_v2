using dev.Domain.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev.Application.Common.Interfaces.IServices
{
    public interface IAppSettingService
    {
        Task<List<AppSetting>> GetAll();
        Task<List<AppSetting>> GetAllFromJson();
        Task Add(AppSetting appSetting);
    }
}
