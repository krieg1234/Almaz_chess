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
        private (int x, int y)[][] ways;

        public Piece(bool isWhire)
        {
            this.isWhite = isWhire;
        }

        public void Replace(int x, int y)
        {
            ways = this.CollectAllowWays();
            this.coordinate = new(x, y);
        }

        public void Kill()
        {
            isAlive = !isAlive;
            
        }

        public abstract (int x, int y)[][] CollectAllowWays();

        public (int x, int y)[] SelectWay((int x, int y) target)
        {
            foreach ((int x, int y)[] way in ways)
            {
                foreach ((int x, int y) cell in way)
                {
                    if (cell == target)
                    {
                        return way;
                    }
                }
            }
            throw new Exception("Эта фигура так не ходит");
        }

    }
}
