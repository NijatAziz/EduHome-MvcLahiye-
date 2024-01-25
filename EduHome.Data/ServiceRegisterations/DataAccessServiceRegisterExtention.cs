using EduHome.Core.Entities;
using EduHome.Core.Repositories;
using EduHome.Data.DAl;
using EduHome.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
namespace EduHome.Data.ServiceRegisterations
{
    public static class DataAccessServiceRegisterExtention
    {
        public static void DataAccessServiceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EduHomeDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"),
                                 b => b.MigrationsAssembly("EduHome.Data"));
            });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IHobbyRepository, HobbyRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

        }
    }
}
