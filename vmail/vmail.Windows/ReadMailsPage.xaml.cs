﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.WindowsAzure.MobileServices;
using vmail.Models;
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
    public sealed partial class ReadMailsPage : Page
    {
        public ReadMailsPage()
        {
            this.InitializeComponent();
            this.loadUnreadMails();

        }

        public async void loadUnreadMails()
        {
            EmailAddress emailAddress = SessionHelper.getCurrentEmailAddress();
            try
            {
                MobileServiceCollection<Mail, Mail> unreadMail = await Mail.getReadMail(emailAddress);
                mailList.ItemsSource = unreadMail;
            }
            catch (Exception)
            {

            }
        }

        private void btnNewMail_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateMailPage));
        }

        private void btnChangeEmailAddress_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateEmailAddressPage));
        }

        private void btnUnreadMails_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UnreadMailsPage));
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel stackPanel = (StackPanel)sender;
            Mail mail = stackPanel.DataContext as Mail;

            Frame.Navigate(typeof(ReadMailPage), mail);
        }
    }
}