using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
    internal class Rook : Piece
    {
        public Rook(bool isWhite) : base(isWhite)
        {
            icon = isWhite?"ЛАД":"ROO";
        }
        public string icon;
        public override string Icon
        {
            get => icon;
        }


        public override (int x, int y)[][] CollectAllowWays()
        {
            Stack<(int x, int y)[]> ways = new Stack<(int x, int y)[]>();
            Stack<(int x, int y)> cells = new Stack<(int x, int y)>();

            for ((int x, int y) = (this.coordinate.x, this.coordinate.y); 
                x <= Board.maxCellIndex && y<=Board.maxCellIndex; 
                x++, y++)
            {
                cells.Push((x, y));
            }
            ways.Push(cells.ToArray());

            cells.Clear();
            for ((int x, int y) = (this.coordinate.x, this.coordinate.y);
                x >= 0 && y <= Board.maxCellIndex;
                x--, y++)
            {
                cells.Push((x, y));
            }
            ways.Push(cells.ToArray());

            cells.Clear();
            for ((int x, int y) = (this.coordinate.x, this.coordinate.y);
                x <= Board.maxCellIndex && y >= 0;
                x++, y--)
            {
                cells.Push((x, y));
            }
            ways.Push(cells.ToArray());

            cells.Clear();
            for ((int x, int y) = (this.coordinate.x, this.coordinate.y);
                x >= 0 && y >= 0;
                x--, y--)
            {
                cells.Push((x, y));
            }
            ways.Push(cells.ToArray());

            return ways.ToArray();
        }              

        public static explicit operator Rook(Queen v)
        {
            Rook rook = new Rook(v.isWhite);
            rook.coordinate = v.coordinate;
            return rook;
        }
    }
}
