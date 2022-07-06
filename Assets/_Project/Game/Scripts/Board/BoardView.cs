using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game.Board
{
    public class BoardView : BaseView
    {
        [Space]
        [SerializeField] private SlotController _slotPrefab;
        [SerializeField] private Transform _slotsHolder;

        public SlotController InstantiateNewSlot(Vector2 position, Vector2Int boardPosition)
        {
            SlotController newSlot = Instantiate(_slotPrefab, _slotsHolder);
            newSlot.gameObject.name = $"Slot ({boardPosition.x}, {boardPosition.y})";
            newSlot.View.Position = position;

            return newSlot;
        }
    }
}