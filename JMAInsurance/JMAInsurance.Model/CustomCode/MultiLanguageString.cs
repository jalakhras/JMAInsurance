using System.ComponentModel.DataAnnotations.Schema;
using JMAInsurance.Entity.Enum;
namespace JMAInsurance.Entity.CustomCode
{
    [ComplexType]
    public class MultiLanguageString
    {
        [NotMapped]
        public string LocalizedValue {
            get
            {
                switch (SessionManager.Current.CurrentLanguage)
                {
                    case enum_Language.English:
                        return English;
                    case enum_Language.Arabic:
                    default:
                        return Arabic;
                }
            }
        }

        public string Arabic{ get; set; }

        public string English { get; set; }
    }
}
