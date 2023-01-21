using LogStandert;
using LogStandertBD;
using Microsoft.AspNetCore;

public class Program
{
    private static LogBD logBD;
    static Program() { logBD = new LogBD(); }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapPost("/PostCreate", (LOG log) => PostCreate(log));

        app.MapGet("/CreateRandom", () => GetCreateRandom());

        app.MapGet("/All", () => GetAllLog());

        app.MapGet("/Value={Value}", (string KeyValue) 
            => GetLog(KeyValue));

        app.MapGet("/{str}", (string str) => Console.WriteLine("\t" + str));

        app.Run("http://192.168.1.102:5178/");
    }

    #region POST
    private static void PostCreate(LOG log) => logBD.Create(log);

    #endregion

    #region GET
    private static void GetCreateRandom()
    {
        Console.WriteLine("GetCreateRandom");
        logBD.Create($"{Random(10)}", $"{Random(10)}", $"{Random(10)}");
    }

    private static string GetLog(string value)
    {
        string requests = "null";

        if (LogBD.Logs != null
            && LogBD.Logs.ContainsKey(value))
            requests = LogBD.Logs[value].ToString();

        return requests;
    }

    private static string GetAllLog()
    {
        Console.WriteLine("GetAllLog");
        string str = "";
        foreach (var item in LogBD.Logs)
            str += $"{item.Value.ToString()}\n";

        return str;
    }
    #endregion

    private static string Random(int value) => new System.Random().Next(value).ToString();
}
