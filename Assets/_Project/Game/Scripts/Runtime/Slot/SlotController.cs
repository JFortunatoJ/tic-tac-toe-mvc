using System;

namespace TicTacToe.Game.Slot
{
    public class SlotController : BaseController<SlotModel, SlotView>
    {
        public Action<SlotController> OnTap { get; set; }

        public SlotModel.SlotSign Sign
        {
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

        private void OnMouseUpAsButton()
        {
            if (!CanInteractWithSlot()) return;

            OnTap?.Invoke(this);
        }
    }
}