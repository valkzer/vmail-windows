﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class CreateMailPage : Page
    {

        public CreateMailPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await loadEmailAddressOptions();
            
            if(e.Parameter != null)
            {
                Mail mail = (Mail)e.Parameter;
                txtSubject.Text = "RE:" + mail.subject;
                cboTo.SelectedItem = mail.from;
            }            
        }

        private async Task loadEmailAddressOptions()
        {
            MobileServiceCollection<EmailAddress, EmailAddress> emailAddresses = await EmailAddress.getAll();
            foreach (EmailAddress emailAddress in emailAddresses)
            {
                cboTo.Items.Add(emailAddress.email);
            }
        }
    }
}
