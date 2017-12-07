using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using vmail.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class ReadMailPage : Page
    {
        Mail mail;

        public ReadMailPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.mail = (Mail)e.Parameter;
            try
            {
                mail.markAsRead();
            }
            catch (Exception)
            {
                var errordialog = new MessageDialog("Failed to mark message as read");
                errordialog.Commands.Add(new UICommand("OK"));
                await errordialog.ShowAsync();
            }

            txtFrom.Text = mail.from;
            txtMessage.Text = mail.message;
            txtSubject.Text = mail.subject;
        }

        private void btnReply_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateMailPage), mail);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UnreadMailsPage));
        }
    }
}
