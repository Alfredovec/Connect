using Autofac;
using Connect.Domain.Abstract;
using Connect.Domain.Services;
using Connect.Services;

namespace Connect.Infrastructure.DI
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<LessonService>().As<ILessonService>();
            builder.RegisterType<RateService>().As<IRateService>();
            builder.RegisterType<TopicService>().As<ITopicService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<LanguageService>().As<ILanguageService>();

            builder
                .RegisterGeneric(typeof(CrudService<,>))
                .As(typeof(ICrudService<>))
                .InstancePerDependency();
        }
    }
}
