using Newtonsoft.Json;

namespace streamerbot_tools.GrowYourFurby;

public class AddSubtractInches
{
    private readonly Dictionary<string, object> args = new();

    public bool Execute()
    {
        string username = (args["input0"]?.ToString() ?? string.Empty).TrimStart('@');
        bool parsedLength = int.TryParse(args["input1"]?.ToString(), out int inchesToAdd);
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

        string fileContents = File.ReadAllText(filePath);
        Dictionary<string, int> furbySizes = JsonConvert.DeserializeObject<Dictionary<string, int>>(fileContents) ?? new Dictionary<string, int>();
        int furbySize;
        if (furbySizes.TryGetValue(username, out int currentFurbySize))
        {
            int newFurbySize = currentFurbySize + inchesToAdd;
            if (newFurbySize < 0)
            {
                CPH.SetArgument("errorMsg", $"Final furby length must be 0 or greater but would be {newFurbySize}");
                return false;
            }

            furbySizes[username] = newFurbySize;
            furbySize = newFurbySize;
        }
        else
        {
            if (inchesToAdd < 0)
            {
                CPH.SetArgument("errorMsg", "Final furby length must be 0 or greater");
                return false;
            }

            furbySizes.Add(username, inchesToAdd);
            furbySize = inchesToAdd;
        }

        File.WriteAllText(filePath, JsonConvert.SerializeObject(furbySizes));
        CPH.SetArgument("furbySize", furbySize);
        CPH.SetArgument("updatedUser", username);
        return true;
    }
}