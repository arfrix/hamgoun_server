using System;

namespace HamgoonAPIV1.Services.RocketChat
{
    public class RocketChatRegisterFailed: Exception
    {
        public RocketChatRegisterFailed(string msg): base("RocketRegisterFailed due to "+msg)
        {
            
        }
        
    }
}