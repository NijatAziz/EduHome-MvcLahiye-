using System;
using EduHome.Core.DTOS.Setting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Interfaces
{
    public interface ISettingService
    {
        public Task<IEnumerable<SettingGetDto>> GetAllAsync();
        public Task CreateAsync(SettingPostDto dto);
        public Task UpdateAsync(int id, SettingPostDto dto);
        public Task<SettingGetDto> GetAsync(int id);

        public Task RemovaAsync(int id);
    }
}