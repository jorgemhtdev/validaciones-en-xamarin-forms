namespace ValidationXF.Features
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseValidationViewModel
    {
        private string email;
        private string password;
        private ICommand iniciarSesionCommand;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                Validate(() => email.Length > 6,
                    "El email es obligatorio");
                OnPropertyChanged();
                ((Command)IniciarSesionCommand)?.ChangeCanExecute();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                Validate(() => password.Length > 6,
                    "La contraseña es obligatoria");
                OnPropertyChanged();
                ((Command)IniciarSesionCommand)?.ChangeCanExecute();
            }
        }

        public ICommand IniciarSesionCommand => iniciarSesionCommand 
            ??= new Command(async ()  => await ExecuteLoad(), () => CanExecute());

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) && !HasErrors;
        }

        private async Task ExecuteLoad()
        {
            ((Command)IniciarSesionCommand)?.ChangeCanExecute();

            await Task.Delay(10000);

            ((Command)IniciarSesionCommand)?.ChangeCanExecute();
        }
    }
}