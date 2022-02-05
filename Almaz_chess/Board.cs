using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almaz_chess
{
    class Board
    {
        Piece[] pieces = { };

        public Piece[] Pieces
        {
            get => pieces;
        }
    

    public static int maxCellIndex = 7;
       
        public void DrawBoard()
        {
            Console.Clear();
            string[,] board = new string[8,8];
            string result = "";
            foreach (var piece in pieces)
            {
                if (piece.isAlive)
                    board[piece.coordinate.x, piece.coordinate.y] = piece.Icon;
            }

            for (int y=-1;y<=maxCellIndex; y++)
            {
                result += y +"\t";
                for (int x=0;x<=maxCellIndex; x++)
                {
                    if (y == -1) 
                    {
                        result +=  $" {x } \t";
                    }                    
                    else if (board[x, y] == null) result += "[ ]\t";
                    else result += board[x, y] + "\t";
                }
                result += "\n\n\n";
            }
            Console.WriteLine(result);
            System.Threading.Thread.Sleep(2000);
        }
       public void FillBoardByDefault()
        {
            Stack<Piece> newPieces = new Stack<Piece>();
            int coordX;
            int coordY;
            Piece piece;

            for (int side = 0; side < 2; side++)
            {
                bool isWhite = side == 0 ? true : false;
                for (int i = 0; i <= maxCellIndex; i++)
                {
                    coordX = i;
                    coordY = side == 0 ? 1 : maxCellIndex - 1;                    

                    piece = new Pawn(isWhite);
                    piece.Replace(coordX, coordY);
                    newPieces.Push(piece);
                }
                coordY = side == 0 ? 0 : maxCellIndex;

                piece=new Bishop(isWhite);
                piece.Replace(0, coordY);
                newPieces.Push(piece);

                piece = new Knight(isWhite);
                piece.Replace(1, coordY);
                newPieces.Push(piece);

                piece = new Rook(isWhite);
                piece.Replace(2, coordY);
                newPieces.Push(piece);

                piece = new King(isWhite);
                piece.Replace(isWhite?3:4, coordY);
                newPieces.Push(piece);

                piece = new Queen(isWhite);
                piece.Replace(isWhite ? 4 : 3, coordY);
                newPieces.Push(piece);

                piece = new Rook(isWhite);
                piece.Replace(5, coordY);
                newPieces.Push(piece);

                piece = new Knight(isWhite);
                piece.Replace(6, coordY);
                newPieces.Push(piece);

                piece = new Bishop(isWhite);
                piece.Replace(7, coordY);
                newPieces.Push(piece);


            }

            pieces = newPieces.ToArray();
            DrawBoard();

        }
        delegate Piece PieceCreator(bool isWhite);
        public void FillBoardByRandom()
        {
            Random rnd = new Random();
            
            int whiteCount = rnd.Next(16);
            int blackCount = rnd.Next(16);

            PieceCreator[] pieceCreators =
            {
                (bool isWhite)=>new Pawn(isWhite),
                (bool isWhite)=>new King(isWhite),
                (bool isWhite)=>new Queen(isWhite),
                (bool isWhite)=>new Rook(isWhite),
                (bool isWhite)=>new Knight(isWhite),
                (bool isWhite)=>new Bishop(isWhite),
            };

            Stack<Piece> newPieces = new Stack<Piece>();            
            Piece piece;
            

            
            for (int side=0;side<2;side++)
            {
                bool isWhite = side == 0 ? true : false;
                for (int i = 0; i < (isWhite?whiteCount:blackCount); i++)
                {
                    int nextType = rnd.Next(pieceCreators.Length);
                    PieceCreator pieceCreator = pieceCreators[nextType];
                    piece = pieceCreator(isWhite);
                    newPieces.Push(piece);

                    (int x, int y) = (rnd.Next(maxCellIndex), rnd.Next(maxCellIndex));
                    bool isPlaceEmpty = GetPieceByCoordinate(x, y) == null;
                    while (!isPlaceEmpty)
                    {
                        (x,y)= (rnd.Next(maxCellIndex), rnd.Next(maxCellIndex));
                    }
                    piece.Replace(x, y);
                }
            }
            pieces = newPieces.ToArray();
            DrawBoard();

        }

        //public Piece[] GetPiecesBySide(bool isWhite)
        //{
        //    Stack<Piece> result = new Stack<Piece>();
        //    foreach (Piece piece in pieces)
        //    {
        //        if (piece.isWhite == isWhite)    
        //            result.Push(piece);
        //    }
        //    return result.ToArray();
        //}

        public Piece GetPieceByCoordinate(int x,int y)
        {
            if (x > maxCellIndex || y > maxCellIndex || x < 0 || y < 0)
                throw new Exception($"Координата {(x,y)} за пределами доски");

            foreach (Piece piece in pieces)
            {
                if (piece.coordinate == (x, y)) return piece;
            }

            return null;
        }

        public void ReplacePiece(Piece piece, int x, int y)
        {
            try
            {
                if (piece == null)
                    throw new Exception("Фигура не выбрана");

                if (x < 0 || y < 0 || x > Board.maxCellIndex || y > Board.maxCellIndex)
                    throw new Exception($"Координаты {(x, y)} за пределами доски");

                (int x, int y)[] way = piece.SelectWay(new(x, y));
                foreach ((int x, int y) cell in way)
                {
                    foreach (Piece pieceInBoard in pieces)
                    {
                        if (pieceInBoard.coordinate == cell &&
                            pieceInBoard.coordinate != piece.coordinate &&
                            pieceInBoard.coordinate != (x, y))
                            throw new Exception($"Путь {piece.coordinate}=>{(x, y)} занят другой фигурой");
                    }
                }

                Piece targetPiece = GetPieceByCoordinate(x, y);
                if (targetPiece != null)
                {
                    if (targetPiece.isWhite != piece.isWhite)
                    {
                        if (piece is Pawn)
                            if (Math.Abs(targetPiece.coordinate.x - piece.coordinate.x)!=1)
                                throw new Exception($"Пешка атакует не так {(x, y)}");
                        targetPiece.Kill();
                    }                        
                    else
                    {
                        if (piece is Pawn)
                            if (Math.Abs(targetPiece.coordinate.x - piece.coordinate.x) != 1)
                                throw new Exception($"Пешка ходит не так {(x, y)}");
                        throw new Exception($"Ячейка занята вашей фигурой ({piece.coordinate}=>{(x, y)})");
                    }
                        
                }

                piece.Replace(x, y);

                this.DrawBoard();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
            
        }



    }
}
