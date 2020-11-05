using AutoMapper;
using BoardManager_Service.Boards;
using BoardManager_Service.Caching;
using BoardManager_Service.Token;
using BoardManager_Service.Users;
using BoardManager_Service.WorkContext;
using BoardManager_Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace BoardManager_Core
{
    public static class DependencyLoader
    {

        public static void LoadDependencies(this IServiceCollection serviceCollection)
        {
            try
            {
                serviceCollection.AddSingleton<ICacheService, MemoryCacheService>();
                serviceCollection.AddSingleton<ICacheKeyService, CacheKeyService>();
                serviceCollection.AddSingleton<Microsoft.Extensions.Caching.Memory.IMemoryCache, Microsoft.Extensions.Caching.Memory.MemoryCache>();
               

                switch (Assembly.GetEntryAssembly()?.GetName().Name)
                {
                  
                    case "BoardManager_BackEnd":
                        serviceCollection.AddSingleton<IUserService, UserService>();
                        serviceCollection.AddSingleton<IBoardService, BoardService>();
                        serviceCollection.AddSingleton<ITokenService, TokenService>();
                        serviceCollection.AddSingleton<IWorkContext, ApiWorkContext>();
                        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                        var mappingConfig = new MapperConfiguration(mc =>
                        {
                            mc.AddProfile(new AutoMapperProfile());
                        });
                        IMapper mapper = mappingConfig.CreateMapper();
                        serviceCollection.AddSingleton(mapper);

                        break;
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }
    }
}
