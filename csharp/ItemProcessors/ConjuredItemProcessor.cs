namespace csharp.ItemProcessors
{
    public class ConjuredItemProcessor : IItemProcessor
    {
        private Item _item { get; set; }

        public ConjuredItemProcessor(Item item)
        {
            _item = item;
        }
        
        /// <summary>
        /// Conjured item's quality degraded twice as fast as normal
        /// </summary>
        public void UpdateSellInAndQuality()
        {
            _item.SellIn--;

            if (_item.SellIn >= 0)
            {
                _item.Quality -= 2;
            }

            if (_item.Quality < 0)
            {
                _item.Quality = 0;
            }
        }
    }
}
