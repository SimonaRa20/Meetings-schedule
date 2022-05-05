namespace Visma_Intership
{
    class Participant
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime TimeThenWasAdded { get; set; }
        public List<Meeting> listMeetings;

    }
}
