using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.Helper
{
    public static class SendMessageToTelegram
    {
        public static void SendMessageToTelegrams(string message)
        {
            try
            {
                string urlString = $"https://api.telegram.org/bot6888531607:AAFvGMciQkb6eHP74RYojBYtwryYJqWTloQ/sendMessage?chat_id=1650815455&text={message}";
                WebClient webClient = new WebClient();
                string response = webClient.DownloadString(urlString);
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Telegram mesajı gönderirken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
