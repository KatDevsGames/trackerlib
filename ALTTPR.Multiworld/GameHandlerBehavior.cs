using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ALTTPR.Multiworld
{
    public class GameHandlerBehavior : WebSocketBehavior
    {
        [NotNull] private readonly WebSocketServer _socket;

        [NotNull] private readonly Dictionary<Guid, GameState> _games;

        private readonly Guid _guid;

        public GameHandlerBehavior([NotNull] WebSocketServer socket, [NotNull] Dictionary<Guid, GameState> games, Guid guid)
        {
            _socket = socket;
            _games = games;
            _guid = guid;
        }

        protected override async Task OnMessage([NotNull] MessageEventArgs e)
        {
            string messageText = e.Text.ReadToEnd();
            ISerializable message = JsonConvert.DeserializeObject<ISerializable>(messageText);
            if (message is PlayerUpdate) { await _socket.WebSocketServices.Broadcast(messageText); }
        }
    }
}