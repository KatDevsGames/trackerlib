using System;
using System.Runtime.Serialization;

namespace ALTTPR.Multiworld
{
    [Serializable]
    public class PlayerIdentity : IEquatable<PlayerIdentity>, ISerializable
    {
        // ReSharper disable once MemberCanBeProtected.Global
        public PlayerIdentity(SerializationInfo info, StreamingContext context)
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        public bool Equals(PlayerIdentity other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) { return false; }
            if (ReferenceEquals(this, obj)) { return true; }
            if (obj.GetType() != typeof(PlayerIdentity)) { return false; }
            return Equals((PlayerIdentity)obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
