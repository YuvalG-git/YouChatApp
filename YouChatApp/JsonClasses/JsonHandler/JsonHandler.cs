using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp.JsonClasses.JsonHandler
{
    internal class JsonHandler
    {
        public static string GetJsonFromString(EnumHandler.CommunicationMessageID_Enum enumType, object obj)
        {
            JsonObject jsonObject = new JsonObject(enumType, obj);
            string JsonString = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            return JsonString;
        }
        public static JsonObject GetStringFromJson(string jsomString)
        {
            JsonObject jsonObject = JsonConvert.DeserializeObject<JsonObject>(jsomString, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Binder = new NamespaceAdjustmentBinder(),
                Converters = { new EnumConverter<EnumHandler.CommunicationMessageID_Enum>() }
            });
            return jsonObject;
        }
        public static EnumHandler.CommunicationMessageID_Enum GetMessageTypeOfCommunicationMessageID_Enum(JsonObject jsonObject)
        {
            EnumHandler.CommunicationMessageID_Enum messageType = (EnumHandler.CommunicationMessageID_Enum)jsonObject.MessageType;
            return messageType;
        }

    }
}
