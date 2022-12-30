using Newtonsoft.Json;

namespace streamerbot_tools.GrowYourFurby;

public class CPHInline
{
    // Note: Delete this line if copying directly into Streamer.bot
    private readonly Dictionary<string, object> args = new();

    public bool Execute()
    {
        string username = args["user"]?.ToString() ?? string.Empty;
        string filePath = args["filePath"]?.ToString() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(username))
        {
            CPH.SetArgument("errorMsg", "User cannot be empty");
            return false;
        }

        var furbySizes = new Dictionary<string, int>();

        if (!File.Exists(filePath))
        {
            furbySizes.Add(username, 1);

            // File.Create(filePath);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(furbySizes));

            CPH.SetArgument("furbySize", 1);
            return true;
        }

        string fileContents = File.ReadAllText(filePath);
        furbySizes = JsonConvert.DeserializeObject<Dictionary<string, int>>(fileContents) ?? new Dictionary<string, int>();

        if (furbySizes.TryGetValue(username, out int furbySize))
        {
            furbySize += 1;
            furbySizes[username] = furbySize;
        }
        else
        {
            furbySize = 1;
            furbySizes.Add(username, furbySize);
        }

        File.WriteAllText(filePath, JsonConvert.SerializeObject(furbySizes));

        CPH.SetArgument("furbySize", furbySize);

        return true;
    }
}