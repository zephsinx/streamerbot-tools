namespace streamerbot_tools;

/// <summary>
/// Methods from CPH to avoid build errors.
/// </summary>
public static class CPH
{
    /// <summary>
    /// Set local argument
    /// </summary>
    /// <param name="argumentName"></param>
    /// <param name="argumentValue"></param>
    public static void SetArgument(string argumentName, object argumentValue)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get Global variable
    /// </summary>
    /// <param name="varName"></param>
    /// <param name="persisted"></param>
    public static T GetGlobalVar<T>(string varName, bool persisted = true)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Set Global variable
    /// </summary>
    /// <param name="varName"></param>
    /// <param name="value"></param>
    /// <param name="persisted"></param>
    public static T SetGlobalVar<T>(string varName, object value, bool persisted = true)
    {
        throw new NotImplementedException();
    }
}