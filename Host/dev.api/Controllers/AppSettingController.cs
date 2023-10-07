using dev.Application.Common.Interfaces.IServices;
using dev.Domain.Master;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSettingController : ControllerBase
    {
        private readonly IAppSettingService _appSettingService;

        public AppSettingController(IAppSettingService appSettingService)
        {
            _appSettingService = appSettingService;
        }

        [HttpGet(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var data = await _appSettingService.GetAllFromJson();
            return Ok(data);
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add(AppSetting appSetting)
        {
            await _appSettingService.Add(appSetting);
            return Ok();
        }
    }
}
