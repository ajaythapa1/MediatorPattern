namespace MediatorR.Models
{
    public class TblUserProfile : Users
    {
        public Guid Id {  get; set; }
        public string PasswordHash {  get; set; }
        public bool IsActive {  get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
