using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game.Board
{
    public class BoardController : BaseController<BoardModel, BoardView>
    {
        public void InstantiateBoard()
        {
            model.boardGrid = new SlotController[model.boardWidth, model.boardHeight];

            for (int h = 0; h < model.boardWidth; h++)
            {
                for (int w = 0; w < model.boardHeight; w++)
                {
                    SlotController newSlot = View.InstantiateNewSlot(new Vector2(model.slotSize * w - model.slotSize,
                        model.slotSize * h - model.slotSize));
                    newSlot.gameObject.name = $"Slot ({w}, {h})";
                    model.boardGrid[w, h] = newSlot;
                }
            }
        }

        public SlotModel.SlotSign GetWinnerSign()
        {
            for (int i = 0; i < 3; i++)
            {
                if (model.boardGrid[i, 0].Sign == SlotModel.SlotSign.None)
                {
                    continue;
                }

                if (model.boardGrid[i, 0].Sign == model.boardGrid[i, 1].Sign &&
                    model.boardGrid[i, 1].Sign == model.boardGrid[i, 2].Sign)
                {
                    return model.boardGrid[i, 0].Sign;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (model.boardGrid[0, i].Sign == SlotModel.SlotSign.None)
                {
                    continue;
                }

                if (model.boardGrid[0, i].Sign == model.boardGrid[1, i].Sign &&
                    model.boardGrid[1, i].Sign == model.boardGrid[2, i].Sign)
                {
                    return model.boardGrid[i, 0].Sign;
                }
            }

            if (model.boardGrid[0, 0].Sign != SlotModel.SlotSign.None &&
                model.boardGrid[0, 0].Sign == model.boardGrid[1, 1].Sign &&
                model.boardGrid[1, 1].Sign == model.boardGrid[2, 2].Sign)
            {
                return model.boardGrid[0, 0].Sign;
            }

            if (model.boardGrid[2, 0].Sign != SlotModel.SlotSign.None &&
                model.boardGrid[2, 0].Sign == model.boardGrid[1, 1].Sign &&
                model.boardGrid[1, 1].Sign == model.boardGrid[0, 2].Sign)
            {
                return model.boardGrid[2, 0].Sign;
            }

            return SlotModel.SlotSign.None;
        }

        public bool AllSlotsWereFilled()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (model.boardGrid[i, j].Sign == SlotModel.SlotSign.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}