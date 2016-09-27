using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Authorization.Permissions.Dto;

namespace MyCompanyName.AbpZeroTemplate.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultOutput<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
