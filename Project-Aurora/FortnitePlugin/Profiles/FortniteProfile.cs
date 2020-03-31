using Aurora.Devices;
using Aurora.EffectsEngine.Animations;
using Aurora.Settings;
using Aurora.Settings.Layers;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using Aurora.Profiles.Fortnite.Layers;

namespace Aurora.Profiles.Fortnite
{

    public class FortniteProfile : ApplicationProfile {

        public FortniteProfile() : base() { }

        public override void Reset() {
            base.Reset();

            // Big thanks to @Ant on the Aurora Discord for creating this default profile :)

            Layers = new ObservableCollection<Layer> {
                new Layer("Explosion", new FortniteBurnLayerHandler())
            };
        }
    }
}
