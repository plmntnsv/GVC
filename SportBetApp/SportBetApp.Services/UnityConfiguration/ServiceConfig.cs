using SportBetApp.Repository;
using SportBetApp.Repository.Contracts;
using SportBetApp.Repository.UnityConfiguration;
using Unity;
using Unity.Extension;

namespace SportBetApp.Services.UnityConfiguration
{
    public class ServiceConfig : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<RepositoryConfig>();
            Container.RegisterType<IEventRepository, EventRepository>();
        }
    }
}
