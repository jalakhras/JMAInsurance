using System.Collections.Generic;

namespace JMAInsurance.Entity
{
    public class PaginationDTO<T>
    {
        public IList<T> ResultSet { get; set; }

        public int TotalRecords { get; set; }
    }
}