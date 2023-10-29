using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackingWinFormsApp
{
    internal class BiLevelNextFit : PackingStrategy
    {
		public List<Level> Execute(List<Item> items, int widthBound, int conteinerHeight)
		{
			List<Level> result = new List<Level>();
			const string pathCounter = "counter.txt";
			const string pathArea = "area.txt";

			int level = 0;
			int counter = 0;
			int itemArea = 0;

			int itemsHeight = 0;
			result.Add(new Level(widthBound));

			foreach (Item item in items)
			{

				Level curLevel = result[level];
				
				if (curLevel.GetFreeWidth() < item.Width)
				{
					itemsHeight += Convert.ToInt32(result[level].GetMaxHeight());

					result.Add(new Level(widthBound));
					level++;
					curLevel = result[level];
				}
				if (itemsHeight + item.Height < conteinerHeight)
				{
					if (result.Count % 2 != 0)
					{
						if (curLevel.GetCountItems() == 0)
						{
							curLevel.AddItem(item);
						}
						else
						{
							curLevel.InsertItem(item, 1);
						}
						counter++;
						itemArea = itemArea + (item.Width * item.Height);
					}
					else
					{
						Level prevLevel = result[level - 1];
						if (prevLevel.GetCountItems() == 1)
						{
							if (curLevel.GetCountItems() == 0)
							{
								curLevel.AddItem(item);
							}
							else
							{
								curLevel.InsertItem(item, 1);
							}
						}
						else
						{
							if (curLevel.GetCountItems() == 0)
							{
								curLevel.AddItem(item);
							}
							else
							{
								Item itemFirst = prevLevel.GetItemByIndex(0);
								Item itemLast = prevLevel.GetItemByIndex(prevLevel.GetCountItems() - 1);

								if (itemFirst.Height <= itemLast.Height)
								{
									curLevel.InsertItem(item, 1);
								}
								else
								{
									curLevel.InsertItem(item, 0);
								}
							}
						}
						counter++;
						itemArea = itemArea + (item.Width * item.Height);
					}

					File.WriteAllText(pathCounter, Convert.ToString(counter));
					File.WriteAllText(pathArea, Convert.ToString(itemArea));
				}
				
			}	

			return result;
		}

		public void DrawPackingItems(List<Level> result, PictureBox picBox)
        {
            Graphics gr = picBox.CreateGraphics();
            Rectangle clientRect = picBox.ClientRectangle;

            gr.DrawRectangle(new Pen(Color.Red), clientRect.X, clientRect.Y, 
				clientRect.Width - 2, clientRect.Height - 2);
            
            int h = 0;

            for (int i = 0; i < result.Count - 1; i++)
            {
                if (((i + 1) % 2 != 0) || ((result[i - 1].GetCountItems() == 1) && ((i + 1) % 2 == 0)))
                {
                    DrawOddLevel(result[i], gr, clientRect, h);
                }
                else
                {
                    DrawEvenLevel(result[i], result[i - 1], gr, clientRect, h);
                }

                if (result[i].GetCountItems() > 0)
                    h += result[i].GetMaxHeight();
            }
        }

        private void DrawOddLevel(Level level, Graphics gr, Rectangle clientRect, int h)
        {
			List<Item> items = level.GetItems();

			int x = 0;
			int y = clientRect.Height - items[0].Height - h;

			Color color = GetRndColor();
			Rectangle rect;

			rect = new Rectangle(x, y, items[0].Width, items[0].Height);
			gr.FillRectangle(new SolidBrush(color), rect);
			gr.DrawRectangle(new Pen(Color.Black), rect);

			x = clientRect.Width;

			for (int j = items.Count - 1; j > 0; j--)
            {
                color = GetRndColor();
                y = clientRect.Height - items[j].Height - h;
                rect = new Rectangle(x - items[j].Width, y, items[j].Width, items[j].Height);

                gr.FillRectangle(new SolidBrush(color), rect);
                gr.DrawRectangle(new Pen(Color.Black), rect);

                x -= items[j].Width;
            }
        }

        private void DrawEvenLevel(Level level, Level prevLevel, Graphics gr, Rectangle clientRect, int h)
        {
			List<Item> items = level.GetItems();

			int x = 0;
			int y;

			Item itemFirst = prevLevel.GetItemByIndex(0);
            Item itemLast = prevLevel.GetItemByIndex(prevLevel.GetCountItems() - 1);

            Color color = GetRndColor();
			Rectangle rect;

			if (itemFirst.Height <= itemLast.Height)
            {
                y = clientRect.Height - items[0].Height - h;
				rect = new Rectangle(x, y, items[0].Width, items[0].Height);

				gr.FillRectangle(new SolidBrush(color), rect);
                gr.DrawRectangle(new Pen(Color.Black), rect);

                x = clientRect.Width;
            }
            else
            {
                x = clientRect.Width;
                y = clientRect.Height - items[0].Height - h;
				rect = new Rectangle(x - items[0].Width, y, items[0].Width, items[0].Height);

				gr.FillRectangle(new SolidBrush(color), rect);
                gr.DrawRectangle(new Pen(Color.Black), rect);

                x -= items[0].Width;
            }

            for (int j = items.Count - 1; j > 0; j--)
			{
                color = GetRndColor();
				y = clientRect.Height - items[j].Height - h;
				rect = new Rectangle(x - items[j].Width, y, items[j].Width, items[j].Height);

                gr.FillRectangle(new SolidBrush(color), rect);
                gr.DrawRectangle(new Pen(Color.Black), rect);

                x -= items[j].Width;
            }
        }

        private Color GetRndColor()
        {
            Random random = new Random();

            return Color.FromArgb((byte)random.Next(0, 200), (byte)random.Next(0, 200), (byte)random.Next(0, 200));
        }
    }
}
