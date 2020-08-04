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
    public abstract partial class CheckBoxTemplateBase : UserControl
    {
        [DependencyProperty]
        public CheckBox2 TemplateParent
        {
            get { return (CheckBox2)GetValue(TemplateParentProperty); }
            set { SetValue(TemplateParentProperty, value); }
        }

        [DependencyProperty]
        public CommonStates CommonStates
        {
            get { return (CommonStates)GetValue(CommonStatesProperty); }
            set { SetValue(CommonStatesProperty, value); }
        }

        protected bool IsTrue(bool? b)
        {
            return b.HasValue && b.Value;
        }
        protected bool IsFalse(bool? b)
        {
            return b.HasValue && !b.Value;
        }
        protected bool IsNull(bool? b)
        {
            return !b.HasValue;
        }
        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CheckBoxTemplateBase).OnPropertyChanged(e);
        }

        protected virtual void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {

        }
    }

    public enum CommonStates
    {
        Normal,
        PointerOver,
        Pressed,
        Disabled
    }
}
