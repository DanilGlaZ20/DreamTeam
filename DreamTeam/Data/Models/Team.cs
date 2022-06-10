using System.ComponentModel.DataAnnotations;
namespace DreamTeam.Data.Models
{
    public class Team
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }//название
        public int Budget { get; set; }//бюджет
        public string Liga { get; set; }//лига
        
        public virtual Coach? WorkTeam { get; set; }
        public virtual Player? Player { get; set; }
        
    }
}