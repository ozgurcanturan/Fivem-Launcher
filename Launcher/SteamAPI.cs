﻿using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace Launcher
{
    public static class SteamManager
    {
        public static string GetSteamID3()
        {
            try
            {
                return Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Valve")?.OpenSubKey("Steam")?.OpenSubKey("ActiveProcess")?.GetValue("ActiveUser")?.ToString() ?? "0";
            }
            catch
            {
                return "0";
                // ignored
            }
        }

        public static bool IsRunning()
        {
            return Process.GetProcessesByName("steam").Any();
        }
    }

    public partial class SteamApi
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("players")]
        public Player[] Players { get; set; }
    }

    public partial class Player
    {
        [JsonProperty("steamid")]
        public string Steamid { get; set; }

        [JsonProperty("personaname")]
        public string Personaname { get; set; }

        [JsonProperty("profileurl")]
        public string Profileurl { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("avatarfull")]
        public string Avatarfull { get; set; }
    }
}