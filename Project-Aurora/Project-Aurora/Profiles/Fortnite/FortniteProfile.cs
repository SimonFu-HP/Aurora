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

            Layers = new ObservableCollection<Layer> {
                new Layer("Enemy killed layer", new FortniteEnemyKilledLayerHandler(){
                    Properties = new FortniteEnemyKilledProperties(Color.FromArgb(50, 205, 50)),
                }),

                new Layer("Poison layer", new FortnitePoisonLayerHandler()
                {
                    Properties = new BreathingLayerHandlerProperties()
                    {
                        _Sequence = new KeySequence(new FreeFormObject ((float)-50.0, (float)-50.955883, (float)1385.40466, (float)297.2353 )),
                        _PrimaryColor = Color.FromArgb(113, 15, 255),
                        _SecondaryColor = Color.FromArgb(255, 0, 0),
                        _EffectSpeed = 2.0f
                    },
                }),

                new Layer("Gliding layer", new FortniteGlidingLayerHandler()),

                new Layer("Building layer", new FortniteBuildingLayerHandler(){
                    Properties = new AmbilightLayerHandlerProperties()
                    {
                        _AmbilightCaptureType = AmbilightCaptureType.Coordinates,
                    },
                }),

                new Layer("Harvest layer", new FortniteHarvestLayerHandler(){
                    Properties = new AmbilightLayerHandlerProperties()
                    {
                        _AmbilightCaptureType = AmbilightCaptureType.Coordinates,
                    },
                }),

                new Layer("Player killed layer", new FortnitePlayerKilledLayerHandler() {
                    Properties = new FortnitePlayerKilledProperties(Color.Red),
                }),

                new Layer("Shooting layer", new FortniteShootingLayerHandler()),

                new Layer("Explosion layer", new FortniteExplosionLayerHandler()),

                new Layer("interactive layer", new InteractiveLayerHandler {
                    Properties = new InteractiveLayerHandlerProperties {
                        _InteractiveEffect = Desktop.InteractiveEffects.Wave,
                        _PrimaryColor = Color.White,
                        _SecondaryColor = Color.FromArgb(30, 0, 255),
                        _EffectSpeed = 20,
                        _EffectWidth = 24,
                        _WaitOnKeyUp = true,
                        _UsePressBuffer = true,
                        _Sequence = new KeySequence(new[] {
                            (DeviceKeys)40,
                            (DeviceKeys)60,
                            (DeviceKeys)61,
                            (DeviceKeys)62,
                            (DeviceKeys)38,
                            (DeviceKeys)18,
                            (DeviceKeys)19,
                            (DeviceKeys)20,
                            (DeviceKeys)21,
                            (DeviceKeys)22,
                            (DeviceKeys)23,
                            (DeviceKeys)2,
                            (DeviceKeys)3,
                            (DeviceKeys)4,
                            (DeviceKeys)5,
                            (DeviceKeys)6,
                            (DeviceKeys)59,
                            (DeviceKeys)76,
                            (DeviceKeys)94,
                            (DeviceKeys)97,
                            (DeviceKeys)44,
                            (DeviceKeys)64,
                            (DeviceKeys)63,
                            (DeviceKeys)42,
                            (DeviceKeys)41,
                            (DeviceKeys)90,
                            (DeviceKeys)91,
                            (DeviceKeys)92,
                            (DeviceKeys)105,
                            (DeviceKeys)106,
                            (DeviceKeys)93,
                            (DeviceKeys)58,
                            (DeviceKeys)37,
                            (DeviceKeys)34,
                            (DeviceKeys)35,
                            (DeviceKeys)36,
                            (DeviceKeys)55,
                            (DeviceKeys)56,
                            (DeviceKeys)57,
                            (DeviceKeys)73,
                            (DeviceKeys)74,
                            (DeviceKeys)75,
                            (DeviceKeys)136,
                            (DeviceKeys)137,
                            (DeviceKeys)133,
                            (DeviceKeys)138,
                            (DeviceKeys)139,
                            (DeviceKeys)131,
                            (DeviceKeys)132,
                            (DeviceKeys)16,
                            (DeviceKeys)15,
                            (DeviceKeys)14,
                            (DeviceKeys)31,
                            (DeviceKeys)32,
                            (DeviceKeys)33,
                            (DeviceKeys)54,
                            (DeviceKeys)53,
                            (DeviceKeys)52,
                            (DeviceKeys)89,
                            (DeviceKeys)102,
                            (DeviceKeys)103,
                            (DeviceKeys)104,
                            (DeviceKeys)101,
                            (DeviceKeys)100,
                            (DeviceKeys)99,
                            (DeviceKeys)98,
                            (DeviceKeys)94,
                            (DeviceKeys)76,
                            (DeviceKeys)78,
                            (DeviceKeys)79,
                            (DeviceKeys)80,
                            (DeviceKeys)81,
                            (DeviceKeys)82,
                            (DeviceKeys)83,
                            (DeviceKeys)85,
                            (DeviceKeys)86,
                            (DeviceKeys)87,
                            (DeviceKeys)88,
                            (DeviceKeys)70,
                            (DeviceKeys)69,
                            (DeviceKeys)68,
                            (DeviceKeys)67,
                            (DeviceKeys)66,
                            (DeviceKeys)65,
                            (DeviceKeys)64,
                            (DeviceKeys)63,
                            (DeviceKeys)59,
                            (DeviceKeys)17,
                            (DeviceKeys)18,
                            (DeviceKeys)19,
                            (DeviceKeys)20,
                            (DeviceKeys)21,
                            (DeviceKeys)22,
                            (DeviceKeys)23,
                            (DeviceKeys)40,
                            (DeviceKeys)60,
                            (DeviceKeys)61,
                            (DeviceKeys)62,
                            (DeviceKeys)41,
                            (DeviceKeys)42,
                            (DeviceKeys)43,
                            (DeviceKeys)44,
                            (DeviceKeys)45,
                            (DeviceKeys)47,
                            (DeviceKeys)48,
                            (DeviceKeys)49,
                            (DeviceKeys)50,
                            (DeviceKeys)51,
                            (DeviceKeys)30,
                            (DeviceKeys)29,
                            (DeviceKeys)28,
                            (DeviceKeys)27,
                            (DeviceKeys)26,
                            (DeviceKeys)25,
                            (DeviceKeys)24,
                            (DeviceKeys)2,
                            (DeviceKeys)3,
                            (DeviceKeys)4,
                            (DeviceKeys)5,
                            (DeviceKeys)6,
                            (DeviceKeys)7,
                            (DeviceKeys)8,
                            (DeviceKeys)9,
                            (DeviceKeys)10,
                            (DeviceKeys)11,
                            (DeviceKeys)12,
                            (DeviceKeys)13})
                    }
                }),

                new Layer("comms", new SolidColorLayerHandler {
                    Properties = new LayerHandlerProperties {
                        _PrimaryColor = Color.FromArgb(0, 166, 33),
                        _Sequence = new KeySequence(new[] { (DeviceKeys)44, (DeviceKeys)72 })
                    }
                }),

                new Layer("E", new SolidColorLayerHandler {
                    Properties = new LayerHandlerProperties {
                        _PrimaryColor = Color.FromArgb(93, 190, 255),
                        _Sequence = new KeySequence(new[] { DeviceKeys.E })
                    }
                }),

                new Layer("inventory", new SolidColorLayerHandler {
                    Properties = new LayerHandlerProperties {
                        _PrimaryColor = Color.FromArgb(255, 122, 0),
                        _Sequence = new KeySequence(new[] { (DeviceKeys)18,
                            (DeviceKeys)19,
                            (DeviceKeys)20,
                            (DeviceKeys)21,
                            (DeviceKeys)22,
                            (DeviceKeys)23,
                            (DeviceKeys)46 })
                    }
                }),

                new Layer("map", new SolidColorLayerHandler {
                    Properties = new LayerHandlerProperties {
                        _PrimaryColor = Color.FromArgb(215, 252, 6),
                        _Sequence = new KeySequence(new[] { (DeviceKeys)38, (DeviceKeys)84 })
                    }
                }),

                new Layer("building", new SolidColorLayerHandler {
                    Properties = new LayerHandlerProperties {
                        _PrimaryColor = Color.FromArgb(0, 7, 255),
                        _Sequence = new KeySequence(new[] {
                            (DeviceKeys)39,
                            (DeviceKeys)2,
                            (DeviceKeys)3,
                            (DeviceKeys)4,
                            (DeviceKeys)5,
                            (DeviceKeys)6,
                            (DeviceKeys)64,
                            (DeviceKeys)63})
                    }
                }),

                new Layer("movement", new SolidColorLayerHandler {
                    Properties = new LayerHandlerProperties {
                        _PrimaryColor = Color.White,
                        _Sequence = new KeySequence(new[] {
                            (DeviceKeys)40,
                            (DeviceKeys)60,
                            (DeviceKeys)61,
                            (DeviceKeys)62,
                            (DeviceKeys)76,
                            (DeviceKeys)94,
                            (DeviceKeys)97})
                    }
                }),

                new Layer("background", new BreathingLayerHandler()
                {
                    Properties = new BreathingLayerHandlerProperties()
                    {
                        _Sequence = new KeySequence(new FreeFormObject ((float)-50.0, (float)-50.955883, (float)1385.40466, (float)297.2353 )),
                        _PrimaryColor = Color.FromArgb(152, 0, 255),
                        _SecondaryColor = Color.FromArgb(10, 0, 25),
                        _EffectSpeed = 1.0f
                    },

                })
            };
        }
    }
}
