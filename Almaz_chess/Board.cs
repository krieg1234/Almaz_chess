using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
    class Board
    {
        Piece[] pieces;
        public static int maxCellIndex = 7;
       
       public void FillBoardByDefault()
        {
            pieces = new Piece[32];

            for (int pieceIndex=0; pieceIndex < pieces.Length; pieceIndex++)
            {
                for (int side = 0; side < 2; side++)
                {
                    for (int i = 0; i <= maxCellIndex; i++)
                    {
                        int coordX = i;
                        int coordY = side == 0 ? 1 : maxCellIndex-1;
                        bool isWhite = pieceIndex == 0 ? true : false;

                        Piece piece = new Pawn(isWhite);
                        piece.Replace(coordX, coordY);

                        pieces[pieceIndex] = piece;
                    }
                }
            }
            
        }

        public Piece[] GetPiecesBySide(bool isWhite)
        {
            Piece[] result = { };
            foreach (Piece piece in pieces)
            {
                if (piece.isWhite == isWhite)                   
                {
                    Piece[] newResult = new Piece[result.Length + 1];
                    for (int i = 0; i < result.Length; i++)
                    {
                        newResult[i] = piece;
                    }
                    newResult[result.Length] = piece;
                    result = newResult;
                }
            }
            return result;
        }

        public void ReplacePiece(Piece piece, int x, int y)
        {
            if (x < 0 || y < 0 || x > Board.maxCellIndex || y > Board.maxCellIndex)
                throw new Exception("Координаты за пределами доски");

            Piece[] friends = GetPiecesBySide(piece.isWhite);
            Piece[] enemies = GetPiecesBySide(!piece.isWhite);

            foreach (Piece friend in friends)
            {
                if (!friend.isAlive) continue;
                if (friend.coordinate.x==x && friend.coordinate.y == y)
                {
                    throw new Exception("Ячейка занята дружеской фигурой");
                }                    
            }

            (int x, int y)[] way = piece.SelectWay(new (x, y));
            foreach ((int x, int y) cell in way)
            {
                foreach (Piece pieceInBoard in pieces)
                {
                    if (pieceInBoard.coordinate == cell &&
                        pieceInBoard.coordinate != piece.coordinate &&
                        pieceInBoard.coordinate != (x, y))                    
                                throw new Exception("Путь занят другой фигурой");                                          
                }
            }
            
           
            piece.Replace(x, y);

            foreach (Piece enemy in enemies)
            {
                if (!enemy.isAlive) continue;
                if (enemy.coordinate.x == x && enemy.coordinate.y == y) 
                {
                    enemy.Kill();
                    break;
                }
            }
        }



    }
}
