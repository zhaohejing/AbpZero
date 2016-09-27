using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Timing.Dto;

namespace MyCompanyName.AbpZeroTemplate.Timing
{
    public interface ITimingAppService : IApplicationService
    {
        Task<ListResultOutput<NameValueDto>> GetTimezones(GetTimezonesInput input);

        Task<List<ComboboxItemDto>> GetTimezoneComboboxItems(GetTimezoneComboboxItemsInput input);
    }
}
