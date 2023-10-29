using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackingWinFormsApp
{
    internal class BestFitDecreasingHighStrategy : PackingStrategy
    {
		public List<Level> Execute(List<Item> items, int widthBound, int conteinerHeight)
		{
			List<Item> sortedItems = items.OrderByDescending(o => o.Height).ToList();
			List<Level> result = new List<Level>();
			const string pathCounter = "counter.txt";
			const string pathArea = "area.txt";

			int itemsHeight = 0;
			int counter = 0;
			int itemArea = 0;

			//int counter = 0;

			for (int i = 0; i < sortedItems.Count; ++i)
			{
				bool isFindFreeWidth = false;

				for (int j = 0; j < result.Count; ++j)
				{
					if (result[j].GetFreeWidth() >= sortedItems[i].Width)
					{
						isFindFreeWidth = true;
						result[j].AddItem(sortedItems[i]);
						itemArea = itemArea + (sortedItems[i].Width * sortedItems[i].Height);
						counter++;
						break;
					}
				}

				if ((!isFindFreeWidth) && (itemsHeight + sortedItems[i].Height < conteinerHeight))
				{
					Level level = new Level(widthBound);
					level.AddItem(sortedItems[i]);
					result.Add(level);
					itemArea = itemArea + (sortedItems[i].Width * sortedItems[i].Height);
					counter++;
					itemsHeight += sortedItems[i].Height;
				}

				File.WriteAllText(pathCounter, Convert.ToString(counter));
				File.WriteAllText(pathArea, Convert.ToString(itemArea));
			}

			return result;
		}

		public void DrawPackingItems(List<Level> result, PictureBox pictureBox)
        {
            Graphics gr = pictureBox.CreateGraphics();          
            Rectangle clientRect = pictureBox.ClientRectangle;
;
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
