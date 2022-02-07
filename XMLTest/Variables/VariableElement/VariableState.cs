using System;
using System.Linq;

using CNTDLYCalculator.Log;

namespace CNTDLYCalculator.DesignSpace.VariableScope
{
    internal class VariableState
    {
        public string Value { get; private set; } = "";
        public float Min { get; private set; } = float.MaxValue;
        public float Typ { get; private set; } = float.MaxValue;
        public float Max { get; private set; } = float.MaxValue;

        public VariableState (string value)
        {
            Value = value;
        }
        public VariableState (string value, float[] stateValuesVariable) : this (value)
        {
            Min = stateValuesVariable[0];
            Typ = stateValuesVariable[1];
            Max = stateValuesVariable[2];
        }

        public float[] GetVariablesArray()
        {
            float[] ArrVarialbes = {Min, Typ, Max};

            if (ArrVarialbes.Contains(float.MaxValue))
            {
                throw _formingException("Something variable value was not detected.");
            }
            else
            {
                return ArrVarialbes;
            }
        }
        public void SetVariablesArray(float min, float typ, float max)
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw _formingException("State \"Value\" was not specificated.");
            }
            else
            {
                Min = min; Typ = typ; Max = max;
            }
        }
        public override string ToString()
        {
            return $"Value: {Value};" +
                $"\t{Variables.RANGEOFNAME[0]}: {Min};" +
                $"\t{Variables.RANGEOFNAME[1]}: {Typ};" +
                $"\t {Variables.RANGEOFNAME[2]}: {Max}\n";
        }
        private Exception _formingException(string message = "")
        {
            Exception exception = new Exception(message);
            exception.Data.Add(Variables.RANGEOFNAME[0], Min);
            exception.Data.Add(Variables.RANGEOFNAME[1], Typ);
            exception.Data.Add(Variables.RANGEOFNAME[2], Max);
            Logger.WriteToLog(exception);
            return exception;
        }
    }
}
