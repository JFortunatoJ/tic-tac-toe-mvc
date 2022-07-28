namespace TicTacToe.Game.Slot
{
    public class SlotController : BaseController<SlotModel, SlotView>
    {
        public SlotSign Sign
        {
            get => Model.sign;
            set
            {
                Model.sign = value;
                View.Sign = value;
            }
        }

        public bool CanInteractWithSlot()
        {
            return Model.sign == SlotSign.Empty;
        }
    }
}