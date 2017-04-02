namespace Connect.Api.Models.Update
{
    public class RateUpdateContract
    {
        public int FromUserId { get; set; }

        public int ToUserId { get; set; }

        public int Value { get; set; }
    }
}