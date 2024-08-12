using Exiled.API.Features;
using System;

namespace JoinLogger
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "JoinLogger";
        public override string Author => "thecroshel";
        public override Version RequiredExiledVersion => new Version(8, 4, 3); // This requires the System namespace
        public override string Prefix => "JoinLogger";

        public EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            base.OnEnabled();

            EventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Player.Joined += EventHandlers.OnPlayerJoined;
            Exiled.Events.Handlers.Player.Left += EventHandlers.OnPlayerLeft;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            Exiled.Events.Handlers.Player.Joined -= EventHandlers.OnPlayerJoined;
            Exiled.Events.Handlers.Player.Left -= EventHandlers.OnPlayerLeft;
            EventHandlers = null;
        }
    }
}