namespace Visma_Intership
{
    class TaskUtils
    {
        public static void PrintMeetingsList(List<Meeting> list)
        {
            Console.WriteLine(new string('-', 185));
            Console.WriteLine(string.Format("| {0,5} | {1,15} | {2,30} | {3,50} | {4, 10} | {5,10} | {6,20} | {7,20} |", "Nr",
           "Name", "Responsible Person", "Description", "Category", "Type", "StartDate", "EndDate"));
            Console.WriteLine(new string('-', 185));
            for (int i = 0; i < list.Count; i++)
            {
                Meeting meeting = list[i];
                Console.WriteLine(string.Format("| {0,5} | {1,15} | {2,30} | {3,50} | {4, 10} | {5,10} | {6,20} | {7,20} |",
                   i + 1, meeting.Name, meeting.ResponsiblePerson, meeting.Description, meeting.Category, meeting.Type,
                   meeting.StartDate, meeting.EndDate));
                Console.WriteLine(new string('-', 185));
            }
        }

        public static Meeting AddNewMeeting()
        {
            Meeting meeting = new Meeting();
            Console.WriteLine("New Meeting");
            Console.Write("Enter meeting name: ");
            meeting.Name = Console.ReadLine();

            Console.Write("Enter meeting responsible person: ");
            meeting.ResponsiblePerson = Console.ReadLine();

            Console.Write("Enter meeting description: ");
            meeting.Description = Console.ReadLine();

            Console.Write("Enter meeting category (CodeMonkey/Hub/Short/TeamBuilding): ");
            string category = Console.ReadLine();
            Category newCategory = (Category)Enum.Parse(typeof(Category), category);
            meeting.Category = newCategory;

            Console.Write("Enter meeting type (Live/InPerson): ");
            string type = Console.ReadLine();
            Type newType = (Type)Enum.Parse(typeof(Type), type);
            meeting.Type = newType;

            Console.Write("Enter meeting start date (f.e. 2020-05-05 11:00:00): ");
            string startDate = Console.ReadLine();
            meeting.StartDate = Convert.ToDateTime(startDate);

            Console.Write("Enter meeting end date (f.e. 2020-05-05 12:00:00): ");
            string endDate = Console.ReadLine();
            meeting.EndDate = Convert.ToDateTime(endDate);

            return meeting;
        }



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
        //public static List<Meeting> FilterByTheNumberOfAttendees(List<Meeting> list, int attendeesNumber)
        //{
        //    List<Meeting> filteredList = new List<Meeting>();
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].participants.Count > attendeesNumber)
        //        {
        //            filteredList.Add(list[i]);
        //        }
        //    }

        //    return filteredList;
        //}
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
        //public static Meeting AddAPersonToTheMeeting(Meeting meeting, Participant participant)
        //{
        //    for (int i = 0; i < meeting.participants.Count; i++)
        //    {
        //        if (meeting.participants[i] != participant)
        //        {
        //            //if (participant.listMeetings[])
        //            meeting.participants.Add(participant);
        //        }
        //    }
        //    return meeting;
        //}
    }
}
