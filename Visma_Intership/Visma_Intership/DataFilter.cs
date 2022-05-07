namespace Visma_Intership
{
    public class DataFilter
    {
        public static void FilterByDescription(List<Meeting> meetingList)
        {
            string description = DataRequestor.GetDescription();
            List<Meeting> filterByDescription = TaskUtils.FilterByDescription(meetingList, description);
            TaskUtils.PrintMeetingsList(filterByDescription);
        }

        public static void FilterByResponsiblePerson(List<Meeting> meetingList)
        {
            string responsiblePerson = DataRequestor.GetResponsiblePerson();
            List<Meeting> filterByResponsiblePerson = TaskUtils.FilterByResponsiblePerson(meetingList, responsiblePerson);
            TaskUtils.PrintMeetingsList(filterByResponsiblePerson);
        }

        public static void FilterByCategory(List<Meeting> meetingList)
        {
            Category category = DataRequestor.GetCategory();
            List<Meeting> filterByCategory = TaskUtils.FilterByCategory(meetingList, category);
            TaskUtils.PrintMeetingsList(filterByCategory);
        }

        public static void FilterByType(List<Meeting> meetingList)
        {
            Type type = DataRequestor.GetType();
            List<Meeting> filterByType = TaskUtils.FilterByType(meetingList, type);
            TaskUtils.PrintMeetingsList(filterByType);
        }

        public static void FilterByDates(List<Meeting> meetingList)
        {
            Console.WriteLine("Start interval date:");
            DateTime startDate = DataRequestor.GetDates();
            Console.WriteLine("End interval date:");
            DateTime endDate = DataRequestor.GetDates();

            List<Meeting> filterByDate = TaskUtils.FilterByDates(meetingList, startDate, endDate);
            TaskUtils.PrintMeetingsList(filterByDate);
        }

        public static void FilterByAttendeesCount(List<Meeting> meetingList)
        {
            int attendeesCount = DataRequestor.GetAttendeesCount();
            List<Meeting> filterByAttendeesCount = TaskUtils.FilterByAttendeesCount(meetingList, attendeesCount);
            TaskUtils.PrintMeetingsList(filterByAttendeesCount);
        }
    }
}
