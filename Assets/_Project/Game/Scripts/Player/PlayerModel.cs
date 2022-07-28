namespace TicTacToe.Game.Player
{
    [System.Serializable]
    public class PlayerModel : BaseModel
    {
        public SlotSign Sing { get; private set; }
        public int score;

        public PlayerModel(SlotSign sing)
        {
            Sing = sing;
            score = 0;
        }
    }
}