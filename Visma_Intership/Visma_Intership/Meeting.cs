namespace Visma_Intership
{
    public class Meeting
    {
        public string Name { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Type Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public List<Participant> participants;

        public Meeting(string name, string responsiblePerson, string description,
            Category category, Type type, DateTime startDate, DateTime endDate)
        {
            this.Name = name;
            this.ResponsiblePerson = responsiblePerson;
            this.Description = description;
            this.Category = category;
            this.Type = type;
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public Meeting()
        {
        }
    }
}
