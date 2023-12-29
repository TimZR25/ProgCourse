using ProgCourse.Data;
using ProgCourse.User;
using ProgCourse.Utilities;

namespace ProgCourse.LogIn.Service
{
    public class LogInService : ILogInService
    {
        private IUserEntity? _currentUser;

        public IUserEntity? CurrentUser => _currentUser;

        private IBaseRepository<IUserEntity> _userRepository;

        public LogInService(IBaseRepository<IUserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool TryLogInUser(string login, string password, out string errorText)
        {
            errorText = string.Empty;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                errorText = "Пустое поле логина или пароля";
                return false;
            }

            password = HashConverter.ToHashString(password);

            var user = (from x in _userRepository.GetAll()
                        where x.Login == login && x.Password == password
                        select x).FirstOrDefault();

            if (user == null)
            {
                errorText = "Неверный логин или пароль";
                return false;
            }

            _currentUser = user;

            return true;
        }
    }
}
