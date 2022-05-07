namespace Visma_Intership
{
    public class MeetingService : IMeetingService
    {
        private List<Meeting> _meetings { get; set; } = new List<Meeting>();
        private readonly IFileService _fileService;

        public MeetingService(IFileService fileService)
        {
            _fileService = fileService;
            ReadMeetings();
        }

        public void ReadMeetings()
        {
            var result = _fileService.ReadFile<List<Meeting>>("meeting_data.json");
            if (result == null)
            {
                return;
            }

            _meetings = result;
        }

        public void SaveMeetings()
            => _fileService.SaveFile(_meetings, "meeting_data.json");

        public List<Meeting> GetMeetings()
        {
            return _meetings;
        }

        public void RemoveMeeting(Meeting removeMeeting)
        {
            var meeting = _meetings.Where(x => x == removeMeeting).FirstOrDefault();
            if (meeting == null) return;
            _meetings.Remove(meeting);
            SaveMeetings();
        }
        public void AddMeeting(Meeting newMeeting)
        {
            _meetings.Add(newMeeting);
            SaveMeetings();
        }
        public void AddPerson(Meeting meeting, Participant participant)
        {
            var foundMeeting = _meetings.Where(x => x == meeting).FirstOrDefault();
            if (foundMeeting == null)
            {
                return;
            }
            foundMeeting.Participants.Add(participant);
            SaveMeetings();
        }

        public void RemovePerson(Meeting meeting, Participant participant)
        {
            var foundMeeting = _meetings.Where(x => x == meeting).FirstOrDefault();
            if (foundMeeting == null)
            {
                return;
            }
            foundMeeting.Participants.Remove(participant);
            SaveMeetings();
        }

        public void CreateNewMeeting()
        {
            Meeting meeting = new Meeting();
            Console.WriteLine("New Meeting");

            meeting.Name = DataRequestor.GetName();
            meeting.ResponsiblePerson = DataRequestor.GetResponsiblePerson();
            meeting.Description = DataRequestor.GetDescription();
            meeting.Category = DataRequestor.GetCategory();
            meeting.Type = DataRequestor.GetType();
            meeting.StartDate = DataRequestor.GetStartDate();
            meeting.EndDate = DataRequestor.GetEndDate();
            meeting.Participants.Add(new Participant(DataRequestor.GetParticipantName()));

            AddMeeting(meeting);
        }
    }
}
