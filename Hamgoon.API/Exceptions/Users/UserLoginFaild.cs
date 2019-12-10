using System;
namespace HamgoonAPI.Exceptions.Users
{
    public class UserLoginFaild: Exception
    {
        public UserLoginFaild(): base("Username/password combination is wrong")
        {
        }
    }
}
