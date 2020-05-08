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
            AllowLayer<FortniteExplosionLayerHandler>();
            AllowLayer<FortniteShootingLayerHandler>();
            AllowLayer<FortnitePlayerKilledLayerHandler>();
            AllowLayer<FortniteHarvestLayerHandler>();
            AllowLayer<FortniteBuildingLayerHandler>();
            AllowLayer<FortniteGlidingLayerHandler>();
            AllowLayer<FortnitePoisonLayerHandler>();
            AllowLayer<FortniteEnemyKilledLayerHandler>();
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
