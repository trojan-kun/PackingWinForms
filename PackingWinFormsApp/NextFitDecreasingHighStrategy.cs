using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingWinFormsApp
{
    internal class NextFitDecreasingHighStrategy : PackingStrategy
    {
		public List<Level> Execute(List<Item> items, int widthBound, int conteinerHeight)
		{
			List<Item> sortedItems = items.OrderByDescending(o => o.Height).ToList();
			List<Level> result = new List<Level>();
			const string pathCounter = "counter.txt";
			const string pathArea = "area.txt";

			int level = 0;
			int remainderW = widthBound;
			int counter = 0;
			int itemArea = 0;
			int itemsHeight = sortedItems[0].Height;

			result.Add(new Level(widthBound));


			for (int i = 0; i < sortedItems.Count; ++i)
			{    

				if (sortedItems[i].Width <= remainderW)
				{
					remainderW -= sortedItems[i].Width;
					result[level].AddItem(sortedItems[i]);
					counter++;

					itemArea = itemArea + (sortedItems[i].Width * sortedItems[i].Height);
					File.WriteAllText(pathCounter, Convert.ToString(counter));
					File.WriteAllText(pathArea, Convert.ToString(itemArea));

					continue;
				}

				if ((itemsHeight + sortedItems[i].Height < conteinerHeight) && (remainderW < sortedItems[i].Width))
				{
					itemsHeight += sortedItems[i].Height;
					remainderW = widthBound - sortedItems[i].Width;

					level++;
					counter++;
					result.Add(new Level(remainderW));
					result[level].AddItem(sortedItems[i]);
					itemArea = itemArea + (sortedItems[i].Width * sortedItems[i].Height);

					File.WriteAllText(pathCounter, Convert.ToString(counter));
					File.WriteAllText(pathArea, Convert.ToString(itemArea));
				}
			}

			return result;
		}

		public void DrawPackingItems(List<Level> result, PictureBox pictureBox)
        {
            Graphics gr = pictureBox.CreateGraphics();
            Rectangle clientRect = pictureBox.ClientRectangle;

            gr.DrawRectangle(new Pen(Color.Red), clientRect.X, clientRect.Y, 
                clientRect.Width - 2, clientRect.Height - 2);
            int h = 0;

            foreach (Level level in result)
            {
                int x = 0;
                foreach (Item item in level.GetItems())
                {
                    Random random = new Random();
                    Color color = Color.FromArgb((byte)random.Next(0, 200), 
                        (byte)random.Next(0, 200), (byte)random.Next(0, 200));

                    float y = clientRect.Height - item.Height - h;
                    gr.FillRectangle(new SolidBrush(color), x, y, item.Width, item.Height);
                    gr.DrawRectangle(new Pen(Color.Black), x, y, item.Width, item.Height);
                    x += item.Width;
                }

                if (level.GetCountItems() > 0)
                    h += level.GetMaxHeight();
            }


        }
    }
}
