using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataLayer
{
    public class DataLayerConfiguration
    {
        public static void Configuration(IServiceCollection services,IConfigurationRoot configuration)
        {
            services.AddDbContext<DatabaseContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("MyConnection")));

            services.AddScoped<DatabaseContext>();

            // Dapper Configuration
            services.AddScoped<IDbConnection>
                (_ => new SqlConnection(configuration.GetConnectionString("MyConnection")));
        }
    }
}
