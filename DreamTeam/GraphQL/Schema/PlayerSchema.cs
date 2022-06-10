using DreamTeam.GraphQL.Mutation;
using DreamTeam.GraphQL.Queries;
using DreamTeam.GraphQL.Services;

namespace DreamTeam.GraphQL.Schema
{
    public class PlayerSchema: global::GraphQL.Types.Schema
    {
        public PlayerSchema(IPlayerService service)
        {
            Query = new PlayerQuery(service);
            Mutation = new PlayerMutation(service);
        }
    }
}