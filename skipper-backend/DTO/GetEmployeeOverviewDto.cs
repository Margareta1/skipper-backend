namespace skipper_backend.DTO
{
    public class GetEmployeeOverviewDto
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Projects { get; set; }
        public string UtilizationType { get; set; }
        public double UtilizationAmount { get; set; }
        public string Languages { get; set; }
        public string Skills { get; set; }
    }
}
