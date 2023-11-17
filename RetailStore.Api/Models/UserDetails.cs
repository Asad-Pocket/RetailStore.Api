using RetailStore.Api.Models.ViewModel;

namespace RetailStore.Api.Models
{
    public class UserDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Branch { get; set; }
        public string? Role { get; set; } = Roles.User;
    }
}
