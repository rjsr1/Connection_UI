using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            ThreadStart threadStart = new ThreadStart(ReceiveDataServer);
            Thread thread = new Thread(threadStart);
            thread.Start();
            //criaria aqui uma thread que ouviria o servidor enquanto o socket connected==true.E atualiza o textBox do server
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String s = TextBoxClientSend.Text;
            TextBoxClientSend.Clear();
            client.Send(s);
            client.EndMessage();
            TextBoxSentToServer.AppendText("você disse: " + s + "\n");

        }

        private void TextBoxServerResponse_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ReceiveDataServer()
        {
            //fazer melhor.......
            while (client.GetSocket().Connected)
            {
                TextBoxServerResponse.AppendText(client.GetSocketReceiveResponse());
            }
        }
    }
    
}
