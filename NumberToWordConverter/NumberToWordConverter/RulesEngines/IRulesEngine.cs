namespace NumberToWordConverter.RulesEngines
{
    public interface IRulesEngine<Input, Output>
    {
        Output ProcessItem(Input item);
    }
}
