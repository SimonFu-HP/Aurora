using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Profiles;
using Aurora.Profiles.Fortnite.Layers;
using Aurora.Settings;
using Aurora.Profiles.Fortnite;

namespace FortnitePlugin
{
    public class PluginMain : IPlugin
    {
        public string ID { get; private set; } = "FortnitePlugin";

        public string Title { get; private set; } = "Fortnite Plugin";

        public string Author { get; private set; } = "aiqiang.fu@hp.com";

        public Version Version { get; private set; } = new Version(0, 1);

        private IPluginHost pluginHost;

        public IPluginHost PluginHost { get { return pluginHost; }
            set {
                pluginHost = value;
                //Add stuff to the plugin manager
            }
        }

        public PluginMain()
        {
        }

        public void ProcessManager(object manager)
        {
            if (manager is LightingStateManager)
            {
                //((LightingStateManager)manager).RegisterLayerHandler(new LayerHandlerEntry("FortNightBurnLayerHandler", "FortNight explosion Layer", typeof(FortniteBurnLayerHandler)));
                ((LightingStateManager)manager).RegisterEvent(new FortniteApp{ });
            }
        }
    }
}
