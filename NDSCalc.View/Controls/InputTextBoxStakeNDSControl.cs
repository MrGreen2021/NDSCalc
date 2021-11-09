using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace NDSCalc.View.Controls
{
    internal class InputTextBoxStakeNDSControl : TextBox
    {
        private static readonly Regex number = new Regex(@"[0-9]");

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ContextMenu = null;
            _ = CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
        }

        private void OnPasteCommand(object sender, ExecutedRoutedEventArgs e) { }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);
            if (SelectionLength != 0)
            {
                string PreviewResult = Text.Remove(SelectionStart, SelectionLength) + e.Text;
                if (!number.IsMatch(PreviewResult) || Convert.ToInt32(PreviewResult) <= 0 || Convert.ToInt32(PreviewResult) > 100)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!number.IsMatch(e.Text) || Convert.ToInt32(Text + e.Text) <= 0 || Convert.ToInt32(Text + e.Text) > 100)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
