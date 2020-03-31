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
using System.Runtime.InteropServices;

namespace Aurora.Profiles.Fortnite.Layers {

    public class FortniteBuildingLayerHandler : AmbilightLayerHandler {
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rect rectangle);


        public override EffectLayer Render(IGameState gamestate) {
            EffectLayer layer = new EffectLayer("Forthite Building Layer");

            // Render nothing if invalid gamestate or player isn't on fire
            if (!(gamestate is GameState_Fortnite) || (gamestate as GameState_Fortnite).Game.Status != "building")
                return layer;

            var hFgWnd = GetForegroundWindow();
            if (hFgWnd == IntPtr.Zero) return layer;

            Rect wndRect = new Rect();
            if (!GetWindowRect(hFgWnd, out wndRect)) return layer;

            int w = wndRect.Right - wndRect.Left;
            int h = wndRect.Bottom - wndRect.Top;
            Properties._Coordinates = new Rectangle(wndRect.Left + Convert.ToInt32(w * 0.45 + 0.50), wndRect.Top + Convert.ToInt32(h * 0.45 + 0.50), Convert.ToInt32(w * 0.1 + 0.5), Convert.ToInt32(h * 0.1 + 0.5));

            return base.Render(gamestate);
        }
    }
}
