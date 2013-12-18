using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    [global::ProtoBuf.ProtoContract(Name = @"Location")]
    public class Location : global::ProtoBuf.IExtensible
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Latitude", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string latitude { get; set; }
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"Longitude", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string longitude { get; set; }
        
        
        public Location(string latitude, string longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing) { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }

    }
}
