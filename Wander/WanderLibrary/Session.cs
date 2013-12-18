using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    [global::ProtoBuf.ProtoContract(Name = @"Session")]
    public class Session : global::ProtoBuf.IExtensible
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Route", DataFormat = global::ProtoBuf.DataFormat.Group)]
        public Route route { get; set; }
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"Settings", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public Settings settings { get; set; }
        [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name = @"RouteWalked", DataFormat = global::ProtoBuf.DataFormat.Group)]
        public List<Location> routeWalked { get; set; }

        public Session()
        {

        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing) { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
    }
}
