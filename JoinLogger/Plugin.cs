using Exiled.API.Features;
using System;
using JoinLogger.Handlers;

namespace JoinLogger
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "JoinLogger";
        public override string Author => "thecroshel";
        public override Version Version => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(8, 9, 11);

        private EventHandlers eventHandlers;

        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Player.Verified += eventHandlers.OnPlayerVerified;
            Exiled.Events.Handlers.Player.Destroying += eventHandlers.OnPlayerDestroying;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Verified -= eventHandlers.OnPlayerVerified;
            Exiled.Events.Handlers.Player.Destroying -= eventHandlers.OnPlayerDestroying;
            eventHandlers = null;

            base.OnDisabled();
        }
    }
}