
namespace Connect.Domain.Models
{
    public class LanguageSkill
    {
        public int Id { get; set; }

        public string Level { get; set; }

        public int RateMaster { get; set; }

        public int RateApprentice { get; set; }

        public int LanguageId { get; set; }

        public int? UserId { get; set; }

        public int? UserWishedId { get; set; }

        public Language Language { get; set; }
    }
}
