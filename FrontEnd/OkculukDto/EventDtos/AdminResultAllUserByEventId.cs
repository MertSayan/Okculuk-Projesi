namespace OkculukDto.EventDtos
{
    public class AdminResultAllUserByEventId
    {
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string PhoneNumber { get; set; }
            public string RoleName { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
            public DateTime BasvuruZamani { get; set; }
    }
}
