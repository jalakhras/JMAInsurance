namespace JMAInsurance.Models.ViewModel
{
    public class Employments
    {
        public Employments()
        {
            PrimaryEmployer = new EmploymentVM();
            PreviousEmployer = new EmploymentVM();
        }
        public EmploymentVM PrimaryEmployer { get; set; }
        public EmploymentVM PreviousEmployer { get; set; }
    }
}