using Autofac;
using Connect.Data;
using Connect.Data.Repositories;

namespace Connect.Infrastructure.DI
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ConnectDbContext>()
                .AsSelf()
                .As<DbContext>()
                .WithParameter("connectionString", "ReceiptDb")
                .InstancePerLifetimeScope();

            builder.RegisterType<LessonRepository>().As<ILessonRepository>();
            builder.RegisterType<RateRepository>().As<IRateRepository>();
            builder.RegisterType<TopicRepository>().As<ITopicRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
