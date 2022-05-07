namespace Visma_Intership
{
    public static class Validator
    {
        public static bool ValidateType(string type, out Type result)
        {
            if (!Enum.TryParse(type, out result))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDescription(string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                return true;
            }
            return false;
        }

        public static bool ValidateName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return true;
            }
            return false;
        }

        public static bool ValidateResposiblePerson(string responsiblePerson)
        {
            if (!string.IsNullOrEmpty(responsiblePerson))
            {
                return true;
            }
            return false;
        }

        public static bool ValidateCategory(string category, out Category result)
        {
            if (!Enum.TryParse(category, out result))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateAttendeesCount(string attendeesCount, out int count)
        {
            if (!int.TryParse(attendeesCount, out count))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDate(string date, out DateTime result)
        {
            if (!DateTime.TryParse(date, out result))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateParticipant(string participant)
        {
            if (!string.IsNullOrEmpty(participant))
            {
                return true;
            }
            return false;
        }
    }
}
