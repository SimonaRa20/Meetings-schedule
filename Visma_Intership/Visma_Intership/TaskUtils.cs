﻿namespace Visma_Intership
{
    public static class TaskUtils
    {
        public static void PrintMeetingsList(List<Meeting> list)
        {
            const int dashCount = 185;
            string format = "| {0,5} | {1,15} | {2,30} | {3,50} | {4, 10} | {5,10} | {6,20} | {7,20} |";
            Console.WriteLine(new string('-', dashCount));
            Console.WriteLine(string.Format(format, "Nr",
           "Name", "Responsible Person", "Description", "Category", "Type", "StartDate", "EndDate"));
            Console.WriteLine(new string('-', dashCount));
            for (int i = 0; i < list.Count; i++)
            {
                Meeting meeting = list[i];
                Console.WriteLine(string.Format(format,
                   i + 1, meeting.Name, meeting.ResponsiblePerson, meeting.Description, meeting.Category, meeting.Type,
                   meeting.StartDate, meeting.EndDate));
                Console.WriteLine(new string('-', dashCount));
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

        public static Meeting RemoveMeeting(List<Meeting> list, int nr, string responsiblePerson)
        {
            int nrMeeting = nr - 1;
            Meeting meeting = new Meeting();
            for (int i = 0; i < list.Count; i++)
            {
                if (nrMeeting == i)
                {
                    if (list[i].ResponsiblePerson == responsiblePerson)
                    {
                        meeting = list[i];
                    }
                }
            }
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

        public static List<Meeting> FilterByCategory(List<Meeting> list, string category)
        {
            Category newCategory = (Category)Enum.Parse(typeof(Category), category);
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Category == newCategory)
                {
                    filteredList.Add(list[i]);
                }
            }

            return filteredList;
        }

        public static List<Meeting> FilterByType(List<Meeting> list, string type)
        {
            Type newType = (Type)Enum.Parse(typeof(Type), type);
            List<Meeting> filteredList = new List<Meeting>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Type == newType)
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
    }
}
