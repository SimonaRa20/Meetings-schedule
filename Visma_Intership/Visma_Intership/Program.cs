namespace Visma_Intership
{
    class Program
    {


        public static void Main(string[] args)
        {
            List<Meeting> meetingList = new List<Meeting>();
            FileService fileServise = new FileService();
            MeetingService meetingService = new MeetingService(fileServise);

            meetingService.ReadMeetings();

            meetingList = meetingService.GetMeetings();
            TaskUtils.PrintMeetingsList(meetingList);
            bool continueOperation = true;
            Console.WriteLine("Commands list: \n*Create meeting \n*Delete meeting \n*Add person to meeting  \n*Remove person from meeting \n*Filter meetings\nPlease write command:");
            while (continueOperation)
            {
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
                        Console.WriteLine("Filter possibilities by: \n*Description \n*Responsible person \n*Category  \n*Type \n*Dates\n*The number of attendees\nPlease write command:");
                        string filterCommand = Console.ReadLine();
                        switch (filterCommand)
                        {
                            case "Description":
                                DataFilter.FilterByDescription(meetingList);
                                break;

                            case "Responsible person":
                                DataFilter.FilterByResponsiblePerson(meetingList);
                                break;

                            case "Category":
                                DataFilter.FilterByCategory(meetingList);
                                break;

                            case "Type":
                                DataFilter.FilterByType(meetingList);
                                break;
                            case "Dates":
                                DataFilter.FilterByDates(meetingList);
                                break;
                            case "The number of attendees":
                                DataFilter.FilterByAttendeesCount(meetingList);
                                break;
                            default:
                                Console.WriteLine("This filter possibility was not found");
                                break;
                        }

                        break;
                    default:
                        Console.WriteLine("This command was not found");
                        break;

                }
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

            Meeting meeting = TaskUtils.FindMeeting(meetingList, nr, nameSurname);
            meetingService.RemoveMeeting(meeting);
            TaskUtils.PrintMeetingsList(meetingList);
        }
    }
}
