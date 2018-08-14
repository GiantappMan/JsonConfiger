using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace JsonConfiger.Behaviors
{
    public enum LimitType
    {
        None,
        Interget,
        Float,
    }

    public class TextBoxEx : Behavior<TextBox>
    {
        #region LimitType

        public LimitType LimitType
        {
            get { return (LimitType)GetValue(LimitTypeProperty); }
            set { SetValue(LimitTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LimitType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LimitTypeProperty =
            DependencyProperty.Register("LimitType", typeof(LimitType), typeof(TextBoxEx), new PropertyMetadata(LimitType.None));

        #endregion

        protected override void OnAttached()
        {
            base.OnAttached();
            if (LimitType == LimitType.None)
                return;

            AssociatedObject.PreviewTextInput += Txt_PreviewTextInput;
        }
   
        protected override void OnDetaching()
        {
            AssociatedObject.PreviewTextInput -= Txt_PreviewTextInput;
            base.OnDetaching();
        }

        private void Txt_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            switch (LimitType)
            {
                case LimitType.Interget:
                    string onlyNumeric = @"^([0-9]+)$";
                    Regex regex = new Regex(onlyNumeric);
                    e.Handled = !regex.IsMatch(e.Text);
                    break;

                case LimitType.Float:
                    onlyNumeric = @"^([0-9]+(.[0-9]+)?)$";
                    regex = new Regex(onlyNumeric);
                    e.Handled = !regex.IsMatch(e.Text);
                    break;
            }
        }
    }
}
