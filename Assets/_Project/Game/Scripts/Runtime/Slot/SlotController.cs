namespace TicTacToe.Game.Slot
{
    public class SlotController : BaseController<SlotModel, SlotView>
    {
        public SlotModel.SlotSign Sign
        {
            get => model.sign;
            set
            {
                model.sign = value;
                View.Sign = value;
            }
        }

        public bool CanInteractWithSlot()
        {
            return model.sign == SlotModel.SlotSign.None;
        }
    }
}