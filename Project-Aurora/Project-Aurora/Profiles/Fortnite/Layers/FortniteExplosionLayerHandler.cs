using Aurora.EffectsEngine;
using Aurora.EffectsEngine.Animations;
using Aurora.Settings.Layers;
using Aurora.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Aurora.Profiles.Fortnite.Layers {

    public class FortniteExplosionLayerHandler : LayerHandler<LayerHandlerProperties> {

        private List<ExplosionParticle> particles = new List<ExplosionParticle>();
        private Random rnd = new Random();

        public FortniteExplosionLayerHandler() {
            _ID = "FortniteExplosionLayer";
        }

        protected override UserControl CreateControl() {
            return new Control_FortniteExplosionLayer();
        }

        private void CreateFireParticle() {
            float randomX = (float)rnd.NextDouble() * Effects.canvas_width;
            float randomOffset = ((float)rnd.NextDouble() * 15) - 7.5f;
            particles.Add(new ExplosionParticle() {
                mix = new AnimationMix(new[] {
                    new AnimationTrack("particle", 0)
                        .SetFrame(0, new AnimationFilledCircle(randomX, Effects.canvas_height + 5, 5, Color.FromArgb(255, 230, 0)))
                        .SetFrame(1, new AnimationFilledCircle(randomX + randomOffset, -6, 6, Color.FromArgb(0, 255, 230, 0)))
                }),
                time = 0
            });
        }

        public override EffectLayer Render(IGameState gamestate) {
            EffectLayer layer = new EffectLayer("Forthite Burning Layer");

            // Render nothing if invalid gamestate or player isn't on fire
            if (!(gamestate is GameState_Fortnite) || (gamestate as GameState_Fortnite).Game.Status != "explosion")
                return layer;

            // Set the background to red
            layer.Fill(Color.Red);

            // Add 3 particles every frame
            for (int i = 0; i < 3; i++)
                CreateFireParticle();

            // Render all particles
            foreach (var particle in particles) {
                particle.mix.Draw(layer.GetGraphics(), particle.time);
                particle.time += .1f;
            }

            // Remove any expired particles
            particles.RemoveAll(particle => particle.time >= 1);

            return layer;
        }
    }

    internal class ExplosionParticle {
        internal AnimationMix mix;
        internal float time;
    }
}
