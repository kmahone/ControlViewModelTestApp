using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace ControlViewModelTestApp
{
    public static class VSM2
    {
        public static void Connect(UserControl control)
        {
            foreach (var vsg in VisualStateManager.GetVisualStateGroups(control.Content as FrameworkElement))
            {
                VSM2.SetTargetControl(vsg, control);
            }
        }

        public static string GetActiveState(VisualStateGroup obj)
        {
            return (string)obj.GetValue(ActiveStateProperty);
        }

        public static void SetActiveState(VisualStateGroup obj, string value)
        {
            obj.SetValue(ActiveStateProperty, value);
        }

        public static readonly DependencyProperty ActiveStateProperty =
            DependencyProperty.RegisterAttached("ActiveState", typeof(string), typeof(VSM2), new PropertyMetadata(null, OnPropertyChanged));

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var vsg = (d as VisualStateGroup);
            if (vsg != null)
            {
                var target = GetTargetControl(vsg);
                var state = GetActiveState(vsg);
                if (target != null && !string.IsNullOrEmpty(state))
                {
                    VisualStateManager.GoToState(target, state, true);
                }
            }
        }

        public static Control GetTargetControl(VisualStateGroup obj)
        {
            return (Control)obj.GetValue(TargetControlProperty);
        }

        public static void SetTargetControl(VisualStateGroup obj, Control value)
        {
            obj.SetValue(TargetControlProperty, value);
        }

        public static readonly DependencyProperty TargetControlProperty =
            DependencyProperty.RegisterAttached("TargetControl", typeof(Control), typeof(VSM2), new PropertyMetadata(null, OnPropertyChanged));



        public static bool GetIsActive(VisualState obj)
        {
            return (bool)obj.GetValue(IsActiveProperty);
        }

        public static void SetIsActive(VisualState obj, bool value)
        {
            obj.SetValue(IsActiveProperty, value);
            if (obj.StateTriggers.Count == 0)
            {
                obj.StateTriggers.Add(new StateTrigger());
            }
        }

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.RegisterAttached("IsActive", typeof(bool), typeof(VSM2), new PropertyMetadata(false, OnIsActivePropertyChanged));

        public static void OnIsActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var vs = d as VisualState;
            if(vs != null)
            {
                if(vs.StateTriggers.Count == 0)
                {
                    vs.StateTriggers.Add(new StateTrigger());
                }
                var st = vs.StateTriggers[0] as StateTrigger;
                if(st != null)
                {
                    st.IsActive = (bool)e.NewValue;
                }
            }
        }
    }
}
