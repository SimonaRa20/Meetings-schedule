namespace Visma_Intership
{
    class Program
    {


        public static void Main(string[] args)
        {
            //MeetingService meetingService;
            //SomeMethod(meetingService);
            List<Meeting> meetingList = new List<Meeting>();
            SomeMethod();


            Console.WriteLine(meetingList.Count);

            DateTime dt2 = new DateTime(2015, 12, 31);
            //Meeting meeting = new Meeting("Stand Up", "Simona Ragauskaite", "Prisisakysime savo daromos uzduoties progresa", Category.Short,
            // Type.Live, dt2, dt2);
            //InOutUtils.AddNewMeeting(meetingList, meeting, fileName);

            //string command = string.Empty;
            Console.WriteLine("Commands list: \n*Create meeting \n*Delete meeting \n*Add person to meeting  \n*Remove person from meeting \n*Filter meetings\nPlease write command:");
            string command = Console.ReadLine();

            switch (command)
            {
                case "Create meeting":
                    Console.WriteLine("Chosen command - create meeting");
                    break;

                case "Delete meeting":
                    Console.WriteLine("Chosen command - delete meeting");
                    break;

                case "Add person to meeting":
                    Console.WriteLine("Chosen command - add person to meeting");
                    break;

                case "Remove person from meeting":
                    Console.WriteLine("Chosen command - remove person from meeting");
                    break;
                case "Filter meetings":
                    Console.WriteLine("Chosen command - filter meetings");
                    break;
                default:
                    Console.WriteLine("This command was not founded");
                    break;
            }

        }
        //private MeetingService meetingService;
        static void SomeMethod()
        {
            FileServise fileServise = new FileServise();
            MeetingService meetingService = new MeetingService(fileServise);
            meetingService.SaveMeetings();
            meetingService.ReadMeetings();

        }
    }


}
