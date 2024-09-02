using MovieCardApp.API.Data;

namespace MovieCardApp.API.Repositories.Actor
{
    public class ActorRepository : IActorRepository
    {
        private readonly MovieCardAppContext _appContext;

        public ActorRepository(MovieCardAppContext appContext)
        {
            _appContext = appContext;
        }
    }
}
