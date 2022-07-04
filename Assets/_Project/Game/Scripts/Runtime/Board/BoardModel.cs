using TicTacToe.Game.Slot;

namespace TicTacToe.Game.Board
{
    [System.Serializable]
    public class BoardModel : BaseModel
    {
        public int boardWidth;
        public int boardHeight;
        public float slotSize;
        public SlotController[,] boardGrid;
        
        public BoardModel(int boardWidth, int boardHeight, float slotSize)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            this.slotSize = slotSize;
            this.boardGrid = new SlotController[this.boardWidth, this.boardHeight];
        }

        public static BoardModel Default()
        {
            return new BoardModel(3, 3, 1.5f);
        }
    }
}