using System.Diagnostics;
using System.Timers;
using LahkLeDiscord;
using Timer = System.Timers.Timer;

namespace LahkLeScryARK.ScryARK;

public partial class ScryARK
{
    private static DiscordBot.Instance instance = new();
    private static Timer aTimer;

    public static void Lifecycle()
    {
        aTimer = new Timer(1);

        aTimer.Elapsed += OnElapsed;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;

        GC.KeepAlive(aTimer);
        Debug.WriteLine("ScryARK:Main");
    }

    private static void OnElapsed(object source, ElapsedEventArgs e)
    {
        Debug.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
        instance.Tick();
    }

    protected override void OnInitialized()
    {
        Lifecycle();
        Debug.WriteLine("ScryARK:OnInitialized");
    }
}
