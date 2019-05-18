using System;

namespace DataGetter.Entities
{
    /// <summary>
    /// V2ray的实体
    /// </summary>
    public class V2RayEntity
    {
        public string LinkType { get; set; }

        public string User { get; set; }

        public long DataSize { get; set; }

        public string UserType { get; set; }
    }
}
