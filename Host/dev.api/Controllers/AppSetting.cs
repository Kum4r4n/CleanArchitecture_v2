using dev.Application.Common.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSetting : ControllerBase
    {
        private readonly IAppSettingService _appSettingService;

        public AppSetting(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var data = await _appSettingService.GetAll();
            return Ok(data);
        }
    }
}
