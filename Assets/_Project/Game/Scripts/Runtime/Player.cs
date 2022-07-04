using TicTacToe.Game.Slot;

namespace TicTacToe.Game.Player
{
    public class Player
    {
        public SlotModel.SlotSign sing;

        public Player(SlotModel.SlotSign sing)
        {
            this.sing = sing;
        }
    }
}