using DreamTeam.Data.Models;
using GraphQL.Types;

namespace DreamTeam.GraphQL.GraphTypes
{
    public class TeamGraphType : ObjectGraphType<Team>
    {
        public TeamGraphType()
        {
            Name = "Team";
            Field(p => p.ID, true).Description("ID team");
            Field(p => p.Title, false);
            Field(p => p.Budget, false);
            Field(p => p.Liga, false);
            Field(p => p.WorkTeam, false, typeof(CoachGraphType)).Description("this coach");
            Field(p => p.Player, true, typeof(PlayerGraphType));
        }
    }
}