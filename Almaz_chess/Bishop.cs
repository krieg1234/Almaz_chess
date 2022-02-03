using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
    internal class Bishop : Piece
    {
        static string icon = "B";
        public Bishop(bool isWhire) : base(isWhire)
        {
        }
        

        public override (int x, int y)[][] CollectAllowWays()
        {
            Stack<(int x, int y)[]> ways = new Stack<(int x, int y)[]>();
            //(int x, int y)[][] ways = new (int x, int y)[4][];

            Stack<(int x, int y)> cells = new Stack<(int x, int y)>();
            for (int x = this.coordinate.x; x <= Board.maxCellIndex; x++)
            {
                (int x, int y) nextCell = (x, this.coordinate.y);
                cells.Push(nextCell);
            }
            ways.Push(cells.ToArray());

            cells.Clear();
            for (int x = this.coordinate.x; x >= 0; x--)
            {
                (int x, int y) nextCell = (x, this.coordinate.y);
                cells.Push(nextCell);
            }
            ways.Push(cells.ToArray());

            cells.Clear();
            for (int y = this.coordinate.y; y <= Board.maxCellIndex; y++)
            {
                (int x, int y) nextCell = (this.coordinate.x, y);
                cells.Push(nextCell);
            }
            ways.Push(cells.ToArray());

            cells.Clear();
            for (int y = this.coordinate.y; y >= 0; y--)
            {
                (int x, int y) nextCell = (this.coordinate.x, y);
                cells.Push(nextCell);
            }
            ways.Push(cells.ToArray());

            return ways.ToArray();
        }

        public static explicit operator Bishop(Queen v)
        {
            return new Bishop(v.isWhite);
        }
    }
}
