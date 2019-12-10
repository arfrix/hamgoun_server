using System;

namespace HamgoonAPIV1.Services.RocketChat
{
    public class RocketChatLoginFailed: Exception
    {
        public RocketChatLoginFailed(string status): base("RocketChatLoginFailed with status "+status)
        {
            
        }
    }
}