namespace Visma_Intership
{
    public class MeetingService : IMeetingService
    {
        private List<Meeting> _meetings { get; set; } = new List<Meeting>();
        private readonly IFileService _fileService;
        public event EventHandler MeetingsUpdated;

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
            MeetingsUpdated?.Invoke(this, null);
        }

        public void SaveMeetings()
            => _fileService.SaveFile(_meetings, "meeting_data.json");

        public List<Meeting> GetMeetings()
        {
            return _meetings;
        }

        public void RemoveMeeting(string name)
        {
            var meeting = _meetings.Where(x => x.Name == name).FirstOrDefault();
            _meetings.Remove(meeting);
            MeetingsUpdated?.Invoke(this, null);
            SaveMeetings();
        }
        public void AddMeeting(Meeting newMeeting)
        {
            //var meeting = _meetings.Where(x => x == newMeeting).FirstOrDefault();
            _meetings.Add(newMeeting);
            MeetingsUpdated?.Invoke(this, null);
            SaveMeetings();
        }
    }
}
