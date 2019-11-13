using System;
namespace hamgooonWebServerV1.Exceptions.Users
{
    public class UserNotFound: Exception
    {
        public UserNotFound(): base("User not found")
        {
        }
    }
}
