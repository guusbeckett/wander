using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WanderLib
{
    [global::ProtoBuf.ProtoContract(Name = @"Waypoint"), global::ProtoBuf.ProtoInclude(20, typeof(Sight))]
    public class Waypoint : global::ProtoBuf.IExtensible
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Filelocation", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string information { get; set; }
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"Location", DataFormat = global::ProtoBuf.DataFormat.Group)]
        public Location location { get; set; }
        

        public Waypoint(string information, Location location)
        {
            this.information = information;
            this.location = location;
        }

        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing) { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
