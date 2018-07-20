using csharp.ItemProcessors;

namespace csharp
{
    public static class ItemTypeFactory
    {
        /// <summary>
        /// Gets an item processor to handle updating the item's quality and sellIn days remaining
        /// </summary>
        /// <param name="item">The item to base the processor decision off of, uses the name of the item</param>
        /// <returns></returns>
        public static IItemProcessor GetItemProcessor(Item item)
        {
            IItemProcessor processor = null;

            switch (item.Name.ToLowerInvariant())
            {
                case "sulfuras, hand of ragnaros":
                    processor = new LegendaryItemProcessor(item);
                    break;
                case "aged brie":
                    processor = new AgedBrieProcessor(item);
                    break;
                case "backstage passes to a tafkal80etc concert":
                    processor = new BackstagePassProcessor(item);
                    break;
                default:
                    processor = new CommonItemProcessor(item);
                    break;
            }

            return processor;
        }
    }
}
