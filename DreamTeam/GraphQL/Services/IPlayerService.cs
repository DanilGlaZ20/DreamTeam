using System.Linq;
using DreamTeam.Data.Models;
namespace DreamTeam.GraphQL.Services
{
    public interface IPlayerService
    {
        
        IQueryable<Player> GetAllPlayers();//всех игроков
        IQueryable<Team> GetAllTeams();//все команды
        
        Player GetPlayerById(int id);//игрока по id
        Coach GetCoachById(int id);//тренера по id

        Player UpdatePlayer(Player player, int id);//изменить игрока

        Player AddPlayer(Player player);//добавить игрока

        Player DeletePlayer(int id);//удалить игрока по id
        

        Coach AddCoach(Coach coach);//добавить тренера
    }
}