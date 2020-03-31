using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace Aurora.Profiles.Fortnite.Layers {
	
    /// <summary>
    /// Interaction logic for Control_NoOptions.xaml
    /// </summary>
    public partial class Control_FortniteGlidingLayer : UserControl {
        private bool settingsSet = false;

        public Control_FortniteGlidingLayer() {
            InitializeComponent();
        }

        public Control_FortniteGlidingLayer(FortniteGlidingLayerHandler context)
        {
            InitializeComponent();
            DataContext = context;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetSettings();
            Loaded -= UserControl_Loaded;
        }

        private void SetSettings()
        {
            if (!settingsSet && DataContext is FortniteGlidingLayerHandler)
            {
                settingsSet = true;
                ColorPicker_RainColor.SelectedColor = Utils.ColorUtils.DrawingColorToMediaColor((DataContext as FortniteGlidingLayerHandler).Properties._PrimaryColor ?? System.Drawing.Color.Empty);
                MinimumIntensity_Stepper.Value = (DataContext as FortniteGlidingLayerHandler).Properties._MinimumInterval;
                MaximumIntensity_Stepper.Value = (DataContext as FortniteGlidingLayerHandler).Properties._MaximumInterval;
            }
        }

        private void ColorPicker_RainColor_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (IsLoaded && settingsSet && DataContext is FortniteGlidingLayerHandler && e.NewValue.HasValue)
                (DataContext as FortniteGlidingLayerHandler).Properties._PrimaryColor = Utils.ColorUtils.MediaColorToDrawingColor(e.NewValue.Value);
        }

        private void MinimumIntensity_Stepper_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsLoaded && settingsSet && DataContext is FortniteGlidingLayerHandler && (sender as IntegerUpDown).Value.HasValue)
                (DataContext as FortniteGlidingLayerHandler).Properties._MinimumInterval = (sender as IntegerUpDown).Value.Value;
        }

        private void MaximumIntensity_Stepper_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (IsLoaded && settingsSet && DataContext is FortniteGlidingLayerHandler && (sender as IntegerUpDown).Value.HasValue)
                (DataContext as FortniteGlidingLayerHandler).Properties._MaximumInterval = (sender as IntegerUpDown).Value.Value;
        }
    }
}
