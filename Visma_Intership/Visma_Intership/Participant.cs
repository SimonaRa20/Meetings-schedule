namespace Visma_Intership
{
    public class Participant
    {
        public string Name { get; set; }
        public DateTime TimeWhenWasAdded { get; set; }

        public Participant(string name)
        {
            Name = name;
            TimeWhenWasAdded = DateTime.Now;
        }
    }
}
