using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using WebSocket4Net;

namespace ALTTPR.Multiworld
{
    public class GameClient
    {
        [NotNull] private WebSocket _ws;

        [NotNull] private string GameName { get; set; }

        private Guid GameID { get; set; }

        [NotNull] private readonly string _server_url;

        [NotNull] private readonly GameStateReaderWriter _reader_writer;

        [NotNull] private readonly GameStateProcessor _processor;

        [NotNull] private PlayerIdentity LocalPlayer { get; }

        public GameClient([NotNull] string serverURL, [NotNull] GameStateReaderWriter readerWriter, [NotNull] PlayerIdentity localPlayer, [NotNull] string gameName)
        {
            _server_url = serverURL;
            _reader_writer = readerWriter;
            _processor = new GameStateProcessor(_reader_writer);
            LocalPlayer = localPlayer;
            Connect($"{_server_url}/newGame");
            Send(new NewGameRequestBlock(gameName));
        }

        private async void _ws_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                ISerializable block = JsonConvert.DeserializeObject<ISerializable>(e.Message);
                if (block is GameInitBlock gBlock)
                {
                    GameName = gBlock.Name;
                    GameID = gBlock.Guid;
                    Connect($"{_server_url}/{GameID.ToString().ToLowerInvariant()}");
                }
                else if ((block is PlayerUpdate pUpdate) &&
                         ((pUpdate.Recipient == null) || (pUpdate.Recipient.Equals(LocalPlayer))))
                {
                    switch (pUpdate.Type)
                    {
                        case PlayerUpdate.UpdateType.ItemGot:
                            GameState.Item item = (GameState.Item) pUpdate.Message;
                            await _processor.ItemGet(item);
                            break;
                        default:
                            return;
                    }
                }
            }
            catch { /**/ }
        }

        public GameClient([NotNull] string serverURL, Guid gameGuid, [NotNull] PlayerIdentity localPlayer)
        {
            LocalPlayer = localPlayer;
            Connect($"{serverURL}/{gameGuid.ToString().ToLowerInvariant()}");
        }

        private void Connect([NotNull] string url)
        {
            try { _ws?.Dispose(); }
            catch { /**/ }
            _ws = new WebSocket(url) { AutoSendPingInterval = 15, EnableAutoSendPing = true };
            _ws.AutoSendPingInterval = 15;
            _ws.EnableAutoSendPing = true;
            _ws.MessageReceived += _ws_MessageReceived;
            _ws.Open();
        }

        private void Send(ISerializable message)
        {
            _ws.Send(JsonConvert.SerializeObject(message, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            }));
        }
    }
}
