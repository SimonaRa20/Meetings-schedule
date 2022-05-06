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
        public List<Participant> Participants { get; set; } = new List<Participant>();

        public Meeting(string name, string responsiblePerson, string description,
            Category category, Type type, DateTime startDate, DateTime endDate, List<Participant> participants)
        {
            Name = name;
            ResponsiblePerson = responsiblePerson;
            Description = description;
            Category = category;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            Participants = participants;
        }

        public Meeting()
        {
        }
    }
}
