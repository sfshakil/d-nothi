namespace dNothi.Services.UserServices
{
    public class UserParam
    {
        public string username { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return $"{username}: {password}";
        }
    }
}
