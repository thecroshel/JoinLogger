using Exiled.Events.EventArgs;
using Exiled.API.Features;
using System;
using System.IO;
using Exiled.Events.EventArgs.Player;

namespace JoinLogger.Handlers
{
    public class EventHandlers
    {
        private readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JoinLogs.txt");

        public void OnPlayerVerified(VerifiedEventArgs ev)
        {
            string playerIp = ev.Player.IPAddress;
            string playerInfo = $"[JOIN] Date: {DateTime.Now} | Player: {ev.Player.Nickname} | IP: {playerIp} | Steam64ID: {ev.Player.UserId}";
            LogPlayerInfo(playerInfo);
        }

        public void OnPlayerDestroying(DestroyingEventArgs ev)
        {
            string playerIp = ev.Player.IPAddress;
            string playerInfo = $"[EXIT] Date: {DateTime.Now} | Player: {ev.Player.Nickname} | IP: {playerIp} | Steam64ID: {ev.Player.UserId}";
            LogPlayerInfo(playerInfo);
        }

        private void LogPlayerInfo(string info)
        {
            try
            {
                File.AppendAllText(logFilePath, info + Environment.NewLine);
                Log.Info($"Logged: {info}");
            }
            catch (Exception e)
            {
                Log.Error($"Failed to log player info: {e}");
            }
        }
    }
}