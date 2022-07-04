using System;
using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game.Board
{
    public class BoardView : BaseView
    {
        [Space]
        [SerializeField] private SlotController _slotPrefab;
        [SerializeField] private Transform _slotsHolder;

        public SlotController InstantiateNewSlot(Vector2 position)
        {
            SlotController newSlot = Instantiate(_slotPrefab, _slotsHolder);
            newSlot.View.Position = position;

            return newSlot;
        }
    }
}