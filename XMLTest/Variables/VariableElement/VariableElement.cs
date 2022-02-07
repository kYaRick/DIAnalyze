using System;
using System.Collections.Generic;
using System.Linq;

using CNTDLYCalculator.Log;

namespace CNTDLYCalculator.DesignSpace.VariableScope
{
    internal class VariableElement
    {
        public string ElementName { get; private set; }
        public List<VariableField> VariableFields { get; private set; } = new List<VariableField>();

        public VariableElement(string elementName)
        {
            SetElementName(elementName, true);
        }
        public void SetElementName(string elementName, bool isRewrite=true)
        {
            if (string.IsNullOrWhiteSpace(ElementName) || isRewrite)
            {
                ElementName = elementName;
            } 
            else
            {
                var exception = new Exception("Variable element name error.");
                exception.Data.Add("Element name in object", ElementName);
                exception.Data.Add("Element name for write", elementName);
                exception.Data.Add("Rewrite flag status", isRewrite);

                Logger.WriteToLog(exception);
                throw exception;
            }
        }
        public void AddField (VariableField variableField)
        {
            if (VariableFields?.Any(el => el.FieldName.Equals(variableField.FieldName)) ?? false)
            {
                var exception = new Exception("Duplicate field found in error table.");
                exception.Data.Add("Field name", variableField.FieldName);
                Logger.WriteToLog(exception);
            }
            else
            {
                VariableFields.Add(variableField);
            }
        }
    }
}
