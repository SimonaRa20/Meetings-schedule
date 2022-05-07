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
                                FilterByDescription(meetingList);
                                break;

                            case "Responsible person":
                                FilterByResponsiblePerson(meetingList);
                                break;

                            case "Category":
                                FilterByCategory(meetingList);
                                break;

                            case "Type":
                                FilterByType(meetingList);
                                break;
                            case "Dates":
                                FilterByDates(meetingList);
                                break;
                            case "The number of attendees":
                                FilterByAttendeesCount(meetingList);
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

            Meeting meeting = TaskUtils.RemoveMeeting(meetingList, nr, nameSurname);
            meetingService.RemoveMeeting(meeting);
            TaskUtils.PrintMeetingsList(meetingList);
        }

        public static void FilterByDescription(List<Meeting> meetingList)
        {
            Console.WriteLine("Write description:");
            string description = Console.ReadLine();
            List<Meeting> filterByDescription = TaskUtils.FilterByDescription(meetingList, description);
            TaskUtils.PrintMeetingsList(filterByDescription);
        }

        public static void FilterByResponsiblePerson(List<Meeting> meetingList)
        {
            Console.WriteLine("Write respnsible person:");
            string responsiblePerson = Console.ReadLine();
            List<Meeting> filterByResponsiblePerson = TaskUtils.FilterByResponsiblePerson(meetingList, responsiblePerson);
            TaskUtils.PrintMeetingsList(filterByResponsiblePerson);
        }

        public static void FilterByCategory(List<Meeting> meetingList)
        {
            Console.WriteLine("Write category:");
            string category = Console.ReadLine();
            List<Meeting> filterByCategory = TaskUtils.FilterByCategory(meetingList, category);
            TaskUtils.PrintMeetingsList(filterByCategory);
        }

        public static void FilterByType(List<Meeting> meetingList)
        {
            Console.WriteLine("Write type:");
            string type = Console.ReadLine();
            List<Meeting> filterByType = TaskUtils.FilterByType(meetingList, type);
            TaskUtils.PrintMeetingsList(filterByType);
        }

        public static void FilterByDates(List<Meeting> meetingList)
        {
            Console.WriteLine("Write interval start date:");
            string startDate = Console.ReadLine();
            Console.WriteLine("Write interval end date:");
            string endDate = Console.ReadLine();

            DateTime start = Convert.ToDateTime(startDate);
            DateTime end = Convert.ToDateTime(endDate);
            List<Meeting> filterByDate = TaskUtils.FilterByDates(meetingList, start, end);
            TaskUtils.PrintMeetingsList(filterByDate);
        }

        public static void FilterByAttendeesCount(List<Meeting> meetingList)
        {
            Console.WriteLine("Write attendees count:");
            string count = Console.ReadLine();
            int attendeesCount = Convert.ToInt32(count);
            List<Meeting> filterByAttendeesCount = TaskUtils.FilterByAttendeesCount(meetingList, attendeesCount);
            TaskUtils.PrintMeetingsList(filterByAttendeesCount);
        }
    }





}
