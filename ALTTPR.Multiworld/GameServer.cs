using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using WebSocketSharp.Server;

namespace ALTTPR.Multiworld
{
    public class GameServer
    {
        [NotNull] private readonly WebSocketServer _socket = new WebSocketServer();

        [NotNull] private readonly Dictionary<Guid, GameState> _games = new Dictionary<Guid, GameState>();

        public GameServer()
        {
            _socket.AddWebSocketService("newGame", () => new NewGameBehavior(_socket, _games));
            _socket.Start();
        }
    }
}
