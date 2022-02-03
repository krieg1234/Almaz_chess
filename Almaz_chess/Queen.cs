using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
    internal class Queen : Piece
    {
        static string icon = "Ф";
        public Queen(bool isWhire) : base(isWhire)
        {
        }
        

        public override (int x, int y)[][] CollectAllowWays()
        {
            Stack<(int x, int y)[]> ways = new Stack<(int x, int y)[]>();

            Piece abstractPiece = (Bishop)this;
            (int x, int y)[][] bishopWays = abstractPiece.CollectAllowWays();

            abstractPiece = (Rook)this;
            (int x, int y)[][] rookWays = abstractPiece.CollectAllowWays();

            foreach (var way in bishopWays)
            {
                ways.Push(way);
            }
            foreach (var way in rookWays)
            {
                ways.Push(way);
            }

            return ways.ToArray();
        }
    }
}
