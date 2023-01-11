using Newtonsoft.Json;

namespace streamerbot_tools.GrowYourFurby;

public class GrowYourFurby
{
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

        if (!File.Exists(filePath))
        {
            CPH.SetArgument("errorMsg", $"File with path '{filePath}' does not exist");
            return false;
        }

        string fileContents = File.ReadAllText(filePath);
        Dictionary<string, int> furbySizes = JsonConvert.DeserializeObject<Dictionary<string, int>>(fileContents) ?? new Dictionary<string, int>();
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