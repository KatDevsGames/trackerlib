using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace ALTTPR.Multiworld
{
    [Serializable]
    public class NewGameRequestBlock : ISerializable
    {
        [NotNull] public string Name { get; }

        public NewGameRequestBlock([NotNull] string name) => Name = name;

        // ReSharper disable once MemberCanBeProtected.Global
        public NewGameRequestBlock([NotNull] SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("name") ?? string.Empty;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name);
        }
    }
}
