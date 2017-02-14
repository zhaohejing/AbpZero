using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.MultiTenancy.Dto;

namespace MyCompanyName.AbpZeroTemplate.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        Task<PagedResultDto<TenantListDto>> GetTenants(GetTenantsInput input);

        Task CreateTenant(CreateTenantInput input);

        Task<TenantEditDto> GetTenantForEdit(NullableIdDto input);

        Task UpdateTenant(TenantEditDto input);

        Task DeleteTenant(NullableIdDto input);

        Task<GetTenantFeaturesForEditOutput> GetTenantFeaturesForEdit(NullableIdDto input);

        Task UpdateTenantFeatures(UpdateTenantFeaturesInput input);

        Task ResetTenantSpecificFeatures(NullableIdDto input);
    }
}
