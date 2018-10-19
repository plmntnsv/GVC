using SportBetApp.Data;
using SportBetApp.Data.Contracts;
using Unity;
using Unity.Extension;

namespace SportBetApp.Repository.UnityConfiguration
{
    public class RepositoryConfig : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ISportBetAppDbContext, SportBetAppDbContext>();
        }
    }
}
