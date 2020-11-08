namespace dNothi.Services.UserServices
{
    public class UserParam
    {
        public UserParam(string userName,string password)
        {
            this.username = userName;
            this.password = password;
        }
        public string username { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return $"{username}: {password}";
        }
    }
}
