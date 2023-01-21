using System.Net;
using System.Net.Sockets;
using str = System.String;

namespace LogStandert
{
    public class CreateLog
    {
        #region static
        public static ILocalWrite iLocalWrite;

        private static int _keyForLogs = -1;
        private static string? LocalIP = null;

        private static string GetLocalIPAddress()
        {
            if (LocalIP != null)
                return LocalIP;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return LocalIP = ip.ToString();

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        #endregion

        #region value
        private str newKeyForLogs { get => (++KeyLastLog).ToString(); }
        private str timeNow { get => DateTime.Now.ToLongTimeString(); }
        private LOG _log;

        public int KeyLastLog
        {
            get => _keyForLogs;
            private set => _keyForLogs = value;/*запись стека запроса _idKeyLogs*/
        }
        public LOG Log { get => _log; private set => _log = value; }
        #endregion

        public CreateLog(str type, str header, str text_Stack = "Stack")
            => Create(type, header, text_Stack);

        private void Create(str type, str header, str text_Stack)
        {
            try
            {
                Log = new LOG(
                    GetLocalIPAddress(), newKeyForLogs, timeNow,
                    type, header, text_Stack);
            }
            catch (Exception ex)
            {
                Log = null;
                iLocalWrite?.Write($"{timeNow}\t\t{ex.Message}");
            }
        }

        public override str ToString() => Log.ToString();
    }
}
