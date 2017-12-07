using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using vmail.Models;
using vmail.Util;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class CreateEmailAddressPage : Page
    {
        public CreateEmailAddressPage()
        {
            this.InitializeComponent();
        }

        private async void btnCreateEmailAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
                EmailAddress emailAddress = new EmailAddress();
                emailAddress.email = txtEmailAddress.Text.ToString();
                await emailAddress.save();
                SessionHelper.setCurrentEmailAddress(emailAddress);
                Frame.Navigate(typeof(UnreadMailsPage));
            }
            catch (Exception)
            {
                Frame.Navigate(typeof(MainPage));
            }

        }
    }
}
