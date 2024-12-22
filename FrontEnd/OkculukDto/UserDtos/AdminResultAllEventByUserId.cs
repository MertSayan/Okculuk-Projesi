namespace OkculukDto.UserDtos
{
    public class AdminResultAllEventByUserId
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Status { get; set; }
        public string RejectedReason { get; set; }
    }
}
