using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace ALTTPR.Multiworld
{
    [Serializable]
    public class PlayerUpdate : ISerializable
    {
        [NotNull] public PlayerIdentity Sender { get; }

        [CanBeNull] public PlayerIdentity Recipient { get; set; }

        public UpdateType Type { get; }

        public ushort Message { get; set; }

        public GameState SenderState { get; set; }

        public enum UpdateType : byte
        {
            ItemGot = 0,
            ConsumableUsed = 1,
            MoneySpent = 2,
            DamageTaken = 3,
            PlayerDied = 4,
            PlayerWon = 5,
            PlayerForfeited = 6,
            PlayerSQ = 7
        }

        public PlayerUpdate([NotNull] PlayerIdentity sender, UpdateType type)
        {
            Sender = sender;
            Type = type;
        }

        public PlayerUpdate([NotNull] SerializationInfo info, StreamingContext context)
        {
            Sender = info.GetValue("sender", typeof(PlayerIdentity)) as PlayerIdentity ??
                     throw new SerializationException();
            Recipient = info.GetValue("recipient", typeof(PlayerIdentity)) as PlayerIdentity;
            Message = info.GetUInt16("message");
            SenderState = info.GetValue("senderState", typeof(GameState)) as GameState;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("sender", Sender);
            info.AddValue("recipient", Recipient);
            info.AddValue("message", Message);
            info.AddValue("senderState", SenderState);
        }
    }
}
