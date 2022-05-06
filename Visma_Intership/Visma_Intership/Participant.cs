namespace Visma_Intership
{
    public class Participant
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime TimeWhenWasAdded { get; set; }

        public Participant(string name, string surname, DateTime timeWhenWasAdded)
        {
            Name = name;
            Surname = surname;
            TimeWhenWasAdded = timeWhenWasAdded;
        }
    }
}
