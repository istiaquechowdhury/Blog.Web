using Autofac;
using Blog.Application.Services;
using Blog.Web.Models;


namespace Blog.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<MemberShip>().As<IMembership>().InstancePerLifetimeScope();
           // builder.RegisterType<HtmlEmailSender>().As<IEmailSender>().InstancePerLifetimeScope();
            builder.RegisterType<BlogPostManagement>().As<IBlogPostManagement>().InstancePerLifetimeScope();
           

        }

    }
}
