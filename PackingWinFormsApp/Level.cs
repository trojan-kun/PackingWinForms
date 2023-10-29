using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingWinFormsApp
{
    internal class Level
    {
        private List<Item> items;
        private int width;
        public Level(int width)
        {
            items = new List<Item>();
            this.Width = width;
        }

        public int Width { get => width; set => width = value; }

        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        public void InsertItem(Item item, int index)
        {
            items.Insert(index, item);
        }

        public Item GetItemByIndex(int index)
        {
            return items[index];
        }

        public int GetMaxHeight()
        {
            return items.Max(r => r.Height);
        }

        public int GetCountItems()
        {
            return this.items.Count;
        }

        public List<Item> GetItems()
        {
            return this.items;
        }

        public int GetFreeWidth()
        {
            int res = Width - items.Sum(r => r.Width);
            return res;
        }
    }
}
