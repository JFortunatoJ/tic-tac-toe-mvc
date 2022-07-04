using TicTacToe.Game.Slot;

namespace TicTacToe.Game
{
    public class PlayerModel : BaseModel
    {
        public SlotModel.SlotSign Sing { get; private set; }

        public PlayerModel(SlotModel.SlotSign sing)
        {
            Sing = sing;
        }
    }
}