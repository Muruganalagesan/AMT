using AMT.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace AMT.Common
{
   

    public static class XMLSerializer<Type>
    {
        
        public static Boolean DeSerializeInputs<T> (String inputPath, ref T DeserializedObject)
        {
            bool result = false;
            T objectInfo;
            try
            {
                if (File.Exists(inputPath))
                {
                    using (StreamReader xmlReader = new StreamReader(inputPath))
                    {
                        XmlSerializer xmlSerailizer = new XmlSerializer(typeof(T));

                        objectInfo = (T)xmlSerailizer.Deserialize(xmlReader);
                        if (DeserializedObject != null)
                        {
                            DeserializedObject = objectInfo; result = true;
                        }
                        else
                            AMTLogger.WriteToLog("Input passed for getting the deserailized object is empty===>DeSerializeInputs", MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
                        //log.ErrorWriter("Input passed for getting the deserailized object is empty===>DeSerializeInputs");
                    }
                }

                else
                {
                    AMTLogger.WriteToLog("DeSerializeInputs-->File not found.", MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Info );
                }
            }

            catch (Exception ex)
            {
                //TigerLog.WriteToLog(ex.Message, "DeSerializeInputs", 0, TigerLog.LogInfo.Error);

                AMTLogger.WriteToLog("DeSerializeInputs-->"+ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);

            }
            return result;

        }
        public static Boolean SerializeInputs<T> (String inputPath, T inputToSerialize)
        {
            Boolean serializeResult = false;
            try
            {
                //log.InfoWriter("SerializeInputs path:" + inputPath);

                using (StreamWriter serializewriter = new StreamWriter(inputPath, false))
                {
                    XmlSerializer xmlSerailizer = new XmlSerializer(typeof(T));
                    xmlSerailizer.Serialize(serializewriter, inputToSerialize);
                    serializeResult = true;
                }

            }
            catch (Exception ex)
            {
                AMTLogger.WriteToLog("Error in method SerializeInputs===> " + ex.Message, MethodBase.GetCurrentMethod().Name, 0, AMTLogger.LogInfo.Error);
               // log.ErrorWriter("Error in method SerializeInputs===> " + ex.Message);
                // TigerLog.WriteToLog(ex.Message, "Error in method SerializeInputs", 0, TigerLog.LogInfo.Error);
            }
            return serializeResult;
        }
    }
}
