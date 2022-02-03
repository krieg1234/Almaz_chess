using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
    internal class Rook : Piece
    {
        static string icon = "Л";
        public Rook(bool isWhire) : base(isWhire)
        {
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
                x <= Board.maxCellIndex && y <= Board.maxCellIndex;
                x--, y++)
            {
                cells.Push((x, y));
            }
            ways.Push(cells.ToArray());

            cells.Clear();
            for ((int x, int y) = (this.coordinate.x, this.coordinate.y);
                x <= Board.maxCellIndex && y <= Board.maxCellIndex;
                x++, y--)
            {
                cells.Push((x, y));
            }
            ways.Push(cells.ToArray());

            cells.Clear();
            for ((int x, int y) = (this.coordinate.x, this.coordinate.y);
                x <= Board.maxCellIndex && y <= Board.maxCellIndex;
                x--, y--)
            {
                cells.Push((x, y));
            }
            ways.Push(cells.ToArray());

            return ways.ToArray();
        }              

        public static explicit operator Rook(Queen v)
        {
            return new Rook(v.isWhite);
        }
    }
}
