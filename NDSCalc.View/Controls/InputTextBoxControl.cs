using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NDSCalc.View.Controls
{
    internal class InputTextBoxControl : TextBox
    {
        private static readonly Regex numbers = new Regex(@"[0-9]");
        private static readonly Regex point = new Regex(@"[,.]{1}");
        private static readonly Regex end = new Regex(@"\b[0-9]+[\,\.]\d{2}");

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            _ = CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
        }

        private void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string buffer = Clipboard.GetText();
                string PreviewResult;
                if (SelectionLength == 0)
                {
                    if (string.IsNullOrEmpty(Text))
                    {
                        if (CheckField(buffer))
                        {
                            Text = buffer;
                            SelectionStart = Text.Length;
                        }
                    }
                    else
                    {
                        int caretIndex = CaretIndex;
                        PreviewResult = Text.Insert(CaretIndex, buffer);
                        if (CheckField(PreviewResult))
                        {
                            Text = PreviewResult;
                            SelectionStart = Text.Length;
                            CaretIndex = caretIndex + buffer.Length;
                        }
                    }
                }
                else
                {
                    PreviewResult = Text.Remove(SelectionStart, SelectionLength) + buffer;
                    if (CheckField(PreviewResult))
                    {
                        SelectedText = buffer;
                        CaretIndex += buffer.Length;
                        SelectionLength = 0;
                    }
                }
            }
        }

        private bool CheckField(string buffer)
        {
            return (numbers.IsMatch(buffer) && buffer.Length <= 13) || (end.IsMatch(buffer) && buffer.Length <= 16);
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);
            if (!numbers.IsMatch(e.Text) || end.IsMatch(Text) || Text.Length == 13 & !Text.Contains(",") || Text.Length == 16)
            {
                e.Handled = true;
            }
            if (point.IsMatch(e.Text) & !Text.Contains(",") & !string.IsNullOrEmpty(Text))
            {
                Text += ",";
                SelectionStart = Text.Length;
            }
        }
    }
}
