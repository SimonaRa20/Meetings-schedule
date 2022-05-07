namespace Visma_Intership
{
    public static class TaskUtils
    {
        public static void PrintMeetingsList(List<Meeting> list)
        {
            const int dashCount = 185;
            string format = "| {0,5} | {1,15} | {2,20} | {3,30} | {4, 10} | {5,10} | {6,20} | {7,20} | {8,30} |";
            Console.WriteLine(new string('-', dashCount));
            Console.WriteLine(string.Format(format, "Nr",
           "Name", "Responsible Person", "Description", "Category", "Type", "StartDate", "EndDate", "Participants"));
            Console.WriteLine(new string('-', dashCount));
            for (int i = 0; i < list.Count; i++)
            {
                Meeting meeting = list[i];
                string participantsList = string.Empty;
                for (int j = 0; j < meeting.Participants.Count; j++)
                {
                    participantsList = participantsList + meeting.Participants[j].Name + ", ";
                }

                Console.WriteLine(string.Format(format,
                   i + 1, meeting.Name, meeting.ResponsiblePerson, meeting.Description, meeting.Category, meeting.Type,
                   meeting.StartDate, meeting.EndDate, participantsList));

                Console.WriteLine(new string('-', dashCount));
            }
        }

        public static Meeting AddNewMeeting()
        {
            Meeting meeting = new Meeting();
            Console.WriteLine("New Meeting");

            string name = RequestDataFromUser("Enter meeting name: ");
            while (!Validator.ValidateName(name))
            {
                Console.WriteLine("Please try again, name was incorrect");
            }
            meeting.Name = name;

            string responsiblePerson = RequestDataFromUser("Enter meeting responsible person: ");
            while (!Validator.ValidateResposiblePerson(responsiblePerson))
            {
                Console.WriteLine("Please try again, responsible person was incorrect");
            }
            meeting.ResponsiblePerson = responsiblePerson;

            string description = RequestDataFromUser("Enter meeting description: ");
            while (!Validator.ValidateDescription(description))
            {
                Console.WriteLine("Please try again, description was incorrect");
            }
            meeting.Description = description;

            Category category;
            while (!Validator.ValidateCategory(RequestDataFromUser("Enter meeting category (CodeMonkey/Hub/Short/TeamBuilding): "), out category))
            {
                Console.WriteLine("Please try again, type was incorrect");
            }
            meeting.Category = category;

            Type type;
            while (!Validator.ValidateType(RequestDataFromUser("Enter meeting type (Live/InPerson): "), out type))
            {
                Console.WriteLine("Please try again, type was incorrect");
            }
            meeting.Type = type;

            DateTime startDate;
            while (!Validator.ValidateDate(RequestDataFromUser("Enter meeting start date (f.e. 2020-05-05 11:00:00): "), out startDate))
            {
                Console.WriteLine("Please try again, date was incorrect");
            }
            meeting.StartDate = startDate;

            DateTime endDate;
            while (!Validator.ValidateDate(RequestDataFromUser("Enter meeting end date (f.e. 2020-05-05 12:00:00): "), out endDate))
            {
                Console.WriteLine("Please try again, date was incorrect");
            }
            meeting.EndDate = endDate;

            string attendeePerson = RequestDataFromUser("Enter meeting person name and surname");
            while (!Validator.ValidateParticipant(attendeePerson))
            {
                Console.WriteLine("Please try again, person name and surname was incorrect");
            }
            meeting.Participants.Add(new Participant(attendeePerson));

            return meeting;
        }


        public static string RequestDataFromUser(string request)
        {
            Console.WriteLine(request);
            return Console.ReadLine();
        }

        public static Meeting FindMeeting(List<Meeting> list, int nr, string responsiblePerson)
        {
            int nrMeeting = nr - 1;
            Meeting meeting = new Meeting();
            if (list[nrMeeting].ResponsiblePerson == responsiblePerson)
            {
                meeting = list[nrMeeting];
            }
            return meeting;
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
