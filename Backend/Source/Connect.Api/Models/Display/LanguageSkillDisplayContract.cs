namespace Connect.Api.Models.Display
{
    public class LanguageSkillDisplayContract
    {
        public LanguageDisplayContract Language { get; set; }

        public string Level { get; set; }

        public int RateMaster { get; set; }

        public int RateApprentice { get; set; }
    }
}