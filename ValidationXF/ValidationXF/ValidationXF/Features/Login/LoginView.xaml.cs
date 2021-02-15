namespace ValidationXF.Features
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            (BindingContext as LoginViewModel).ErrorsChanged += ViewModel_ErrorsChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            (BindingContext as LoginViewModel).ErrorsChanged -= ViewModel_ErrorsChanged;
        }

        void ViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            bool propHasErrors = ((BindingContext as LoginViewModel).GetErrors(e.PropertyName)
                as List<string>)?.Any() == true;

            var vm = (BindingContext as LoginViewModel);

            switch (e.PropertyName)
            {
                case nameof(vm.Email):
                    email.TextColor = propHasErrors
                        ? Color.Red : Color.Black;
                    break;
                case nameof(vm.Password):
                    //password.TextColor = propHasErrors
                    //    ? Color.Red : Color.Black;

                    VisualStateManager.GoToState(password, propHasErrors ? "Invalid" : "Valid");
                    break;
                Default: break;
            }
        }
    }
}