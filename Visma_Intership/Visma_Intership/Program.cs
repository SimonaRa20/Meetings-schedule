namespace Visma_Intership
{
    class Program
    {


        public static void Main(string[] args)
        {
            List<Meeting> meetingList = new List<Meeting>();
            FileServise fileServise = new FileServise();
            MeetingService meetingService = new MeetingService(fileServise);

            meetingService.ReadMeetings();

            meetingList = meetingService.GetMeetings();
            TaskUtils.PrintMeetingsList(meetingList);
            //TaskUtils.PrintMeetingsList(meetingList);

            //Console.WriteLine(meetingList.Count);

            DateTime dt2 = new DateTime(2015, 12, 31);
            //Meeting meeting = new Meeting("Stand Up", "Simona Ragauskaite", "Prisisakysime savo daromos uzduoties progresa", Category.Short,
            // Type.Live, dt2, dt2);

            Console.WriteLine("Commands list: \n*Create meeting \n*Delete meeting \n*Add person to meeting  \n*Remove person from meeting \n*Filter meetings\nPlease write command:");
            string command = Console.ReadLine();

            switch (command)
            {
                case "Create meeting":
                    CreateMeeting(meetingService, meetingList);
                    break;

                case "Delete meeting":
                    DeleteMeeting(meetingService, meetingList);
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
        public static void CreateMeeting(MeetingService meetingService, List<Meeting> meetingList)
        {
            Meeting newMeeting = TaskUtils.AddNewMeeting();
            Console.WriteLine("Chosen command - create meeting");
            meetingService.AddMeeting(newMeeting);
            TaskUtils.PrintMeetingsList(meetingList);
        }

        public static void DeleteMeeting(MeetingService meetingService, List<Meeting> meetingList)
        {
            Console.WriteLine("There is meetings list:");
            TaskUtils.PrintMeetingsList(meetingList);
            Console.Write("Please write what are you : ");
            string nameSurname = Console.ReadLine();

            Console.WriteLine("Please write meeting nr which you want to delete");
            string deleteNr = Console.ReadLine();
            int nr = Convert.ToInt32(deleteNr);

            Meeting meeting = TaskUtils.RemoveMeeting(meetingList, nr, nameSurname);
            meetingService.RemoveMeeting(meeting);
            TaskUtils.PrintMeetingsList(meetingList);
        }
    }




}
