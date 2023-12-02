using ProgCourse.Data;

namespace ProgCourse
{
    internal static class Program
    {
        public static UserStorage UserStorage = new JsonUserStorage("users.json");
        public static DataManager DataManager = new DataManager(UserStorage);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataManager.LoadAll();

            ApplicationConfiguration.Initialize();
            Application.Run(new LogInForm());
        }
    }
}