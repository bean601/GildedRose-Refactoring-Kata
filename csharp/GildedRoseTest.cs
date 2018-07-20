using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void GivenValidItemsTheNamesShouldBeReturnedCorrectly()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "foo", SellIn = 0, Quality = 0 },
                new Item { Name = "foo1", SellIn = 0, Quality = 0 },
                new Item { Name = "foo2", SellIn = 0, Quality = 0 },
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual("foo1", Items[1].Name);
            Assert.AreEqual("foo2", Items[2].Name);
        }

        [Test]
        public void GivenValidItemsWhenUpdateQualityIsCalledThenQaulityShouldUpdateCorrectly()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 25, Quality = 10 },
                new Item { Name = "test", SellIn = 25, Quality = 10 },
                new Item { Name = "test2", SellIn = -1, Quality = 10 },
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(80, Items[0].Quality);
            Assert.AreEqual(11, Items[1].Quality);
            Assert.AreEqual(11, Items[2].Quality);
            Assert.AreEqual(9, Items[3].Quality);
            Assert.AreEqual(8, Items[4].Quality);
        }

        [Test]
        public void GivenValidItemsWhenUpdateQualityIsCalledThenSellInShouldGoDownCorrectly()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 },
                new Item { Name = "test", SellIn = 25, Quality = 10 },
                new Item { Name = "test2", SellIn = 0, Quality = 10 },
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            Assert.AreEqual(5, Items[0].SellIn);
            Assert.AreEqual(4, Items[1].SellIn);
            Assert.AreEqual(14, Items[2].SellIn);
            Assert.AreEqual(24, Items[3].SellIn);
            Assert.AreEqual(-1, Items[4].SellIn);
        }

        [Test]
        public void GivenValidAgedBrieItemsWhenUpdateIsCalledThenSellInAndQualityShouldUpdateCorrectly()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 20, Quality = 50 },
                new Item { Name = "Aged Brie", SellIn = -5, Quality = 0 },
            };

            GildedRose app = new GildedRose(Items);
            
            app.UpdateQuality();

            Assert.AreEqual(11, Items[0].Quality);
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(11, Items[1].Quality);
            Assert.AreEqual(1, Items[1].SellIn);
            Assert.AreEqual(50, Items[2].Quality);
            Assert.AreEqual(19, Items[2].SellIn);
            Assert.AreEqual(2, Items[3].Quality);  //is this supposed to increase after sellIn?
            Assert.AreEqual(-6, Items[3].SellIn);
        }

        [Test]
        public void GivenValidConcertTicketItemsWhenUpdateIsCalledThenSellInAndQualityShouldUpdateCorrectly()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality =  48},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 17, Quality = 5 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 50 },
            };

            GildedRose app = new GildedRose(Items);
           
            app.UpdateQuality();
       
            Assert.AreEqual(13, Items[0].Quality);
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(13, Items[1].Quality);
            Assert.AreEqual(1, Items[1].SellIn);
            Assert.AreEqual(50, Items[2].Quality);
            Assert.AreEqual(1, Items[2].SellIn);
            Assert.AreEqual(6, Items[3].Quality);
            Assert.AreEqual(16, Items[3].SellIn);
            Assert.AreEqual(7, Items[4].Quality);
            Assert.AreEqual(9, Items[4].SellIn);
            Assert.AreEqual(0, Items[5].Quality);
            Assert.AreEqual(-2, Items[5].SellIn);
        }

        [Test]
        public void GivenValidItemsWhenUpdateQualityIsCalledManyTimesThenQualityShouldUpdateCorrectly()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 },
                new Item { Name = "test", SellIn = 25, Quality = 15 },
                new Item { Name = "test2", SellIn = 0, Quality = 5 },
                new Item { Name = "Aged Brie", SellIn = 15, Quality = 48 },
            };

            GildedRose app = new GildedRose(Items);

            for (int i = 0; i < 10; i++)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(80, Items[0].Quality); //legendary items can never change from 80
            Assert.AreEqual(25, Items[1].Quality); //weird case where cheese increase doubles after 0 selIn days
            Assert.AreEqual(5, Items[2].Quality);
            Assert.AreEqual(0, Items[3].Quality);
            Assert.AreEqual(50, Items[4].Quality); //normal items can never go above 50
        }
    }
}
