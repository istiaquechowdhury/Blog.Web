using Autofac;
using Blog.Application;
using Blog.Application.Services;
using Blog.Domain.RepositoryContracts;
using Blog.Infrastructure;
using Blog.Infrastructure.Repositories;
using Blog.Infrastructure.UnitOfWorks;
using Blog.Web.Data;
using Blog.Web.Models;


namespace Blog.Web
{
    public class WebModule(string connectionstring,string migrationnassembly) : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<BlogDbContext>().AsSelf()
               .WithParameter("connectionString", connectionstring)
               .WithParameter("migrationAssembly", migrationnassembly)
               .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", connectionstring)
                .WithParameter("migrationAssembly", migrationnassembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogPostRepository>()
                .As<IBlogPostRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogUnitOfWork>()
                .As<IBlogUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogPostManagement>()
                .As<IBlogPostManagement>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>()
               .As<ICategoryRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<CategoryManagement>()
              .As<ICategoryMangement>()
              .InstancePerLifetimeScope();

        }

    }
}
