using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
//using System.Windows.Forms;
using System.Windows.Navigation;

namespace Aurora.Profiles.Fortnite {

    public partial class Control_Fortnite : System.Windows.Controls.UserControl {
        private Application m_profile;
        private GameState_Fortnite State => m_profile.Config.Event._game_state as GameState_Fortnite;

        public Control_Fortnite(Application profile) {
            InitializeComponent();
            m_profile = profile;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = e.AddedItems[0] as ComboBoxItem;
            string effect = item.Content.ToString();

            if (!string.IsNullOrEmpty(effect))
            {
                Global.logger.Info(effect);
                if(State != null)
                {
                    State.Game.Status = effect.ToLower();
                }
            }
        }
    }
}
