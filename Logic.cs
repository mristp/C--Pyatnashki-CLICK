using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Logic
    {        
        int[,] map;// = new int[4, 4];
        int emptyX = 3, emptyY = 3;
        static Random rnd = new Random();

        public Logic()
        {
            map = new int[4, 4];
        }

        public void start ()
        {
            for (int x=0;x<4;x++)            
                for (int y=0;y<4;y++)                
                    map[x, y] = coordsToPosition(x, y)+1;
            map[emptyX, emptyY] = 0;
        }

        public int getNumber(int position)
        {
            int x, y;
            positionToCoords(position, out x, out y);
            return map[x, y];
        }

        private int coordsToPosition(int x, int y)
        {
            if (x < 0) x = 0;
            if (x > 3) x = 3;
            if (y < 0) y = 0;
            if (y > 3) y = 3;
            return y * 4 + x;
        }

        private void positionToCoords(int position, out int x, out int y)
        {
            if (position < 0) position = 0;
            if (position > 15) position = 15;
            x = position % 4;
            y = position / 4;
        }

        public void shiftButton (int position)
        {
            int x, y;
            positionToCoords(position, out x, out y);
            if (Math.Abs(emptyX - x) + Math.Abs(emptyY - y) != 1) return;
            map[emptyX, emptyY] = map[x, y];
            map[x, y] = 0;
            emptyX = x;
            emptyY = y;
        }
        public void shiftButtonRandomize()
        {
            int availableMoves = rnd.Next(0, 4);
            int nextX = emptyX;
            int nextY = emptyY;
            switch (availableMoves)
            {
                case 0: nextX--; break;
                case 1: nextX++; break;
                case 2: nextY--; break;
                case 3: nextY++; break;
            }
            shiftButton(coordsToPosition(nextX, nextY));

        }
        public bool theEnd()
        {
            if (!(emptyX == 3 && emptyY == 3)) return false;
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    if (!(x == 3 && y == 3))
                        if (map[x, y] != coordsToPosition(x, y) + 1) return false;
            return true;
        }
    }    
}
