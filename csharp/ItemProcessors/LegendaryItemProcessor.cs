namespace csharp.ItemProcessors
{
    public class LegendaryItemProcessor : IItemProcessor
    {
        private Item _item { get; set; }
                
        public LegendaryItemProcessor(Item item)
        {
            _item = item;
        }

        /// <summary>
        /// Legendary items never have to be sold and don't decrease in quality
        /// </summary>
        public void UpdateSellInAndQuality()
        {
            //do nothing since this is a legendary item
        }
    }
}
