using System;

namespace HamgoonAPI.Exceptions.Users
{
    public class UserAlreadyExists: Exception
    {
        public UserAlreadyExists(): base("UserAlreadyExists")
        {
            
        }
    }
}