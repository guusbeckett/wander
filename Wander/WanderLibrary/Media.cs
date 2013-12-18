using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib.Media
{
    [global::ProtoBuf.ProtoContract(Name = @"Media")]
    public class Media : global::ProtoBuf.IExtensible
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Filelocation", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string fileLocation { get; set; }
        
        public Media(Type type, string fileLocation)
        {
            fileLocation = "";
        }


        [global::ProtoBuf.ProtoContract(Name = @"Type")]
        public enum Type
        {
            [global::ProtoBuf.ProtoEnum(Name=@"Audio", Value=0)]
            AUDIO,
            [global::ProtoBuf.ProtoEnum(Name = @"Video", Value = 1)]
            VIDEO,
            [global::ProtoBuf.ProtoEnum(Name = @"Photo", Value = 2)]
            PHOTO
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing) { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
} 