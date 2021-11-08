using System.ComponentModel;

namespace NDSCalc.ViewModel.Interfaces
{
    /// <summary>Интерфейс VM калькулятора НДС.</summary>
    public interface INdsCalculationViewModel : INotifyPropertyChanged
    {
        /// <summary>Сумма без НДС.</summary>
        decimal AmountWithoutNds { get; set; }

        /// <summary>Ставка НДС.</summary>
        decimal NdsRate { get; set; }

        /// <summary>Сумма НДС.</summary>
        decimal AmountOfNds { get; }

        /// <summary>Общая сумма, включая НДС.</summary>
        decimal TotalAmount { get; }
    }
}
