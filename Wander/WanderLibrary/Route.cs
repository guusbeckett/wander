using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    [global::ProtoBuf.ProtoContract(Name = @"Route")]
    public class Route : global::ProtoBuf.IExtensible
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string name { get; set; }
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"Waypoints", DataFormat = global::ProtoBuf.DataFormat.Group)]
        public List<Waypoint> waypoints { get; set; }
        [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name = @"totalDistance", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
        public double totalDistance { get; set; }
        [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name = @"distanceLeft", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
        public double distanceLeft { get; set; }
        [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name = @"lastLocation", DataFormat = global::ProtoBuf.DataFormat.Group)]
        public Location lastLocation { get; set; }
        
        
        public Route(string name, List<Waypoint> waypoints, double totalDistance)
        {
            this.name = name;
            this.totalDistance = totalDistance;
            this.waypoints = waypoints;
        }

        public double routeLeft()
        {
            return distanceLeft;
        }

        public double routeWalked()
        {
            return totalDistance - distanceLeft;
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing) { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); } 

    }
}
