using DreamTeam.Data.Models;
using GraphQL.Types;

namespace DreamTeam.GraphQL.GraphTypes
{
    public class CoachGraphType : ObjectGraphType<Coach>
    {
        public CoachGraphType()
        {
            Name = "Coach";
            Field(p => p.ID, true).Description("ID coach");
            Field(p => p.Name, false);
            Field(p => p.Style, false);
            Field(p => p.Experience, false);

        }
    }
}