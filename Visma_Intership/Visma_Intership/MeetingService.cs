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
    }
}
