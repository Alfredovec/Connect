using AutoMapper;
using Connect.Api.Infrastructure.Automapper;
using Connect.Infrastructure.Automapper;

namespace Connect.Api
{
    public static class AutomapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperWebProfile>();
                cfg.AddProfile<AutomapperDomainProfile>();
            });

            return config;
        }
    }
}