namespace Visma_Intership
{
    public class MeetingService : IMeetingService
    {
        private List<Meeting> Meetings { get; set; } = new List<Meeting>();
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

            Meetings = result;
            MeetingsUpdated?.Invoke(this, null);
        }

        public void SaveMeetings()
            => _fileService.SaveFile(Meetings, "meeting_data.json");
    }
}
