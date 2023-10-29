using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingWinFormsApp
{
    internal interface OnlinePackingStrategy
    {
        List<Level> Execute(List<Item> item, int widthBound, int conteinerHeight);

        void DrawPackingItems(List<Level> result, PictureBox pictureBox);
    }
}
