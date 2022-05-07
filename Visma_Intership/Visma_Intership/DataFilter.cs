namespace Visma_Intership
{
    public class DataFilter
    {
        public static void FilterByDescription(List<Meeting> meetingList)
        {
            string description = DataRequestor.GetDescription();
            List<Meeting> filterByDescription = FilterByDescription(meetingList, description);
            TaskUtils.PrintMeetingsList(filterByDescription);
        }

        public static void FilterByResponsiblePerson(List<Meeting> meetingList)
        {
            string responsiblePerson = DataRequestor.GetResponsiblePerson();
            List<Meeting> filterByResponsiblePerson = FilterByResponsiblePerson(meetingList, responsiblePerson);
            TaskUtils.PrintMeetingsList(filterByResponsiblePerson);
        }

        public static void FilterByCategory(List<Meeting> meetingList)
        {
            Category category = DataRequestor.GetCategory();
            List<Meeting> filterByCategory = FilterByCategory(meetingList, category);
            TaskUtils.PrintMeetingsList(filterByCategory);
        }

        public static void FilterByType(List<Meeting> meetingList)
        {
            Type type = DataRequestor.GetType();
            List<Meeting> filterByType = FilterByType(meetingList, type);
            TaskUtils.PrintMeetingsList(filterByType);
        }

        public static void FilterByDates(List<Meeting> meetingList)
        {
            DateTime startDate = DataRequestor.GetStartDate();
            DateTime endDate = DataRequestor.GetEndDate();

            List<Meeting> filterByDate = FilterByDates(meetingList, startDate, endDate);
            TaskUtils.PrintMeetingsList(filterByDate);
        }

        public static void FilterByAttendeesCount(List<Meeting> meetingList)
        {
            int attendeesCount = DataRequestor.GetAttendeesCount();
            List<Meeting> filterByAttendeesCount = FilterByAttendeesCount(meetingList, attendeesCount);
            TaskUtils.PrintMeetingsList(filterByAttendeesCount);
        }

        public static List<Meeting> FilterByDescription(List<Meeting> list, string description)
        {
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Description.Contains(description, StringComparison.OrdinalIgnoreCase))
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
                if (list[i].ResponsiblePerson.Equals(responsiblePerson, StringComparison.OrdinalIgnoreCase))
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

        public static List<Meeting> FilterByType(List<Meeting> list, Type type)
        {
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == type)
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
                if (list[i].StartDate >= startDate && list[i].StartDate < endDate)
                {
                    filteredList.Add(list[i]);
                }
            }

            return filteredList;
        }

        public static List<Meeting> FilterByAttendeesCount(List<Meeting> list, int count)
        {
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Participants.Count >= count)
                {
                    filteredList.Add(list[i]);
                }
            }
            return filteredList;
        }
    }
}
