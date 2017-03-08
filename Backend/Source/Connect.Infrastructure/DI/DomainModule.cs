using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
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
        }
    }
}
