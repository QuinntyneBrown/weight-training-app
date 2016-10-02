using WeightTrainingApp.Configuration;
using WeightTrainingApp.Data;
using WeightTrainingApp.Services;
using WeightTrainingApp.Utilities;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace WeightTrainingApp
{
    public class UnityConfiguration
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IDbContext, DataContext>();
            container.RegisterType<IUow, Uow>();
            container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            container.RegisterType<IIdentityService, IdentityService>();
            container.RegisterType<ILoggerFactory, LoggerFactory>();
            container.RegisterType<ICacheProvider, CacheProvider>();
            container.RegisterType<IEncryptionService, EncryptionService>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IExerciseService, ExerciseService>();
            container.RegisterType<IScheduleService, ScheduleService>();
            container.RegisterType<IScheduledExerciseService, ScheduledExerciseService>();

            container.RegisterInstance(AuthConfiguration.LazyConfig);            
            return container;
        }
    }
}
