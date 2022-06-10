using System.Linq;
using DreamTeam.Data.Models;
namespace DreamTeam.GraphQL.Services
{
    public interface IPlayerService
    {
        
        IQueryable<Player> GetAllPlayers();
        
        Player GetPlayerById(int id);

        Player UpdatePlayer(Player player, int id);

        Player AddPlayer(Player player);

        Player DeletePlayer(int id);

        Coach CheckCoach(string name);

        Team AddTeam(Team team);
    }
}