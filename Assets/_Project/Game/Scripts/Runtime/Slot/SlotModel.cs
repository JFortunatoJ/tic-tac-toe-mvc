namespace TicTacToe.Game.Slot
{
    [System.Serializable]
    public class SlotModel : BaseModel
    {
        public enum SlotSign
        {
            None,
            X,
            O
        }

        public SlotSign sign;
    }
}