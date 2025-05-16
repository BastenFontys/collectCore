using collectCoreBLL.Services;
using collectCoreDAL.Interfaces;
using collectCoreDAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL
{
    public static class DepencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICollectionRepo, CollectionRepo>();
            services.AddScoped<CollectionService>();

            services.AddScoped<IItemRepo, ItemRepo>();
            services.AddScoped<ItemService>();
        }
    }
}
