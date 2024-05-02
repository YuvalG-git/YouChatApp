using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace YouChatApp
{
    /// <summary>
    /// The "NamespaceAdjustmentBinder" class is a custom serialization binder that adjusts type names by replacing "YouChatServer" with "YouChatApp".
    /// </summary>
    public class NamespaceAdjustmentBinder : SerializationBinder
    {
        /// <summary>
        /// The method overrides the BindToType method to adjust the type name by replacing "YouChatServer" with "YouChatApp".
        /// </summary>
        /// <param name="assemblyName">The assembly name of the type.</param>
        /// <param name="typeName">The original type name.</param>
        /// <returns>The adjusted Type object.</returns>
        public override Type BindToType(string assemblyName, string typeName)
        {
            // Replace "YouChatServer" with "YouChatApp" in the type name
            string adjustedTypeName = typeName.Replace("YouChatServer", "YouChatApp");
            return Type.GetType(adjustedTypeName);
        }
    }
}
