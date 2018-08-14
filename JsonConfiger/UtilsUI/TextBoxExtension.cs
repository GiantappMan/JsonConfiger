using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace JsonConfiger.UtilsUI
{
    public enum LimitType
    {
        None,
        Interget,
        Float,
    }

    public static class TextBoxExtension
    {
        #region Limit

        public static LimitType GetLimitType(DependencyObject obj)
        {
            return (LimitType)obj.GetValue(LimitTypeProperty);
        }

        public static void SetLimitType(DependencyObject obj, LimitType value)
        {
            obj.SetValue(LimitTypeProperty, value);
        }

        // Using a DependencyProperty as the backing store for LimitType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LimitTypeProperty =
            DependencyProperty.RegisterAttached("LimitType", typeof(LimitType), typeof(TextBoxExtension), new PropertyMetadata(LimitType.None, new PropertyChangedCallback((sender, e) =>
            {
                TextBox txt = sender as TextBox;
                LimitType type = (LimitType)e.NewValue;
                if (txt == null || type == LimitType.None)
                    return;

                DataObject.AddPastingHandler(txt, PastingHandler);

                txt.PreviewKeyDown += Txt_PreviewKeyDown;
            })));

        private static void Txt_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            LimitType type = GetLimitType(txt);
            e.Handled = !IsTextAllowed(type, e.Key.ToString());
        }

        private static void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            TextBox txt = sender as TextBox;
            LimitType type = GetLimitType(txt);

            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(type, text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static bool IsTextAllowed(LimitType type, string text)
        {
            bool result = false;
            switch (type)
            {
                case LimitType.Interget:
                    string onlyNumeric = @"^(\d+)$";
                    Regex regex = new Regex(onlyNumeric);
                    result = regex.IsMatch(text);
                    break;

                case LimitType.Float:
                    onlyNumeric = @"^([0-9]+(.[0-9]+)?)$";
                    regex = new Regex(onlyNumeric);
                    result = regex.IsMatch(text);
                    break;
            }
            return result;
        }

        #endregion
    }
}
