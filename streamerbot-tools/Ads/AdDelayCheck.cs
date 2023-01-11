using Newtonsoft.Json;

namespace streamerbot_tools.Ads;

public class AdDelayCheck
{
    private readonly Dictionary<string, object?> args = new();

    public bool Execute()
    {
        // Get current ad play time
        DateTimeOffset thisTime = DateTimeOffset.Now;

        // Set output date format const
        const string dateFormat = "dddd, MMMM dd, yyyy h:mm:ss tt";
        const string lastTimeArg = "lastTime";
        const string timeMessageArg = "timeMessage";
        string timeString;

        // If lastTime is not a valid date, use thisTime instead
        if (!DateTimeOffset.TryParse(args[lastTimeArg]?.ToString(), out DateTimeOffset lastTime))
        {
            timeString = thisTime.ToString(dateFormat);
            // Return
            CPH.SetArgument(lastTimeArg, timeString);
            CPH.SetArgument(timeMessageArg, $"{timeString}: First ad.");
            return true;
        }

        timeString = lastTime.ToString(dateFormat);
        TimeSpan timeDiff = thisTime - lastTime;
        int minutes = (int)Math.Truncate(timeDiff.TotalMinutes);
        double secondsFraction = timeDiff.TotalMinutes - minutes;
        int seconds = (int)Math.Floor(secondsFraction * 60);

        CPH.SetArgument(lastTimeArg, timeString);
        CPH.SetArgument(timeMessageArg, $"{timeString}: {minutes}m {seconds}s (or {(int)timeDiff.TotalSeconds} seconds) since last ad.");

        return true;
    }
}