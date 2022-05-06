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
    }
}
