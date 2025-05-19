using collectCoreBLL.Mappers;
using collectCoreBLL.Services;
using collectCoreDAL.Interfaces;
using collectCoreDAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCore
{
    public static class DepencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<UserService>();

            services.AddScoped<ICollectionRepo, CollectionRepo>();
            services.AddScoped<CollectionService>();

            services.AddScoped<IItemRepo, ItemRepo>();
            services.AddScoped<ItemService>();

            services.AddScoped<UserMapper>();
            services.AddScoped<CollectionMapper>();
            services.AddScoped<ItemMapper>();
        }
    }
}
