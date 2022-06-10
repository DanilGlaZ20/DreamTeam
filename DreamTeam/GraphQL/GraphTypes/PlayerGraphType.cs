using DreamTeam.Data.Models;
using GraphQL.Types;
namespace DreamTeam.GraphQL.GraphTypes
{
    public class PlayerGraphType : ObjectGraphType<Player>
    {
        public PlayerGraphType()
        {
            Name = "Player";
            Field(p => p.ID, true).Description("ID player)");
            Field(p => p.Name, false);
            Field(p => p.Number, false);
            Field(p => p.Height, false);
            Field(p => p.Team, true, typeof(TeamGraphType)).Description("The player plays in this Club");
        }
    }
}