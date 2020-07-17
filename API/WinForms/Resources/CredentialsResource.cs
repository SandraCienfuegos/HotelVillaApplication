using System.ComponentModel.DataAnnotations;

namespace Winforms
{
    public class CredentialsResource
    {
        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }
    }
}