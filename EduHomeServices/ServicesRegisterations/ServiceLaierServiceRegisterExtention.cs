
using EduHomeServices.ExternalServices.Implementations;
using EduHomeServices.ExternalServices.Interface;
using EduHomeServices.Services.Implementations;
using EduHomeServices.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EduHomeServices.ServiceRegisterations
{
    public static class ServiceLaierServiceRegisterExtention
    {
        public static void ServiceLayerServiceRegister(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddHttpContextAccessor();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IHobbyService, HobbyService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseCommentService, CourseCommentService>();
            services.AddScoped<IBlogCommentService, BlogCommentService>();
            services.AddScoped<IAuthorService, AuthorService>();


            services.AddScoped<LayoutService>();









        }
    }
}

