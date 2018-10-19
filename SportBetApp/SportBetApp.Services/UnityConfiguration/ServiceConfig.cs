using SportBetApp.Repository;
using SportBetApp.Repository.Contracts;
using Unity;
using Unity.Extension;

namespace SportBetApp.Services.UnityConfiguration
{
    public class ServiceConfig : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IEventRepository, EventRepository>();
        }
    }
}
