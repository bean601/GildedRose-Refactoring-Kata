namespace csharp.ItemProcessors
{
    public class AgedBrieProcessor : IItemProcessor
    {
        private Item _item { get; set; }

        public AgedBrieProcessor(Item item)
        {
            _item = item;
        }

        /// <summary>
        /// Aged Brie quality increases as it ages, if the SellIn is less than zero, the quality increase doubles
        /// </summary>
        public void UpdateSellInAndQuality()
        {
            _item.SellIn--;

            if (_item.Quality < 50)
            {
                if (_item.SellIn < 0)
                {
                    _item.Quality += 2;
                }
                else
                {
                    _item.Quality++;
                }
            }

            if (_item.Quality > 50)
            {
                _item.Quality = 50;
            }
        }
    }
}
