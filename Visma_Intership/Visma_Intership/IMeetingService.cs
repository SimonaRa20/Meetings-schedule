namespace Visma_Intership
{
    public interface IMeetingService
    {
        void ReadMeetings();
        void SaveMeetings();
        List<Meeting> GetMeetings();
        void RemoveMeeting(Meeting meeting);
        void AddMeeting(Meeting newMeeting);
    }
}
