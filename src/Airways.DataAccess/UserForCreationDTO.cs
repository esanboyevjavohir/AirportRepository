using Airways.Core.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Airways.DataAccess
{
    public class UserForCreationDTO
    {
        [Required(ErrorMessage = "Foydalanuvchi nomini kiritish shart")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Ism uzunligi kamida 2 ta va maksimal 15 ta bo'lishi kerak")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Ism faqat harflar va bo'sh joylardan iborat bo'lishi mumkin" )]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email manzilini kiritish shart")]
        [EmailAddress(ErrorMessage = "Email manzil noto'g'ri formatda")]
        public string? Email { get; set; }
        [DefaultValue("")]
        public string? Address { get; set; }    
        public Role Role { get; set; }
        [DefaultValue("")]
        public string? Password { get; set; }
    }
}
