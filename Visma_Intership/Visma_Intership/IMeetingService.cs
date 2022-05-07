namespace Visma_Intership
{
    public interface IMeetingService
    {
        void ReadMeetings();
        void SaveMeetings();
        List<Meeting> GetMeetings();
        void RemoveMeeting(Meeting meeting);
        void AddMeeting(Meeting newMeeting);
        void AddPerson(Meeting meeting, Participant participant);
        void RemovePerson(Meeting meeting, Participant participant);
        void CreateNewMeeting();
    }
}
