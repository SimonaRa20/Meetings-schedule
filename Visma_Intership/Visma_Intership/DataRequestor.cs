namespace Visma_Intership
{
    public class DataRequestor
    {
        public static string RequestDataFromUser(string request)
        {
            Console.WriteLine(request);
            return Console.ReadLine();
        }

        public static string GetDescription()
        {
            string description = RequestDataFromUser("Write description:");
            while (!Validator.ValidateDescription(description))
            {
                description = RequestDataFromUser("Please try again write description");
            }
            return description;
        }

        public static string GetResponsiblePerson()
        {
            string responsiblePerson = RequestDataFromUser("Write responsible person: ");
            while (!Validator.ValidateResposiblePerson(responsiblePerson))
            {
                responsiblePerson = RequestDataFromUser("Please try again write responsible person");
            }
            return responsiblePerson;
        }

        public static Category GetCategory()
        {
            string category = RequestDataFromUser("Write category: ");
            Category result;
            while (!Validator.ValidateCategory(category, out result))
            {
                category = RequestDataFromUser("Please try again write category");
            }
            return result;
        }

        public static Type GetType()
        {
            string type = RequestDataFromUser("Write type: ");
            Type result;
            while (!Validator.ValidateType(type, out result))
            {
                type = RequestDataFromUser("Please try again write type");
            }
            return result;
        }

        public static DateTime GetDates()
        {
            string date = RequestDataFromUser("Write date: ");
            DateTime result;
            while (!Validator.ValidateDate(date, out result))
            {
                date = RequestDataFromUser("Please try again write date");
            }
            return result;

        }

        public static int GetAttendeesCount()
        {
            string attendeesCount = RequestDataFromUser("Write attendees count:");
            int count;
            while (!Validator.ValidateAttendeesCount(attendeesCount, out count))
            {
                attendeesCount = RequestDataFromUser("Please try again write attendees count");
            }
            return count;
        }
    }
}
