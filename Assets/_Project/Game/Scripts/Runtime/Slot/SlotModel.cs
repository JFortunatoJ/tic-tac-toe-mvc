using UnityEngine;

namespace TicTacToe.Game.Slot
{
    [System.Serializable]
    public class SlotModel : BaseModel
    {
        public Vector2Int boardPosition;
        public SlotSign sign;
    }
}