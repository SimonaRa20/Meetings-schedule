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


    }
}
