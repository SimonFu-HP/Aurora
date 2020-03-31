using Aurora.Settings;
using Aurora.Settings.Layers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Aurora.Profiles.Fortnite.Layers;

namespace Aurora.Profiles.Fortnite {

    public class FortniteApp : Application {

        public FortniteApp() : base(new LightEventConfig {
            Name = "Fortnite",
            ID = "Fortnite",
            ProcessNames = new[] { "FortniteClient-Win64-Shipping.exe", "chrome.exe", "wmplayer.exe" },
            ProfileType = typeof(FortniteProfile),
            OverviewControlType = typeof(Control_Fortnite),
            GameStateType = typeof(GameState_Fortnite),
            Event = new GameEvent_Generic(),
            IconURI = "Resources/Fornite.png"
        }) {
            var extra = new List<LayerHandlerEntry> {
                new LayerHandlerEntry("FortniteExplosionLayer", "Fortnite exposion Layer", typeof(FortniteExplosionLayerHandler)),
                new LayerHandlerEntry("FortniteShootingLayer", "Fortnite shooting Layer", typeof(FortniteShootingLayerHandler)),
                new LayerHandlerEntry("FortnitePlayerKilledLayer", "Fortnite Player Killed Layer", typeof(FortnitePlayerKilledLayerHandler)),
                new LayerHandlerEntry("FortniteHarvestLayer", "Fortnite Harvest Layer", typeof(FortniteHarvestLayerHandler)),
                new LayerHandlerEntry("FortniteBuildingLayer", "Fortnite Building Layer", typeof(FortniteBuildingLayerHandler)),
                new LayerHandlerEntry("FortniteGlidingLayer", "Fortnite Gliding Layer", typeof(FortniteGlidingLayerHandler)),
                new LayerHandlerEntry("FortnitePoisonLayer", "Fortnite Poison Layer", typeof(FortnitePoisonLayerHandler)),
                new LayerHandlerEntry("FortniteEnemyKilledLayer", "Enemy Killed Layer", typeof(FortniteEnemyKilledLayerHandler)),
            };

            Global.LightingStateManager.RegisterLayerHandlers(extra, false);

            foreach (var entry in extra)
            {
                Config.ExtraAvailableLayers.Add(entry.Key);
            }
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
