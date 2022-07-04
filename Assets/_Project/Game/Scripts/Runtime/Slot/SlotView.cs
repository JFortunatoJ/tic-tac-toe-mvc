using TMPro;
using UnityEngine;

namespace TicTacToe.Game.Slot
{
    public class SlotView : BaseView
    {
        [SerializeField]
        private TextMeshPro _singText;

        public Vector2 Position
        {
            set => transform.position = value;
        }

        public SlotModel.SlotSign Sign
        {
            set
            {
                switch (value)
                {
                    case SlotModel.SlotSign.None:
                        _singText.text = string.Empty;
                        break;
                    case SlotModel.SlotSign.O:
                        _singText.text = "O";
                        break;
                    case SlotModel.SlotSign.X:
                        _singText.text = "X";
                        break;
                }
            }
        }
    }
}