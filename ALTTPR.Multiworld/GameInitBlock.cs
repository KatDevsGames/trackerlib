using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace ALTTPR.Multiworld
{
    [Serializable]
    public class GameInitBlock : ISerializable
    {
        [NotNull] public string Name { get; }

        public Guid Guid { get; }

        public GameInitBlock([NotNull] string name, Guid guid)
        {
            Name = name;
            Guid = guid;
        }

        // ReSharper disable once MemberCanBeProtected.Global
        public GameInitBlock([NotNull] SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("name") ?? string.Empty;
            Guid = (info.GetValue("guid", typeof(Guid)) as Guid?) ?? Guid.Empty;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name);
            info.AddValue("guid", Guid);
        }
    }
}
