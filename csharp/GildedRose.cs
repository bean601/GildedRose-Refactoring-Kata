using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                var processor = ItemProcessorFactory.GetItemProcessor(item);

                if (processor != null)
                {
                    processor.UpdateSellInAndQuality();
                }
            }            
        }
    }
}
