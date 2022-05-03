
namespace Visma_Intership
{
    class Program
    {
        static void Main(string[] args)
        {
            Meeting meeting = new Meeting("StandUp", "Gabija Gurkyte", "Discuss how goes project", Category.Short, Type.Live,
                new DateTime(2022, 5, 3), new DateTime(2022, 5, 3));

            Console.WriteLine("Name : {0}", meeting.Name);
            Console.WriteLine("ResponsiblePerson : {0}", meeting.ResponsiblePerson);
            Console.WriteLine("Description : {0}", meeting.Description);
            Console.WriteLine("Category : {0}", meeting.Category);
            Console.WriteLine("Type : {0}", meeting.Type);
            Console.WriteLine("StartDate : {0:yyy-MM-dd}", meeting.StartDate);
            Console.WriteLine("EndDate : {0:yyy-MM-dd}", meeting.EndDate);
        }


    }
}
