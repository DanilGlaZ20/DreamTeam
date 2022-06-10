using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DreamTeam.Data.Models
{
    public class Coach
    {
        public Coach() { WorkTeams= new HashSet<Team>(); }
        
        [Key] public int ID { get; set; }

        public string Name { get; set; } //Имя
        public string Style { get; set; } //стиль игры
        public int Experience { get; set; } //стаж в годах
        public ICollection<Team>? WorkTeams { get; set; }

        
    }
}