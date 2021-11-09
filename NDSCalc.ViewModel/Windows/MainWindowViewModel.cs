using NDSCalc.ViewModel.Interfaces;
using Simplified;

namespace NDSCalc.ViewModel.Windows
{
    public class MainWindowViewModel : BaseInpc, INdsCalculationViewModel
    {
        private decimal _amountWithoutNds;
        private decimal _ndsRate;
        private decimal _amountOfNds;
        private decimal _totalAmount;

        public decimal AmountWithoutNds { get => _amountWithoutNds; set => Set(ref _amountWithoutNds, value); }
        public decimal NdsRate { get => _ndsRate; set => Set(ref _ndsRate, value); }
        public decimal AmountOfNds { get => _amountOfNds; private set => Set(ref _amountOfNds, value); }
        public decimal TotalAmount { get => _totalAmount; private set => Set(ref _totalAmount, value); }

        public static MainWindowViewModel DemoInstance { get; } = new MainWindowViewModel()
        {
            AmountWithoutNds = 123.45m,
            NdsRate = 67.8m,
            AmountOfNds = 90.12m,
            TotalAmount = 345.67m
        };
    }
}
