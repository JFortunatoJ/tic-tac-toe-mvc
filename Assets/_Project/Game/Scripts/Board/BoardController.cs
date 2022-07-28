using System.Collections.Generic;
using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game.Board
{
    public class BoardController : BaseController<BoardModel, BoardView>
    {
        private Dictionary<Vector2Int, SlotController> _slotsList = new Dictionary<Vector2Int, SlotController>();

        public void InstantiateBoard()
        {
            Model.boardGrid = new SlotSign[Model.boardWidth, Model.boardHeight];

            for (int h = 0; h < Model.boardWidth; h++)
            {
                for (int w = 0; w < Model.boardHeight; w++)
                {
                    Vector2Int boardPosition = new Vector2Int(w, h);
                    SlotController newSlot = View.InstantiateNewSlot(new Vector2(
                        -Model.slotSize + (w * Model.slotSize),
                        Model.slotSize - (h * Model.slotSize)), boardPosition);

                    newSlot.Model.boardPosition = boardPosition;

                    _slotsList.Add(boardPosition, newSlot);
                }
            }
        }

        public void ClearBoard()
        {
            for (int i = 0; i < Model.boardWidth; i++)
            {
                for (int j = 0; j < Model.boardHeight; j++)
                {
                    model.boardGrid[i, j] = SlotSign.Empty;
                }
            }
            
            foreach (var slotController in _slotsList)
            {
                slotController.Value.Sign = SlotSign.Empty;
            }
        }

        public void PrintBoard()
        {
            print($"{Model.boardGrid[0, 0]}|{Model.boardGrid[1, 0]}|{Model.boardGrid[2, 0]}\n" +
                  $"{Model.boardGrid[0, 1]}|{Model.boardGrid[1, 1]}|{Model.boardGrid[2, 1]}\n" +
                  $"{Model.boardGrid[0, 2]}|{Model.boardGrid[1, 2]}|{Model.boardGrid[2, 2]}");
            
        }

        public SlotSign GetWinnerSign()
        {
            //Vertical check
            for (int i = 0; i < 3; i++)
            {
                if (Model.boardGrid[i, 0] == SlotSign.Empty)
                {
                    continue;
                }

                if (Model.boardGrid[i, 0] == Model.boardGrid[i, 1] &&
                    Model.boardGrid[i, 1] == Model.boardGrid[i, 2])
                {
                    return Model.boardGrid[i, 0];
                }
            }

            //Horizontal check
            for (int i = 0; i < 3; i++)
            {
                if (Model.boardGrid[0, i] == SlotSign.Empty)
                {
                    continue;
                }

                if (Model.boardGrid[0, i] == Model.boardGrid[1, i] &&
                    Model.boardGrid[1, i] == Model.boardGrid[2, i])
                {
                    return Model.boardGrid[0, i];
                }
            }

            //Diagonal check
            if (Model.boardGrid[0, 0] != SlotSign.Empty &&
                Model.boardGrid[0, 0] == Model.boardGrid[1, 1] &&
                Model.boardGrid[1, 1] == Model.boardGrid[2, 2])
            {
                return Model.boardGrid[0, 0];
            }

            if (Model.boardGrid[2, 0] != SlotSign.Empty &&
                Model.boardGrid[2, 0] == Model.boardGrid[1, 1] &&
                Model.boardGrid[1, 1] == Model.boardGrid[0, 2])
            {
                return Model.boardGrid[2, 0];
            }

            return SlotSign.Empty;
        }

        public void SetSlotSignAtBoard(SlotSign sign, Vector2Int boardPosition)
        {
            _slotsList[boardPosition].Sign = sign;
            Model.boardGrid[boardPosition.x, boardPosition.y] = sign;
        }

        public SlotController GetSlotByPosition(Vector2Int boardPosition)
        {
            return _slotsList[boardPosition];
        }

        public bool AllSlotsWereFilled()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Model.boardGrid[i, j] == SlotSign.Empty)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}