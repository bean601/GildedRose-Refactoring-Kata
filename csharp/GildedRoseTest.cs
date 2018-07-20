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
            var items = new List<Item>
            {
                new Item { Name = "foo", SellIn = 0, Quality = 0 },
                new Item { Name = "foo1", SellIn = 0, Quality = 0 },
                new Item { Name = "foo2", SellIn = 0, Quality = 0 },
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual("foo", items[0].Name);
            Assert.AreEqual("foo1", items[1].Name);
            Assert.AreEqual("foo2", items[2].Name);
        }

        [Test]
        public void GivenValidItemsWhenUpdateQualityIsCalledThenQaulityShouldUpdateCorrectly()
        {
            var items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 25, Quality = 10 },
                new Item { Name = "test", SellIn = 25, Quality = 10 },
                new Item { Name = "test2", SellIn = -1, Quality = 10 },
                new Item { Name = "test3", SellIn = 1, Quality = 10 },
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(80, items[0].Quality);
            Assert.AreEqual(11, items[1].Quality);
            Assert.AreEqual(11, items[2].Quality);
            Assert.AreEqual(9, items[3].Quality);
            Assert.AreEqual(8, items[4].Quality);
            Assert.AreEqual(9, items[5].Quality);
        }

        [Test]
        public void GivenValidItemsWhenUpdateQualityIsCalledThenSellInShouldGoDownCorrectly()
        {
            var items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 },
                new Item { Name = "test", SellIn = 25, Quality = 10 },
                new Item { Name = "test2", SellIn = 0, Quality = 10 },
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(5, items[0].SellIn);
            Assert.AreEqual(4, items[1].SellIn);
            Assert.AreEqual(14, items[2].SellIn);
            Assert.AreEqual(24, items[3].SellIn);
            Assert.AreEqual(-1, items[4].SellIn);
        }

        [Test]
        public void GivenValidAgedBrieItemsWhenUpdateIsCalledThenSellInAndQualityShouldUpdateCorrectly()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 10 },
                new Item { Name = "Aged Brie", SellIn = 20, Quality = 50 },
                new Item { Name = "Aged Brie", SellIn = -5, Quality = 0 },
            };

            var app = new GildedRose(items);
            
            app.UpdateQuality();

            Assert.AreEqual(11, items[0].Quality);
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(11, items[1].Quality);
            Assert.AreEqual(1, items[1].SellIn);
            Assert.AreEqual(50, items[2].Quality);
            Assert.AreEqual(19, items[2].SellIn);
            Assert.AreEqual(2, items[3].Quality);  //is this supposed to increase after sellIn?
            Assert.AreEqual(-6, items[3].SellIn);
        }

        [Test]
        public void GivenValidConcertTicketItemsWhenUpdateIsCalledThenSellInAndQualityShouldUpdateCorrectly()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality =  48},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 17, Quality = 5 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 5 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 50 },
            };

            var app = new GildedRose(items);
           
            app.UpdateQuality();
       
            Assert.AreEqual(13, items[0].Quality);
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(13, items[1].Quality);
            Assert.AreEqual(1, items[1].SellIn);
            Assert.AreEqual(50, items[2].Quality);
            Assert.AreEqual(1, items[2].SellIn);
            Assert.AreEqual(6, items[3].Quality);
            Assert.AreEqual(16, items[3].SellIn);
            Assert.AreEqual(7, items[4].Quality);
            Assert.AreEqual(9, items[4].SellIn);
            Assert.AreEqual(0, items[5].Quality);
            Assert.AreEqual(-2, items[5].SellIn);
            Assert.AreEqual(50, items[6].Quality);
            Assert.AreEqual(0, items[6].SellIn);
        }

        [Test]
        public void GivenValidItemsWhenUpdateQualityIsCalledManyTimesThenQualityShouldUpdateCorrectly()
        {
            var items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 },
                new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 },
                new Item { Name = "test", SellIn = 25, Quality = 15 },
                new Item { Name = "test2", SellIn = 0, Quality = 5 },
                new Item { Name = "Aged Brie", SellIn = 15, Quality = 48 },
            };

            var app = new GildedRose(items);

            for (int i = 0; i < 10; i++)
            {
                app.UpdateQuality();
            }

            Assert.AreEqual(80, items[0].Quality); //legendary items can never change from 80
            Assert.AreEqual(25, items[1].Quality); //weird case where cheese increase doubles after 0 selIn days
            Assert.AreEqual(5, items[2].Quality);
            Assert.AreEqual(0, items[3].Quality);
            Assert.AreEqual(50, items[4].Quality); //normal items can never go above 50
        }

        [Test]
        public void GivenValidConjuredItemsWhenUpdateIsCalledThenSellInAndQualityShouldUpdateCorrectly()
        {
            var items = new List<Item>
            {
                new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 0 },
                new Item { Name = "Conjured Mana Cake", SellIn = 50, Quality = 50 },
                new Item { Name = "Conjured Mana Cake", SellIn = 2, Quality = 10 },
                new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 },
                new Item { Name = "Conjured Mana Cake", SellIn = 1, Quality = 10 },
                new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 10 },
            };

            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(4, items[0].SellIn);
            Assert.AreEqual(48, items[1].Quality);
            Assert.AreEqual(49, items[1].SellIn);
            Assert.AreEqual(8, items[2].Quality);
            Assert.AreEqual(1, items[2].SellIn);
            Assert.AreEqual(8, items[3].Quality);
            Assert.AreEqual(9, items[3].SellIn);
            Assert.AreEqual(8, items[4].Quality);
            Assert.AreEqual(0, items[4].SellIn);
            Assert.AreEqual(6, items[5].Quality);
            Assert.AreEqual(-2, items[5].SellIn);
        }
    }
}
