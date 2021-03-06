using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
    internal class Queen : Piece
    {
        public Queen(bool isWhite) : base(isWhite)
        {
            icon = isWhite?"ФЕР":"QUE";
        }
        public string icon;
        public override string Icon
        {
            get => icon;
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
