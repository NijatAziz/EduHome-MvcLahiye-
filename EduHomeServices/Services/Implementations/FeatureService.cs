using EduHome.Core.DTOS.Feature;
using EduHome.Core.DTOS.Hobby;
using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.Repositories;
using EduHomeServices.Exceptions;
using EduHomeServices.Services.Interfaces;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public void AddAsync(Feature feature)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(FeaturePostDto dto)
        {
            Feature feature = new()
            {
                Starts = dto.Starts,
                Duration = dto.Duration,
                ClassDuration = dto.ClassDuration,
                Level = dto.Level,
                Language = dto.Language,
                Students = dto.Students,
                Assesments = dto.Assesments,
                CourseFee = dto.CourseFee,
                CreatedAt = DateTime.Now
            };
            await _featureRepository.AddAsync(feature);
            await _featureRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<FeatureGetDto>> GetAllAsync()
        {
            IEnumerable<FeatureGetDto> features = await _featureRepository.GetQuery(x => !x.IsDeleted)
                .Select(x => new FeatureGetDto
                {
                    Starts = x.Starts,
                    Id = x.ID,
                    Duration = x.Duration,
                    ClassDuration = x.ClassDuration
                ,
                    Level = x.Level,
                    Language = x.Language,
                    Students = x.Students,
                    Assesments = x.Assesments,
                    CourseFee = x.CourseFee
                }).ToListAsync();
            return features;
        }

        public async Task<FeatureGetDto> GetAsync(int id)
        {
            Feature? feature = await _featureRepository.GetAsync(x => !x.IsDeleted && x.ID == id);


            if (feature == null)
            {
                throw new ItemNotFoundExcpetion("Feature is not Found");
            }

            FeatureGetDto featureGetDto = new()
            {
                Id = feature.ID,
                Starts = feature.Starts,
                Duration = feature.Duration,
                ClassDuration = feature.ClassDuration,
                Level = feature.Level,
                Language = feature.Language,
                Students = feature.Students,
                Assesments = feature.Assesments,
                CourseFee = feature.CourseFee
            };
            return featureGetDto;
        }

        public async Task RemovaAsync(int id)
        {
            Feature feature = await _featureRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (feature == null)
            {
                throw new ItemNotFoundExcpetion("Feature is not Found");
            }
            feature.IsDeleted = true;
            await _featureRepository.UpdateAsync(feature);
            await _featureRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, FeaturePostDto dto)
        {
            Feature feature = await _featureRepository.GetAsync(x => !x.IsDeleted && x.ID == id);
            if (feature == null)
            {
                throw new ItemNotFoundExcpetion("Feature is not Found");
            }
            feature.Starts = dto.Starts;
            feature.Duration = dto.Duration;
            feature.ClassDuration = dto.ClassDuration;
            feature.Level = dto.Level;
            feature.Language = dto.Language;
            feature.Students = dto.Students;
            feature.Assesments = dto.Assesments;
            feature.CourseFee = dto.CourseFee;
            feature.UpdatedDate = DateTime.Now;
            await _featureRepository.UpdateAsync(feature);
            await _featureRepository.SaveChangesAsync();
        }
    }
}