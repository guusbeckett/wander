using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    [global::ProtoBuf.ProtoContract(Name = @"Language")]
    public class Language : global::ProtoBuf.IExtensible
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string name { get; set; }
        
        public Language(string name)
        {
            this.name = name;
        }

        public string getLanguage()
        {
            return name;
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing) { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
