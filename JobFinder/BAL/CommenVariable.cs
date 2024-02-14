namespace JobFinder.BAL
{
    public class CommenVariable
    {
        private static IHttpContextAccessor _HttpContextAccessor;
        static CommenVariable()
        {
            _HttpContextAccessor = new HttpContextAccessor();
        }

        public static int? UserID()
        {
            return Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetString("UserID"));
        }

        public static string UserName()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("UserName");
        }

        public static string FirstName()
        {
            return _HttpContextAccessor.HttpContext.Session.GetString("FirstName");
        }
    }
}
