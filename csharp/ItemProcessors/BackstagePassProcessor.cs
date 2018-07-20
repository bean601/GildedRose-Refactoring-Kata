namespace csharp.ItemProcessors
{
    public class BackstagePassProcessor : IItemProcessor
    {
        private Item _item { get; set; }

        public BackstagePassProcessor(Item item)
        {
            _item = item;
        }

        /// <summary>
        /// Backstage passes quality increases with age. 
        /// Within 10 days of the concert, the quality goes up by 2 daily.  
        /// Within 5 days of the concert, the quality goes up by 3 daily.
        /// AFter the concert, the tickets are worthless
        /// </summary>
        public void UpdateSellInAndQuality()
        {
            _item.SellIn--;

            if (_item.SellIn < 0)
            {
                _item.Quality = 0;
            }
            else if (_item.Quality < 50)
            {
                _item.Quality++; //increases by 1 everyday

                if (_item.SellIn < 10)
                {
                    _item.Quality++; //increases by 2 if its less than 10 days till concert

                    if (_item.SellIn < 5)
                    {
                        _item.Quality++; //increases by 3 if less than 5 days till concert
                    }
                }
            }

            if (_item.Quality > 50)
            {
                _item.Quality = 50;
            }
        }
    }
}
