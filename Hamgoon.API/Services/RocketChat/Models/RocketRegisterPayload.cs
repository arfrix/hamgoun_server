namespace HamgoonAPIV1.Services.RocketChat
{
    public class RocketChatRegisterPayload
    {
        public string username { get; }
        public string pass { get; }
        public string email { get; }
        public string name { get; }

        public RocketChatRegisterPayload(string username, string pass, string email, string name)
            => (this.username, this.pass, this.email, this.name) = (username, pass, email, name);

    }
}