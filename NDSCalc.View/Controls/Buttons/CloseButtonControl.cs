using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NDSCalc.View.Controls.Buttons
{
    internal class CloseButtonControl : Button
    {
        #region Свойства
        public bool MEnter { get; set; }

        #endregion

        private bool? CheckPressed = null;
        private readonly SolidColorBrush colorBrush = new SolidColorBrush();

        #region Анимации

        private readonly ColorAnimation MEnterAnim = new ColorAnimation(Color.FromArgb(150, 255, 56, 56), TimeSpan.FromSeconds(0.1));
        private readonly ColorAnimation MLeaveAnim = new ColorAnimation(Color.FromArgb(0, 255, 56, 56), TimeSpan.FromSeconds(0.1));
        private readonly ColorAnimation MPressedEnterAnim = new ColorAnimation(Color.FromArgb(150, 176, 16, 16), TimeSpan.FromSeconds(0.1));
        private readonly ColorAnimation MPressedLeaveAnim = new ColorAnimation(Color.FromArgb(0, 176, 16, 16), TimeSpan.FromSeconds(0.1));
        private readonly ColorAnimation MEndAnim = new ColorAnimation(Color.FromArgb(0, 0, 0, 0), TimeSpan.FromSeconds(0.1));

        #endregion

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            BorderBrush = colorBrush;
            MEnter = true;

            if (CheckPressed == null)
            {
                colorBrush.BeginAnimation(SolidColorBrush.ColorProperty, MEnterAnim);
            }

        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            BorderBrush = colorBrush;
            MEnter = false;
            if (CheckPressed == null)
            {
                colorBrush.BeginAnimation(SolidColorBrush.ColorProperty, MLeaveAnim);
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            BorderBrush = colorBrush;
            CheckPressed = null;
            if (MEnter)
            {
                colorBrush.BeginAnimation(SolidColorBrush.ColorProperty, MEnterAnim);
            }
            else
            {
                colorBrush.BeginAnimation(SolidColorBrush.ColorProperty, MEndAnim);
            }
        }

        protected override void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnIsPressedChanged(e);
            BorderBrush = colorBrush;
            CheckPressed = Convert.ToBoolean(e.NewValue);
            if (Convert.ToBoolean(e.NewValue))
            {
                colorBrush.BeginAnimation(SolidColorBrush.ColorProperty, MPressedEnterAnim);
            }
            else if (Convert.ToBoolean(e.NewValue) == false)
            {
                colorBrush.BeginAnimation(SolidColorBrush.ColorProperty, MPressedLeaveAnim);
            }
        }

        protected override void OnClick()
        {
            base.OnClick();
            Application.Current.MainWindow.Close();
        }
    }
}
