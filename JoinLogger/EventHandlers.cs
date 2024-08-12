using Exiled.Events.EventArgs;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace JoinLogger
{
    public class EventHandlers
    {
        public void OnPlayerJoined(JoinedEventArgs ev)
        {
            string steam64Id = ev.Player.UserId.Replace("@steam", "");
            Log.Info($"{ev.Player.Nickname} ({steam64Id}) has joined the server.");
        }

        public void OnPlayerLeft(LeftEventArgs ev)
        {
            string steam64Id = ev.Player.UserId.Replace("@steam", "");
            Log.Info($"{ev.Player.Nickname} ({steam64Id}) has left the server.");
        }
    }
}