namespace UserWebApi.Models
{
    public class UserDTO
    {
        public int RoleId { get; set; }
        public string UserCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sector { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
