   using Microsoft.EntityFrameworkCore;
   using Microsoft.EntityFrameworkCore.Design;

   namespace SenaiSound.Banco
   {
       public class SenaiSoundContextFactory : IDesignTimeDbContextFactory<SenaiSoundContext>
       {
           public SenaiSoundContext CreateDbContext(string[] args)
           {
               var optionsBuilder = new DbContextOptionsBuilder<SenaiSoundContext>();
               optionsBuilder.UseMySql(
                   "Server=localhost;Database=senaisound_db;User=root;Password=123;",
                   new MySqlServerVersion(new Version(8, 0, 25))
               );

               return new SenaiSoundContext(optionsBuilder.Options);
           }
       }
   }
   