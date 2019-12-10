using System;
namespace HamgoonAPI.Exceptions.Users
{
    public class UserNotFound: Exception
    {
        public UserNotFound(): base("User not found")
        {
        }
    }
}
