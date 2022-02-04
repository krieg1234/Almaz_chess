using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
    internal class King : Piece
    {
        public King(bool isWhite) : base(isWhite)
        {
            icon = isWhite?"КОР":"KIN";
        }
        public string icon;
        public override string Icon
        {
            get => icon;
        }

        public override (int x, int y)[][] CollectAllowWays()
        {
            Stack<(int x, int y)[]> ways = new Stack<(int x, int y)[]>();

            (int x, int y)[] nextWay;
            nextWay = new (int x, int y)[2] { (this.coordinate.x + 1, this.coordinate.y), coordinate };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[2] { (this.coordinate.x+1, this.coordinate.y-1), coordinate };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[2] { (this.coordinate.x, this.coordinate.y-1), coordinate };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[2] { (this.coordinate.x - 1, this.coordinate.y-1), coordinate };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[2] { (this.coordinate.x - 1, this.coordinate.y), coordinate };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[2] { (this.coordinate.x - 1, this.coordinate.y+1), coordinate };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[2] { (this.coordinate.x, this.coordinate.y+1), coordinate };
            ways.Push(nextWay);
            nextWay = new (int x, int y)[2] { (this.coordinate.x + 1, this.coordinate.y+1), coordinate };
            ways.Push(nextWay);

            return ways.ToArray();
        }
        
    }
}
