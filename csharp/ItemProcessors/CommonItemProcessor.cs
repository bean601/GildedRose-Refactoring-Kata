using System;

namespace csharp.ItemProcessors
{
    public class CommonItemProcessor : IItemProcessor
    {
        private Item _item { get; set; }

        public CommonItemProcessor(Item item)
        {
            _item = item;
        }

        /// <summary>
        /// Common items decrease in quality by 1 everyday.  Quality can never be less than 0.
        /// </summary>
        public void UpdateSellInAndQuality()
        {
            _item.SellIn--;

            if (_item.SellIn <= 0)
            {
                _item.Quality -= 2;
            }
            else
            {
                _item.Quality--;
            }

            if (_item.Quality < 0)
            {
                _item.Quality = 0;
            }
        }
    }
}
