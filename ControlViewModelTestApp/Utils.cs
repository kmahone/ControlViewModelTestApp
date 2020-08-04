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
    public class DependencyPropertyAttribute : Attribute
    {

    }

    partial class CheckBoxTemplateBase
    {
        public static readonly DependencyProperty CommonStatesProperty =
            DependencyProperty.Register("CommonStates", typeof(CommonStates), typeof(CheckBoxTemplateBase), new PropertyMetadata(ControlViewModelTestApp.CommonStates.Normal, OnPropertyChanged));

        public static readonly DependencyProperty TemplateParentProperty =
            DependencyProperty.Register("TemplateParent", typeof(CheckBox2), typeof(CheckBoxTemplateBase), new PropertyMetadata(null, OnPropertyChanged));
    }
}
