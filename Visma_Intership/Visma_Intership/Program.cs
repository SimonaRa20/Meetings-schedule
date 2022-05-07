namespace Visma_Intership
{
    public class Program
    {
        private static IFileService _fileService;
        private static IMeetingService _meetingService;

        public static void Main(string[] args)
        {
            _fileService = new FileService();
            _meetingService = new MeetingService(_fileService);
            _meetingService.ReadMeetings();


            TaskUtils.PrintMeetingsList(_meetingService.GetMeetings());
            bool continueOperation = true;
            Console.WriteLine("Commands list: \n*Create meeting \n*Delete meeting \n*Add person to meeting  \n*Remove person from meeting \n*Filter meetings\nPlease write command:");
            while (continueOperation)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "Create meeting":
                        CreateMeeting();
                        break;

                    case "Delete meeting":
                        DeleteMeeting();
                        break;

                    case "Add person to meeting":
                        AddNewParticipant();
                        break;

                    case "Remove person from meeting":
                        RemoveParticipant();
                        break;
                    case "Filter meetings":
                        Console.WriteLine("Filter possibilities by: \n*Description \n*Responsible person \n*Category  \n*Type \n*Dates\n*The number of attendees\nPlease write command:");
                        string filterCommand = Console.ReadLine();
                        switch (filterCommand)
                        {
                            case "Description":
                                DataFilter.FilterByDescription(_meetingService.GetMeetings());
                                break;

                            case "Responsible person":
                                DataFilter.FilterByResponsiblePerson(_meetingService.GetMeetings());
                                break;

                            case "Category":
                                DataFilter.FilterByCategory(_meetingService.GetMeetings());
                                break;

                            case "Type":
                                DataFilter.FilterByType(_meetingService.GetMeetings());
                                break;

                            case "Dates":
                                DataFilter.FilterByDates(_meetingService.GetMeetings());
                                break;

                            case "The number of attendees":
                                DataFilter.FilterByAttendeesCount(_meetingService.GetMeetings());
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

        public static void CreateMeeting()
        {
            _meetingService.CreateNewMeeting();
            TaskUtils.PrintMeetingsList(_meetingService.GetMeetings());
        }

        public static void DeleteMeeting()
        {
            Console.WriteLine("There is meetings list:");
            TaskUtils.PrintMeetingsList(_meetingService.GetMeetings());
            Console.Write("Please write what are you : ");
            string nameSurname = Console.ReadLine();

            Console.WriteLine("Please write meeting nr which you want to delete");
            string deleteNr = Console.ReadLine();
            int nr = Convert.ToInt32(deleteNr);

            Meeting meeting = TaskUtils.FindMeeting(_meetingService.GetMeetings(), nr, nameSurname);
            _meetingService.RemoveMeeting(meeting);
            TaskUtils.PrintMeetingsList(_meetingService.GetMeetings());
        }

        public static void AddNewParticipant()
        {





            string participantName = DataRequestor.GetParticipantName();
            int meetingNr = DataRequestor.GetMeetingByNr();
            Meeting foundMeeting = _meetingService.GetMeetings()[meetingNr - 1];
            foundMeeting.Participants.Add(new Participant(participantName));

            _meetingService.AddMeeting(foundMeeting);
        }

        public static void RemoveParticipant()
        {
            string participantName = DataRequestor.GetParticipantName();

            for (int i = 0; i < _meetingService.GetMeetings().Count; i++)
            {
                if (_meetingService.GetMeetings()[i].ResponsiblePerson != participantName)
                {
                    _meetingService.RemovePerson(_meetingService.GetMeetings()[i], new Participant(participantName));
                }
                else
                {
                    return;
                }
            }
        }
    }
}
