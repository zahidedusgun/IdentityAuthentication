using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

//namespace Identity.Persistence.Context
//{
//    public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityFrameworkContext>
//    {
//        //public IdentityFrameworkContext CreateDbContext(string[] args)
//        //{
//        //    IConfigurationRoot configuration = new ConfigurationBuilder()
//        //        .SetBasePath(Directory.GetCurrentDirectory())
//        //        .AddJsonFile("appsettings.json")
//        //        .Build();

//        //    var optionsBuilder = new DbContextOptionsBuilder<IdentityFrameworkContext>();

//        //    var connectionString = configuration.GetSection("IdentityDB").Value;

//        //    optionsBuilder.UseNpgsql(connectionString);

//        //    return new IdentityFrameworkContext(optionsBuilder.Options);
//        }
//    }
//}
