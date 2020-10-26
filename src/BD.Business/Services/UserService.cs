using BD.Business.Interfaces;

namespace BD.Business.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(INotificator notificator, IUserRepository userRepository) : base(notificator)
        {
            _userRepository = userRepository;
        }
        
        public async void Disable(int id)
        {
            await _userRepository.Disable(id);
        }

        public async void Reactivate(int id)
        {
            await _userRepository.Reactivate(id);
        }
        
        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}