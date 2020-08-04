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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ControlViewModelTestApp
{
    public sealed partial class CheckBox2 : UserControl
    {
        public CheckBox2()
        {
            this.InitializeComponent();
            template.TemplateParent = this;
        }

        bool isPointerOver = false;
        bool isPointerDown = false;

        protected override void OnPointerEntered(PointerRoutedEventArgs e)
        {
            base.OnPointerEntered(e);
            isPointerOver = true;
            UpdateVisualStates();
        }

        protected override void OnPointerExited(PointerRoutedEventArgs e)
        {
            base.OnPointerExited(e);
            isPointerOver = false;
            UpdateVisualStates();
        }

        protected override void OnPointerCanceled(PointerRoutedEventArgs e)
        {
            base.OnPointerCanceled(e);
            isPointerOver = false;
            isPointerDown = false;
            UpdateVisualStates();
        }

        protected override void OnPointerCaptureLost(PointerRoutedEventArgs e)
        {
            base.OnPointerCaptureLost(e);
            isPointerOver = false;
            isPointerDown = false;
            UpdateVisualStates();
        }

        protected override void OnPointerPressed(PointerRoutedEventArgs e)
        {
            base.OnPointerPressed(e);
            if(this.CapturePointer(e.Pointer))
            {
                isPointerDown = true;
                UpdateVisualStates();
            }
        }

        protected override void OnPointerReleased(PointerRoutedEventArgs e)
        {
            base.OnPointerReleased(e);
            if(isPointerDown)
            {
                isPointerDown = false;
                DoClick();
                UpdateVisualStates();
            }
            this.ReleasePointerCapture(e.Pointer);
        }

        void DoClick()
        {
            if(IsChecked == true)
            {
                IsChecked = false;
            }
            else
            {
                IsChecked = true;
            }
        }

        void UpdateVisualStates()
        {
            if(isPointerDown)
            {
                template.CommonStates = CommonStates.Pressed;
            }
            else if(isPointerOver)
            {
                template.CommonStates = CommonStates.PointerOver;
            }
            else
            {
                template.CommonStates = CommonStates.Normal;
            }
        }
        

        public event RoutedEventHandler Checked;

        public bool? IsChecked
        {
            get { return (bool?)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool?), typeof(CheckBox2), new PropertyMetadata(false, OnPropertyChanged));

        public object Content2
        {
            get { return (object)GetValue(Content2Property); }
            set { SetValue(Content2Property, value); }
        }

        public static readonly DependencyProperty Content2Property =
            DependencyProperty.Register("Content2", typeof(object), typeof(CheckBox2), new PropertyMetadata(null));

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CheckBox2).OnPropertyChanged(e);
        }

        public void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if(e.Property == ControlTemplate2Property)
            {
                var dt = e.NewValue as DataTemplate;
                if (dt != null)
                {
                    var content = dt.LoadContent() as CheckBoxTemplateBase;
                    if(content != null)
                    {
                        this.Content = content;
                        content.TemplateParent = this;
                    }
                }
            }
        }

        public DataTemplate ControlTemplate2
        {
            get { return (DataTemplate)GetValue(ControlTemplate2Property); }
            set { SetValue(ControlTemplate2Property, value); }
        }

        public static readonly DependencyProperty ControlTemplate2Property =
            DependencyProperty.Register("ControlTemplate2", typeof(DataTemplate), typeof(CheckBox2), new PropertyMetadata(null, OnPropertyChanged));


    }
}
