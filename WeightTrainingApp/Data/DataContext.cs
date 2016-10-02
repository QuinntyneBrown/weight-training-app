using System.Data.Entity;
using WeightTrainingApp.Models;

namespace WeightTrainingApp.Data
{
    public class DataContext: DbContext, IDbContext
    {
        public DataContext()
            : base(nameOrConnectionString: "WeightTrainingAppDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<ScheduledExercise> ScheduledExercises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        } 
    }
}
