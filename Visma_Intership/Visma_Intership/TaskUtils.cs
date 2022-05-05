namespace Visma_Intership
{
    class TaskUtils
    {
        public static List<Meeting> FilterByDescription(List<Meeting> list, string description)
        {
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Description == description)
                {
                    filteredList.Add(list[i]);
                }
            }

            return filteredList;
        }
        public static List<Meeting> FilterByResponsiblePerson(List<Meeting> list, string responsiblePerson)
        {
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ResponsiblePerson == responsiblePerson)
                {
                    filteredList.Add(list[i]);
                }
            }

            return filteredList;
        }

        public static List<Meeting> FilterByCategory(List<Meeting> list, Category category)
        {
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Category == category)
                {
                    filteredList.Add(list[i]);
                }
            }

            return filteredList;
        }

        public static List<Meeting> FilterByDates(List<Meeting> list, DateTime startDate, DateTime endDate)
        {
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].StartDate >= startDate && list[i].EndDate < endDate)
                {
                    filteredList.Add(list[i]);
                }
            }

            return filteredList;
        }
        public static List<Meeting> FilterByTheNumberOfAttendees(List<Meeting> list, int attendeesNumber)
        {
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].participants.Count > attendeesNumber)
                {
                    filteredList.Add(list[i]);
                }
            }

            return filteredList;
        }
        public static List<Meeting> DeleteMeeting(List<Meeting> list, Meeting meeting)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == meeting)
                {
                    list.RemoveAt(i);
                }
            }
            return list;
        }
        public static Meeting AddAPersonToTheMeeting(Meeting meeting, Participant participant)
        {
            for (int i = 0; i < meeting.participants.Count; i++)
            {
                if (meeting.participants[i] != participant)
                {
                    //if (participant.listMeetings[])
                    meeting.participants.Add(participant);
                }
            }
            return meeting;
        }
    }
}
