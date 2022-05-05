namespace Visma_Intership
{
    public interface IMeetingService
    {
        void ReadMeetings();
        void SaveMeetings();
        List<Meeting> GetMeetings();
        public void RemoveMeeting(Meeting meeting);
    }
}
