namespace LogStandert
{
    public class LocalConsoleWrite : ILocalWrite
    {
        static public LocalConsoleWrite Singleton;
        static LocalConsoleWrite() { Singleton = new LocalConsoleWrite(); }
       
        private LocalConsoleWrite() { }

        public void Write(string txt)
        {
            Console.WriteLine(txt);
        }
    }
}
