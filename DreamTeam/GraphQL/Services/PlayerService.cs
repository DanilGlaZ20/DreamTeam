using System.Linq;
using DreamTeam.Data;
using DreamTeam.Data.Models;
using DreamTeam.GraphQL.Services;
using Microsoft.EntityFrameworkCore;

public class PlayerService:IPlayerService
    {
         private readonly DreamTeamContext _context;
        
        
        
        public PlayerService(DreamTeamContext context)
        {
            _context = context;
        }
        public IQueryable<Player> GetAllPlayers()
        {
            return _context.Players
                .Select(p => p);
        }
        public IQueryable<Team> GetAllTeams()
        {
            return _context.Teams
                .Select(t => t);
        }
        

        public Player GetPlayerById(int id)
        {
            return _context.Players
                .Include(t => t.Team)
                .ThenInclude(t=> t.WorkTeam)
                .SingleOrDefault(p => p.ID==id)!;
        }

        public Coach GetCoachById(int id)
        {
            return _context.Coaches.SingleOrDefault(p => p.ID==id)!;
        }
        public Player UpdatePlayer(Player player, int id)
        {
            var updatingPlayer = _context.Players.SingleOrDefault(t=>t.ID==id);
            
            updatingPlayer.Name = player.Name;
            updatingPlayer.Number = player.Number;
            updatingPlayer.Height = player.Height;
            
            _context.Players.Update(updatingPlayer);
            _context.SaveChanges();

            return updatingPlayer;
        }

        public Player AddPlayer(Player player)
        { 
            var result = _context.Players.Add(player).Entity;
            _context.SaveChanges();
            return result;
        }

        public Player DeletePlayer(int id)
        {
            var deletePlayer = _context.Players.FirstOrDefault(p => p.ID == id);
          
            _context.Players.Remove(deletePlayer);
            
            _context.SaveChanges();

            return deletePlayer;
        }
        
        public Coach AddCoach(Coach coach)
        {
            var result = _context.Coaches.Add(coach).Entity;
            _context.SaveChanges();
            return result;
        }
    }
