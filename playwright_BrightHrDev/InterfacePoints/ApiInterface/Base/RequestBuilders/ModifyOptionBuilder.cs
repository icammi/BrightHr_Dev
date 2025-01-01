namespace playwright_newintegrationtests.InterfacePoints.ApiInterface.Base.RequestBuilders;

public class ModifyOptionBuilder
{
    private ModifyOption _modifyOption = new();

    public ModifyOptionBuilder CreateOption()
    {
        _modifyOption = new ModifyOption();
        return this;
    }

    public ModifyOptionBuilder WithOptionId(long id)
    {
        _modifyOption.OptionId = id;
        return this;
    }

    public ModifyOptionBuilder WithResultStatus(string resultStatusText)
    {
        _modifyOption.ResultStatus = GetOptionMarketResultStatus(resultStatusText).ToString();
        return this;
    }

    public static int GetOptionMarketResultStatus(string resultStatusText)
    {
        return resultStatusText.ToLower() switch
        {
            "visible" => 1,
            "suspended" => 2,
            "hidden" => 3,
            _ => throw new InvalidOperationException($"{resultStatusText} is invalid")
        };
    }

    public ModifyOption Build()
    {
        return _modifyOption;
    }
}