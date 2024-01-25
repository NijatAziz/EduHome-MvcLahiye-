using EduHome.Core.DTOS.Setting;
using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.Repositories;
using EduHomeServices.Exceptions;
using EduHomeServices.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Implementations
{
    internal class SettingService : ISettingService
    {

        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public async Task CreateAsync(SettingPostDto dto)
        {
            Setting setting = new()
            {
                key = dto.Key,
                value = dto.Value,
                CreatedAt = DateTime.Now
            };
            await _settingRepository.AddAsync(setting);
            await _settingRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<SettingGetDto>> GetAllAsync()
        {
            IEnumerable<SettingGetDto> features = await _settingRepository.GetQuery(x => !x.IsDeleted)
               .Select(x => new SettingGetDto { Key = x.key, Id = x.ID, Value = x.value }).ToListAsync();
            return features;
        }

        public async Task<SettingGetDto> GetAsync(int id)
        {
            Setting? setting = await _settingRepository.GetAsync(x => !x.IsDeleted && x.ID == id);


            if (setting == null)
            {
                throw new ItemNotFoundExcpetion("Setting is not Found");
            }

            SettingGetDto settingGetDto = new()
            {
                Key = setting.key,
                Id = setting.ID,
                Value = setting.value
            };
            return settingGetDto;
        }

        public async Task RemovaAsync(int id)
        {
            Setting setting = await _settingRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (setting == null)
            {
                throw new ItemNotFoundExcpetion("Setting is not Found");
            }
            setting.IsDeleted = true;
            await _settingRepository.UpdateAsync(setting);
            await _settingRepository.SaveChangesAsync();
        }



        public async Task UpdateAsync(int id, SettingPostDto dto)
        {
            Setting setting = await _settingRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (setting == null)
            {
                throw new ItemNotFoundExcpetion("Setting is not Found");
            }
            setting.key = dto.Key;
            setting.value = dto.Value;
            setting.UpdatedDate = DateTime.Now;
            await _settingRepository.UpdateAsync(setting);
            await _settingRepository.SaveChangesAsync();
        }
    }
}