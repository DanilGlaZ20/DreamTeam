using System.Collections.Generic;
using System.Linq;
using DreamTeam.Data.Models;
using DreamTeam.GraphQL.GraphTypes;
using DreamTeam.GraphQL.Services;
using GraphQL;
using GraphQL.Types;
namespace DreamTeam.GraphQL.Queries
{
    public class PlayerQuery : ObjectGraphType
    {
        private readonly IPlayerService _service;

        public PlayerQuery(IPlayerService service)
        {
            _service = service;

            Field<ListGraphType<PlayerGraphType>>("players", "Take all players",
                resolve: GetAllPlayers);
            Field<PlayerGraphType>("player", "for take player",
                new QueryArguments(MakeNonNullStringArgument("id", "ID player")),
                resolve: GetPlayer);

            // with pagination
            Field<ListGraphType<PlayerGraphType>>("playersPag", "Take all players",
               new QueryArguments(MakeNonNullStringArgument("index", "Number of begining page"),
                   MakeNonNullStringArgument("count", "How much elements to display")),
               resolve: GetAllPlayersPag);
            
           Field<ListGraphType<TeamGraphType>>("teams", "Take all passengers",
                resolve: GetAllTeams);

           Field<CoachGraphType>("coach", "for take player",
               new QueryArguments(MakeNonNullStringArgument("id", "ID coach")),
               resolve: GetCoach);
        }
        

        private IEnumerable<Player> GetAllPlayersPag(IResolveFieldContext<object?> arg)
        {
            var index = int.Parse(arg.GetArgument<string>("index"));
            var count = int.Parse(arg.GetArgument<string>("count"));
            var items = _service.GetAllPlayers().Skip(index).Take(count).ToList();
            return items;
        }

        private QueryArgument MakeNonNullStringArgument(string name, string description)
        {
            return new QueryArgument<NonNullGraphType<StringGraphType>> {Name = name, Description = description};
        }

        private IEnumerable<Player> GetAllPlayers(IResolveFieldContext<object?> arg)
        {
            return _service.GetAllPlayers();
        }
        
        private IEnumerable<Team> GetAllTeams(IResolveFieldContext<object?> arg)
        {
            return _service.GetAllTeams();
        }

        private Coach GetCoach(IResolveFieldContext<object?> arg)
        {
            return _service.GetCoachById(int.Parse(arg.GetArgument<string>("id")));
        }

        private Player GetPlayer(IResolveFieldContext<object?> arg)
        {
            return _service.GetPlayerById(int.Parse(arg.GetArgument<string>("id")));
        }
    }
}