namespace CNTDLYCalculator.DesignSpace.VariableScope
{
    internal class VariableKey
    {
        internal readonly string key = "";
        internal VariableKey(string elementMode, string syncMode = "")
        {
            key = string.IsNullOrEmpty(syncMode) ? $"{elementMode.Trim()}" : $"{elementMode.Trim()}:{syncMode.Trim()}";
        }
    }
}
