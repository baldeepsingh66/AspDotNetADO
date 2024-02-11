namespace CrudApp.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=DESKTOP-8L0AT72; Initial Catalog=dbDemo;Integrated Security=true;";
        public static string CName
        {
            get => cName;
        }
    }
}
