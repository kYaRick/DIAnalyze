using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CNTDLYCalculator.Log;

namespace CNTDLYCalculator.DesignSpace.VariableScope
{
    internal class VariableField
    {
        public List<VariableState> VariableStates { get; set; } = new List<VariableState>();
        public string FieldName { get; private set; } = "";
        public VariableField(string fieldName)
        {
            FieldName = fieldName;
        }
        public void SetFieldName(string fieldName, bool isRewrite = true)
        {
            if (string.IsNullOrWhiteSpace(FieldName) || isRewrite)
            {
                FieldName = fieldName;
            }
            else
            {
                var exception = new Exception("Variable field name error.");
                exception.Data.Add("Field name in object", FieldName);
                exception.Data.Add("Field name for write", fieldName);
                exception.Data.Add("Rewrite flag status", isRewrite);

                Logger.WriteToLog(exception);
                throw exception;
            }
        }
        public void AddState(string stateValue, float[] stateValuesVariable)
        {
            if (VariableStates.Any(variableState => variableState.Value == stateValue))
            {
                StringBuilder exceptionMessage = new StringBuilder($"State info:\n\tvalue: {stateValue}");
                for (byte i = 0; i<Variables.VARIABLEARRLEN; i++)
                {
                   exceptionMessage.Append($"\t{Variables.RANGEOFNAME[i]}: {stateValuesVariable[i]}");
                }

                var ex = _formingException(exceptionMessage.ToString());
                Logger.WriteToLog(ex);
                throw ex;
            }
            else
            {
                VariableState variableState = new VariableState(stateValue, stateValuesVariable);
                VariableStates.Add(variableState);
            }
        }

        private Exception _formingException(string message)
        {
            return new Exception(message);
        }
    }
}
