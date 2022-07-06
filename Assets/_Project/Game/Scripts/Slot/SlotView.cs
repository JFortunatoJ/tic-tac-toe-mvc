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

        public SlotSign Sign
        {
            set
            {
                switch (value)
                {
                    case SlotSign.Empty:
                        _singText.text = string.Empty;
                        break;
                    case SlotSign.O:
                        _singText.text = "O";
                        break;
                    case SlotSign.X:
                        _singText.text = "X";
                        break;
                }
            }
        }
    }
}