namespace Almaz_chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            //board.FillBoardByRandom();

            board.FillBoardByDefault();
            Piece target;
            target = board.GetPieceByCoordinate(3, 6);
            board.ReplacePiece(target, 3, 5);
            board.ReplacePiece(target, 3, 4);
            board.ReplacePiece(target, 3, 3);
            board.ReplacePiece(target, 3, 2);
            board.ReplacePiece(target, 2, 1);

            //Piece target;
            //target = board.GetPieceByCoordinate(3, 6);
            //board.ReplacePiece(target, 3, 5);
            //board.ReplacePiece(target, 3, 4);

            //target = board.GetPieceByCoordinate(2, 7);
            //board.ReplacePiece(target, 5, 4);
            //board.ReplacePiece(target, 2, 1);
            //board.ReplacePiece(target, 5, 4);

            //target = board.GetPieceByCoordinate(7, 6);
            //board.ReplacePiece(target, 7, 5);
            //board.ReplacePiece(target, 7, 4);
            //board.ReplacePiece(target, 7, 3);

            //target = board.GetPieceByCoordinate(7, 7);
            //board.ReplacePiece(target, 7, 5);
            //board.ReplacePiece(target, 5, 5);
            //board.ReplacePiece(target, 5, 1);

            //target = board.GetPieceByCoordinate(1, 0);
            //board.ReplacePiece(target, 0, 2);
            //board.ReplacePiece(target, 1, 4);
            //board.ReplacePiece(target, 2, 6);

            //target = board.GetPieceByCoordinate(3, 0);
            //board.ReplacePiece(target, 2, 1);
            //board.ReplacePiece(target, 2, 2);
            //board.ReplacePiece(target, 1, 1);

            //target = board.GetPieceByCoordinate(3, 7);
            //board.ReplacePiece(target, 3, 6);
            //board.ReplacePiece(target, 3, 5);
            //board.ReplacePiece(target, 7, 1);
            //board.ReplacePiece(target, 6, 1);
            //board.ReplacePiece(target, 5, 1);
            //board.ReplacePiece(target, 4, 1);
            //board.ReplacePiece(target, 3, 1);











        }
    }
}