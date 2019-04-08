using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity
{
    [Table("Progress", Schema = "Insurance")]
    public class Progress
    {
        public int CurrentStage { get; set; }
        public int HighestStage { get; set; }
    }
}