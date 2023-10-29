using System.Drawing;
using System.Windows.Forms;

namespace PackingWinFormsApp
{
    public partial class Form1 : Form
    {
        const string path = "data.txt";
        const string pathCounter = "counter.txt";
		const string pathArea = "area.txt";
		PackingStrategy? StrategyPacking = null;

        public Form1()
        {
            InitializeComponent();

			StrategyPacking = new NextFitDecreasingHighStrategy();
        }

        private void btnGenNewRects_Click(object sender, EventArgs e)
        {
            List<Item> items = GenerateItems((int)numUpDownCountRect.Value);
            DisplayItemsInfo(items);
        }

		private void btnPacking_Click(object sender, EventArgs e)
		{
			Packing();
		}

		private List<Item> GenerateItems(int total)
        {
            List<Item> items = new List<Item>();
            Random rnd = new Random();
			string[] data = new string[total];

            int minWidth = 10;
            int minHeight = 10;
            int maxWidth = pictureBox1.ClientRectangle.Width / 4;
            int maxHeigth = pictureBox1.ClientRectangle.Height / 5;

            for (int i = 0; i < total; i++)
            {
                int rndWidth = rnd.Next(minWidth, maxWidth);
                int rndHeight = rnd.Next(minHeight, maxHeigth);

                data[i] = rndWidth.ToString() + " " + rndHeight.ToString();
                items.Add(new Item(rndWidth, rndHeight));
            }

            File.WriteAllLines(path, data);

            return items;
        }

        private void DisplayItemsInfo(List<Item> items)
        {
			ClearPacking();

			if (items != null)
            {
                richTextBoxAboutRects.Clear();
                richTextBoxAboutRects.AppendText(String.Format(
                    "{0,5}\t\t{1,5}\t\t{2,5}", "Номер", "Ширина", "Высота"));

				int num = 1;

                foreach (Item item in items)
                {
                    richTextBoxAboutRects.AppendText(String.Format(
                        "\n{0,-11}\t\t{1,-10}\t\t{2,-11}", num++, item.Width, item.Height));
                }

			
			}
        }

        private void Packing()
        {
            string[] lines = File.ReadAllLines(path);
            List<Item> items = new List<Item>();
			List<Level> result = new List<Level>();

            int containerArea = pictureBox1.ClientRectangle.Width * pictureBox1.ClientRectangle.Height;

			for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(' ');
                int rndWidth = Convert.ToInt32(data[0]);
                int rndHeight = Convert.ToInt32(data[1]);

                items.Add(new Item(rndWidth, rndHeight));
            }

            ClearPacking();
			richTextBoxAboutEmployment.Clear();
			richTextBoxAboutUse.Clear();

			if (StrategyPacking != null)
            {
				result = StrategyPacking.Execute(items, 
                    pictureBox1.ClientRectangle.Width - 1, pictureBox1.ClientRectangle.Height - 1);
				StrategyPacking.DrawPackingItems(result, pictureBox1);

			}

			string counter = File.ReadAllText(pathCounter);
            Double itemsArea = Convert.ToDouble(File.ReadAllText(pathArea));
            itemsArea = (itemsArea / containerArea) * 100;

			richTextBoxAboutUse.AppendText(String.Format("{0,5}\t{1,5}","Использовано фигур: ", counter));
			richTextBoxAboutEmployment.AppendText((String.Format("{0,5}\t{1,5}", "Занято места: ", itemsArea)));
		}

        private void ClearPacking()
        {
            pictureBox1.Refresh();
        }

        private void rdbNextFitDecreasingHigh_CheckedChanged(object sender, EventArgs e)
        {
			StrategyPacking = new NextFitDecreasingHighStrategy();
        }

        private void rdbBestFitDecreasingHigh_CheckedChanged(object sender, EventArgs e)
        {
			StrategyPacking = new BestFitDecreasingHighStrategy();
        }

        private void rdbBiLevelNextFit_CheckedChanged(object sender, EventArgs e)
        {
			StrategyPacking = new BiLevelNextFit();
        }

		private void numUpDownCountRect_ValueChanged(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}
	}
}