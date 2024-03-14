namespace BOL.API.Service;

public class User
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string UserDesc { get; set; }

    public string Token { get; set; }

    public string[] Roles { get; set; }

    public int SessionId { get; set; }
}

