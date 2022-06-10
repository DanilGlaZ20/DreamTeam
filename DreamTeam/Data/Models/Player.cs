using System.ComponentModel.DataAnnotations;
namespace DreamTeam.Data.Models
{
    public class Player
    {
        [Key] 
        public int ID { get; set; }
        public string Name { get; set; }//имя игрока
        public string Number { get; set; }//номер игрока
        public string Height { get; set; }//рост игрока
        public virtual Team? Team { get; set; }//клуб игрока
    }
}