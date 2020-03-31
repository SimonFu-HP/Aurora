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
using Newtonsoft.Json;

namespace Aurora.Profiles.Fortnite.Layers {
    public class FortniteGlidingLayerHandlerProperties : LayerHandlerProperties<FortniteGlidingLayerHandlerProperties>
    {

        [JsonIgnore]
        public int MinimumInterval => _MinimumInterval ?? 30;
        public int? _MinimumInterval { get; set; }

        [JsonIgnore]
        public int MaximumInterval => _MaximumInterval ?? 30;
        public int? _MaximumInterval { get; set; }

        public FortniteGlidingLayerHandlerProperties() : base() { }
        public FortniteGlidingLayerHandlerProperties(bool assign_default = false) : base(assign_default) { }

        public override void Default()
        {
            base.Default();
            _PrimaryColor = Color.Cyan;
            _MinimumInterval = 30;
            _MaximumInterval = 1;
        }
    }

    public class FortniteGlidingLayerHandler : LayerHandler<FortniteGlidingLayerHandlerProperties>
    {
        private List<Droplet> raindrops = new List<Droplet>();
        private Random rnd = new Random();
        private int frame = 0;

        public FortniteGlidingLayerHandler() : base()
        {
            _ID = "FortniteGlidingLayer";
        }

        protected override UserControl CreateControl()
        {
            return new Control_FortniteGlidingLayer(this);
        }

        private void CreateRainDrop()
        {
            float randomX = (float)rnd.NextDouble() * Effects.canvas_width;
            raindrops.Add(new Droplet()
            {
                mix = new AnimationMix(new[] {
                    new AnimationTrack("raindrop", 0)
                        .SetFrame(0, new AnimationFilledRectangle(randomX, 0, 3, 6, Properties.PrimaryColor))
                        .SetFrame(1, new AnimationFilledRectangle(randomX + 5, Effects.canvas_height, 2, 4, Properties.PrimaryColor))
                }),
                time = 0
            });
        }

        public override EffectLayer Render(IGameState gamestate)
        {
            EffectLayer layer = new EffectLayer("FortniteG Rain Layer");

            if (!(gamestate is GameState_Fortnite)) return layer;

            if (!(gamestate is GameState_Fortnite) || (gamestate as GameState_Fortnite).Game.Status != "gliding")
                return layer;

            layer.Fill(Color.Black);

            // Add more droplets based on the intensity
            float strength = 1.0f;
            if (strength > 0)
            {
                if (frame <= 0)
                {
                    // calculate time (in frames) until next droplet is created
                    float min = Properties.MinimumInterval, max = Properties.MaximumInterval; // Store as floats so C# doesn't prematurely round numbers
                    frame = (int)Math.Round(min - ((min - max) * strength)); // https://www.desmos.com/calculator/uak73e5eub
                    CreateRainDrop();
                }
                else
                    frame--;
            }

            // Render all droplets
            foreach (var droplet in raindrops)
            {
                droplet.mix.Draw(layer.GetGraphics(), droplet.time);
                droplet.time += .1f;
            }

            // Remove any expired droplets
            raindrops.RemoveAll(droplet => droplet.time >= 1);

            return layer;
        }
    }

    internal class Droplet
    {
        internal AnimationMix mix;
        internal float time;
    }
}
