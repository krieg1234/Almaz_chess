using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
    internal class Knight : Piece
    {
        static string icon = "k";
        public Knight(bool isWhire) : base(isWhire)
        {
        }

        public override (int x, int y)[][] CollectAllowWays()
        {
            Stack<(int x, int y)[]> ways = new Stack<(int x, int y)[]>();

            (int x, int y)[] nextWay;
            nextWay = new (int x, int y)[1] { (this.coordinate.x + 2, this.coordinate.y + 1) };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[1] { (this.coordinate.x + 2, this.coordinate.y - 1) };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[1] { (this.coordinate.x + 1, this.coordinate.y - 2) };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[1] { (this.coordinate.x + 1, this.coordinate.y - 2) };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[1] { (this.coordinate.x - 2, this.coordinate.y + 1) };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[1] { (this.coordinate.x - 2, this.coordinate.y - 1) };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[1] { (this.coordinate.x + 1, this.coordinate.y + 2) };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[1] { (this.coordinate.x - 1, this.coordinate.y + 2) };
            ways.Push(nextWay);

            return ways.ToArray();
        }
    }
}
