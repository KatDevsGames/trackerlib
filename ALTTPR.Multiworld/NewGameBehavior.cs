using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ALTTPR.Multiworld
{
    public class NewGameBehavior : WebSocketBehavior
    {
        [NotNull] private readonly WebSocketServer _socket;

        [NotNull] private readonly Dictionary<Guid, GameState> _games;

        public NewGameBehavior([NotNull] WebSocketServer socket, [NotNull] Dictionary<Guid, GameState> games)
        {
            _socket = socket;
            _games = games;
        }

        protected override async Task OnMessage([NotNull] MessageEventArgs e)
        {
            NewGameRequestBlock request = JsonConvert.DeserializeObject<NewGameRequestBlock>(e.Text?.ReadToEnd());

            Guid guid = Guid.NewGuid();
            _games.Add(guid,new GameState());

            _socket.AddWebSocketService($"games/{guid.ToString().ToLowerInvariant()}", () => new GameHandlerBehavior(_socket, _games, guid));

            GameInitBlock response = new GameInitBlock(request.Name, guid);
            await ((Send(JsonConvert.SerializeObject(response, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, ReferenceLoopHandling = ReferenceLoopHandling.Serialize}))) ?? Task.Delay(0));
        }
    }
}
