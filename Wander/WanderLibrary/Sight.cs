using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanderLib
{
    [global::ProtoBuf.ProtoContract(Name = @"Sight")]
    public class Sight : Waypoint, global::ProtoBuf.IExtensible
    {
        [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name = @"Media", DataFormat = global::ProtoBuf.DataFormat.Group)]
        public Dictionary<Media.Media.Type, Media.Media> media { get; set; }
        [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name = @"Name", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public string name { get; set; }
        [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name = @"isVisited", DataFormat = global::ProtoBuf.DataFormat.Default)]
        public Boolean isVisited;
        

        public Sight(Dictionary<Media.Media.Type, Media.Media> media, string name, string information, Location location):base(information, location)
        {
            this.media = media;
            this.name = name;
            this.information = information;
            this.location = location;
            isVisited = false;
        }
        public Sight(Dictionary<Media.Media.Type, Media.Media> media, string name, string information, Location location, Boolean isVisited):base(information,location)
        {
            this.media = media;
            this.name = name;
            this.information = information;
            this.location = location;
            this.isVisited = isVisited;
        }
        
        public void setToVisited()
        {
            isVisited = true;
        }
        private global::ProtoBuf.IExtension extensionObject;
        global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing) { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }

    }
}
