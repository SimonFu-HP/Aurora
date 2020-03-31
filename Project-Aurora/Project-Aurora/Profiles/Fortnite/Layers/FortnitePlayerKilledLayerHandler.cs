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

    public class FortnitePlayerKilledProperties : LayerHandlerProperties<FortnitePlayerKilledProperties>
    {
        public bool? _ShowExplosion { get; set; }

        [JsonIgnore]
        public bool ShowExplosion { get { return Logic._ShowExplosion ?? _ShowExplosion ?? true; } }

        public FortnitePlayerKilledProperties() : base()
        {
        }

        public FortnitePlayerKilledProperties(bool arg = false) : base(arg)
        {
        }

        public FortnitePlayerKilledProperties(Color primaryColor) : base()
        {
            _PrimaryColor = primaryColor;
        }

        public override void Default()
        {
            base.Default();
            _PrimaryColor = Color.FromArgb(125, 0, 0, 0);
            _ShowExplosion = true;
        }
    }

    public class FortnitePlayerKilledLayerHandler : LayerHandler<FortnitePlayerKilledProperties>
    {
        private readonly AnimationTrack[] tracks =
        {
            new AnimationTrack("Goal Explosion Track 0", 1.0f, 0.0f),
            new AnimationTrack("Goal Explosion Track 1", 1.0f, 0.5f),
            new AnimationTrack("Goal Explosion Track 2", 1.0f, 1.0f),
            new AnimationTrack("Goal Explosion Track 3", 1.0f, 1.5f),
            new AnimationTrack("Goal Explosion Track 4", 1.0f, 2.0f)
        };

        private long previoustime = 0;
        private long currenttime = 0;
        private ulong frameIdx = 0;
        private EffectLayer savedLayer = null;

        private static float goalEffect_keyframe = 0.0f;
        private const float goalEffect_animationTime = 3.0f;

        public FortnitePlayerKilledLayerHandler() : base()
        {
            _ID = "FortnitePlayerKilledLayer";
        }

        public override EffectLayer Render(IGameState gamestate)
        {
            previoustime = currenttime;
            currenttime = Utils.Time.GetMillisecondsSinceEpoch();

            EffectLayer layer = new EffectLayer("Fortnite Player Killed Layer");
            AnimationMix goal_explosion_mix = new AnimationMix();

            if (!(gamestate is GameState_Fortnite) || (gamestate as GameState_Fortnite).Game.Status != "player killed")
                return layer;

            if (frameIdx++ % 2 != 0 && savedLayer != null) return savedLayer;

            layer.Fill(Color.Black);

            this.SetTracks(Properties.PrimaryColor);

            goal_explosion_mix = new AnimationMix(tracks);

            goal_explosion_mix.Draw(layer.GetGraphics(), goalEffect_keyframe);
            goalEffect_keyframe += (currenttime - previoustime) / 1000.0f;

            if (goalEffect_keyframe >= goalEffect_animationTime)
            {
                goalEffect_keyframe = 0;
            }

            savedLayer = new EffectLayer(layer);

            return layer;
        }

        public override void SetApplication(Application profile)
        {
            base.SetApplication(profile);
        }

        protected override UserControl CreateControl()
        {
            return new Control_FortnitePlayerKilledLayer();
        }

        private void SetTracks(Color playerColor)
        {
            for (int i = 0; i < tracks.Length; i++)
            {
                tracks[i].SetFrame(
                    0.0f,
                    new AnimationCircle(
                        (int)(Effects.canvas_width_center * 0.9),
                        Effects.canvas_height_center,
                        0,
                        playerColor,
                        4)
                );

                tracks[i].SetFrame(
                    1.0f,
                    new AnimationCircle(
                        (int)(Effects.canvas_width_center * 0.9),
                        Effects.canvas_height_center,
                        Effects.canvas_biggest / 2.0f,
                        playerColor,
                        4)
                );
            }
        }
    }
}
