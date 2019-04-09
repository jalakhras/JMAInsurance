using System.Collections.Generic;
using JMAInsurance.Entity.Enum;
namespace JMAInsurance.Entity
{
    public static class AdUsers
    {
        public static List<AdUser> AdUsersList { get; set; }
    }

    public class AdUser
    {
        public string GUID { get; set; }
        public string value
        {
            get
            {
                switch (SessionManager.Current.CurrentLanguage)
                {
                    case enum_Language.English:
                        if (!string.IsNullOrWhiteSpace(EnglishName))
                            return EnglishName;
                        else
                            return ArabicName;
                    case enum_Language.Arabic:
                    default:
                        return ArabicName;
                }
            }
        }
        public string Username { get; set; }
        public int? Id { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
    }

    public class UsersModel
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class DeptModel
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}