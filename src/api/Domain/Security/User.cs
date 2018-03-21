using System.ComponentModel.DataAnnotations;

namespace OutreachOperations.Api.Domain.Security
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public string EmailAddress { get; set; }
    }
}
