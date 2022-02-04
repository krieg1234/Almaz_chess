using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
     abstract class Piece
    {
        public bool isAlive = true;
        public bool isWhite { get; }
        public (int x, int y) coordinate;
        public abstract string Icon { get;  }

        public Piece(bool isWhire)
        {
            this.isWhite = isWhire;            
        }

        public void Replace(int x, int y)
        {
            this.coordinate = new(x, y);         
        }

        public void Kill()
        {
            isAlive = !isAlive;
            coordinate = (666, 666);
        }

        public abstract (int x, int y)[][] CollectAllowWays();

        public (int x, int y)[] SelectWay((int x, int y) target)
        {
            (int x, int y)[][] ways = CollectAllowWays();            

            foreach ((int x, int y)[] way in ways)
            {
                foreach ((int x, int y) cell in way)
                {
                    if (cell == target)
                    {
                        Stack<(int x, int y)> wayToTarget = new Stack<(int x, int y)>();
                        int indexOfCoord = Array.IndexOf(way, this.coordinate);
                        int indexOfTarget = Array.IndexOf(way, target);

                        int startPoint=Math.Min(indexOfTarget, indexOfCoord);
                        int endPoint = Math.Max(indexOfTarget, indexOfCoord);

                        for (int i = startPoint; i < endPoint; i++)
                        {
                            wayToTarget.Push(way[i]);
                        }
                        (int x, int y)[] result = wayToTarget.ToArray();
                        if (this is Bishop)
                        {
                            Console.WriteLine();
                        }
                        return result;
                    }
                }
            }            
            throw new Exception($"Эта фигура   так не ходит ({coordinate}=>({target}))");           
        }

    }
}
