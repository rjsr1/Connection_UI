using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Net.Sockets;
using Connection;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        Client client;


        public MainWindow()
        {
            InitializeComponent();
            client = new Client(2004, "127.0.0.1");           
            client.StartClient();
            client.ReceiveEvent += HandleReceiveEvent;                      
        }

        void HandleReceiveEvent(object sender, Receive_Args e)
        {
            TextBoxServerResponse.AppendText(e.Message+"\n");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String s = TextBoxClientSend.Text;
            TextBoxClientSend.Clear();
            client.Send(s);            
            TextBoxSentToServer.AppendText("você disse: " + s + "\n");           

        }

        private void TextBoxServerResponse_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
        
    }


}
