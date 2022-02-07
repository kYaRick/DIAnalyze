using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

using CNTDLYCalculator.Log;

namespace CNTDLYCalculator.DesignSpace.VariableScope
{
    static class Variables
    {
        public static readonly string[] RANGEOFNAME = { "min", "typ", "max" };
        public static readonly string DEFAULTTAG = "default";
        public static readonly byte VARIABLEARRLEN = 3;
        public static List<VariableElement> Info { get; private set; } = new List<VariableElement>();
        public static void VariableTagAnalyzer(XElement variableTag, bool isCleanOldInfo)
        {
            if (isCleanOldInfo) Info.Clear();
            IEnumerable<XElement> variableElements = variableTag.Elements("element");

            foreach (XElement variableElement in variableElements)
            {
                VariableElement varElement = new VariableElement(variableElement.Attribute("name").Value);
                VariableField varField = null;
                XElement variableField = variableElement.Element("field");
                IEnumerable<XElement> variableStates;

                if (variableField == null)
                {
                    varField = new VariableField(DEFAULTTAG);
                    variableStates = variableElement.Elements("state");
                }
                else
                {
                    varField = new VariableField(variableField.Attribute("name").Value);
                    variableStates = variableElement.Element("field").Elements("state");
                }

                foreach (var variableState in variableStates)
                {
                    string[] inputArr = new string[VARIABLEARRLEN];

                    for (byte i = 0; i<VARIABLEARRLEN; i++)
                    {
                        inputArr[i] = variableState?.Attribute(RANGEOFNAME[i])?.Value;
                    }

                    bool contFlag = _TryToConvertVariable(inputArr, out float[] outputArr);

                    if (contFlag)
                    {
                        varField.AddState(variableState.Attribute("value")?.Value ?? DEFAULTTAG, outputArr);
                    }
                }

                varElement.AddField(varField);
                Info.Add(varElement);
            }
        }

        private static bool _TryToConvertVariable(string[] inputArr, out float[] outputArr)
        {
            bool convertSuccesFlag = false;
            byte inputArrLen = (byte)inputArr.Length;
            outputArr = new float[VARIABLEARRLEN];

            if (inputArrLen != VARIABLEARRLEN)
            {
                _formException("Input array length isn't equal to the default array length");
            }
            else
            {
                outputArr = new float[inputArrLen];

                for (byte i = 0; i < inputArrLen; i++)
                {
                    convertSuccesFlag = float.TryParse(inputArr[i], out outputArr[i]);
                    if (!convertSuccesFlag)
                    {
                        _formException("Convert input array error.");
                        break;
                    }
                }
            }

            return convertSuccesFlag;

            Exception _formException(string message)
            {
                var exception = new Exception(message);
                exception.Data.Add("Input array lenght", inputArrLen);
                exception.Data.Add("Default array lenght", VARIABLEARRLEN);

                string showArr = "";
                foreach (var el in inputArr)
                {
                    showArr += $"{el}\t";
                }
                showArr += "\b";

                exception.Data.Add("Array", showArr);

                Logger.WriteToLog(exception);
                return exception;
            }
        }
    }
}
