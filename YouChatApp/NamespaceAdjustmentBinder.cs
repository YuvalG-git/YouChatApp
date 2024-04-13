using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    public class NamespaceAdjustmentBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            // Replace "YouChatApp" with "YouChatServer" in the type name
            string adjustedTypeName = typeName.Replace("YouChatServer", "YouChatApp");
            return Type.GetType(adjustedTypeName);
        }
    }
}
