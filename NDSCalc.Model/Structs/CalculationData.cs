namespace NDSCalc.Model.Structs
{
    /// <summary>Структура для данных о состоянии Модели.</summary>
    public struct CalculationData
    {
        /// <summary>Сумма без НДС.</summary>
        public decimal AmountWithoutNds { get; set; }

        /// <summary>Ставка НДС.</summary>
        public decimal NdsRate { get; set; }

        /// <summary>Сумма НДС.</summary>
        public decimal AmountOfNds { get; set; }

        /// <summary>Общая сумма, включая НДС.</summary>
        public decimal TotalAmount { get; set; }

        public CalculationData(decimal amountWithoutNds, decimal ndsRate, decimal amountOfNds, decimal totalAmount)
        {
            AmountWithoutNds = amountWithoutNds;
            NdsRate = ndsRate;
            AmountOfNds = amountOfNds;
            TotalAmount = totalAmount;
        }
    }
}
