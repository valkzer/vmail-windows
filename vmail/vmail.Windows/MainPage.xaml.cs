using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Credentials;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace vmail
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MobileServiceUser user { get; private set; }

        public MainPage()
        {
            InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            checkAuthenticationAndEmailAddress();
        }

        private async void checkAuthenticationAndEmailAddress()
        {
            if (await doAuth() == false)
            {
                var dialog = new MessageDialog("Authentication is required");
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
                btnAuthenticate.Visibility = Visibility.Visible;
                return;
            }

            checkHasRegisteredEmailAddress();
        }

        private async void checkHasRegisteredEmailAddress()
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string emailAddressEmail = (String)localSettings.Values["currentUserEmailAddressEmail"];
            string emailAddressId = (String)localSettings.Values["currentUserEmailAddressId"];
            bool hasRegisteredEmailAddress = emailAddressEmail != null && emailAddressId != null;

            if (hasRegisteredEmailAddress)
            {
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    Frame.Navigate(typeof(UnreadMailPage));
                });
            }
            else
            {
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    Frame.Navigate(typeof(CreateEmailAddressPage));
                });
            }
        }


        private async System.Threading.Tasks.Task<bool> doAuth()
        {
            PasswordVault vault = new PasswordVault();
            PasswordCredential credential = null;
            var provider = MobileServiceAuthenticationProvider.Facebook;
            bool success = false;
            try
            {
                credential = vault.FindAllByResource(provider.ToString()).FirstOrDefault();
            }
            catch (Exception)
            {
            }

            if (credential != null)
            {
                user = new MobileServiceUser(credential.UserName);
                credential.RetrievePassword();
                user.MobileServiceAuthenticationToken = credential.Password;
                Util.AzureHelper.MobileService.CurrentUser = user;
                success = true;
            }
            else
            {
                try
                {
                    user = await Util.AzureHelper.MobileService.LoginAsync(MobileServiceAuthenticationProvider.Facebook);
                    credential = new PasswordCredential(provider.ToString(), user.UserId, user.MobileServiceAuthenticationToken);
                    vault.Add(credential);
                    success = true;
                }
                catch (Exception)
                {
                    success = false;
                }
            }


            return success;
        }

        private void btnAuthenticate_Click(object sender, RoutedEventArgs e)
        {
            checkAuthenticationAndEmailAddress();
        }
    }
}
