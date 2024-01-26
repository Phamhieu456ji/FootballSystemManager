using System.ComponentModel.DataAnnotations;

namespace FastConnectFootballSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}