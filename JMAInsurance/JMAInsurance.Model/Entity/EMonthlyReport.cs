using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JMAInsurance.Entity
{
    [Table("EMonthlyReports", Schema = "Insurance")]

    public class EMonthlyReport
    {

        public int Id { get; set; }
        public double NumberRead { get; set; }
        public double ClickThruRate { get; set; }
        public double NumberSent { get; set; }
        public double AverageQuote { get; set; }
        public double ProjectedConversationRate { get; set; }
    }
}
