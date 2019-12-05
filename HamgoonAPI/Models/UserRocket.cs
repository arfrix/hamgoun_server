namespace HamgoonAPI.Models
{
    
    
    public class UserRocket
    {
        public long Id { set; get; } 
        public string Password { get; set; }

        public UserRocket(long id, string password) => (this.Id, this.Password) = (id, password);
    }
}