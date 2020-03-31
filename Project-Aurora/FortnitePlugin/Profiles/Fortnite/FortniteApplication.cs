using Aurora.Settings;
using Aurora.Settings.Layers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Aurora.Profiles.Postman.Layers;

namespace Aurora.Profiles.Postman {

    public class Postman : Application {

        public Postman() : base(new LightEventConfig {
            Name = "Postman",
            ID = "Postman",
            ProcessNames = new[] { "postman.exe" },
            ProfileType = typeof(PostmanProfile),
            OverviewControlType = typeof(Control_Postman),
            GameStateType = typeof(GameState_Postman),
            Event = new GameEvent_Generic(),
            IconURI = "Resources/Postman.png"
        }) {
            var extra = new List<LayerHandlerEntry> {
                new LayerHandlerEntry("ShootingLayer", "Shooting Layer", typeof(ShootingLayerHandler)),
                new LayerHandlerEntry("ExplosionLayer", "Explosion Layer", typeof(ExplosionLayerHandler)),
                new LayerHandlerEntry("KilledLayer", "Player killed Layer", typeof(PlayerKilledLayerHandler)),
                new LayerHandlerEntry("HarvestLayer", "Harvest Layer", typeof(HarvestLayerHandler)),
                new LayerHandlerEntry("BuildingLayer", "Building Layer", typeof(BuildingLayerHandler)),
                new LayerHandlerEntry("GlidingLayer", "Gliding Layer", typeof(GlidingLayerHandler)),
                new LayerHandlerEntry("StormLayer", "Storm Layer", typeof(StormLayerHandler)),
                new LayerHandlerEntry("EnemyKilledLayer", "Enemy Killed Layer", typeof(EnemyKilledLayerHandler)),
            };

            Global.LightingStateManager.RegisterLayerHandlers(extra, false);

            foreach (var entry in extra)
            {
                Config.ExtraAvailableLayers.Add(entry.Key);
            }
        }
    }
}
