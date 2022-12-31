using Newtonsoft.Json;

namespace streamerbot_tools.GrowYourFurby;

public class SetFurbyLength
{
    // Note: Delete this line if copying directly into Streamer.bot
    private readonly Dictionary<string, object> args = new();

    public bool Execute()
    {
        string username = (args["input0"]?.ToString() ?? string.Empty).TrimStart('@');
        bool parsedLength = int.TryParse(args["input1"]?.ToString(), out int newFurbySize);
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

        if (!parsedLength)
        {
            CPH.SetArgument("errorMsg", "Invalid furby length provided");
            return false;
        }

        if (newFurbySize < 0)
        {
            CPH.SetArgument("errorMsg", $"Furby length must be 0 or greater but was {newFurbySize}");
            return false;
        }

        string fileContents = File.ReadAllText(filePath);
        Dictionary<string, int> furbySizes = JsonConvert.DeserializeObject<Dictionary<string, int>>(fileContents) ?? new Dictionary<string, int>();

        if (furbySizes.TryGetValue(username, out int _))
            furbySizes[username] = newFurbySize;
        else
            furbySizes.Add(username, newFurbySize);

        File.WriteAllText(filePath, JsonConvert.SerializeObject(furbySizes));
        CPH.SetArgument("furbySize", newFurbySize);
        CPH.SetArgument("updatedUser", username);
        return true;
    }
}