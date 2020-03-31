using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Settings.Layers;
using Aurora.EffectsEngine;

namespace Aurora.Profiles.Postman.Layers
{
    public class ShootingLayerHandler : ImageLayerHandler
    {
        public override EffectLayer Render(IGameState gamestate)
        {
            EffectLayer layer = new EffectLayer("Shooting Layer");
            if (!(gamestate is GameState_Postman)) return layer;

            if ((gamestate as GameState_Postman).Game.Status == "shooting")
                return base.Render(gamestate);

            return layer;
        }
    }
}
