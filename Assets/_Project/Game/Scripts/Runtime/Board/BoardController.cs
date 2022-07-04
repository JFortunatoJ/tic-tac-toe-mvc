using System;
using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game.Board
{
    public class BoardController : BaseController<BoardModel, BoardView>
    {
        public Action<SlotController> OnTapSlot;

        public void InstantiateBoard()
        {
            model.boardGrid = new SlotController[model.boardWidth, model.boardHeight];
            
            for (int w = 0; w < model.boardWidth; w++)
            {
                for (int h = 0; h < model.boardHeight; h++)
                {
                    SlotController newSlot = View.InstantiateNewSlot(new Vector2(model.slotSize * w - model.slotSize, model.slotSize * h - model.slotSize));
                    newSlot.OnTap = OnTapSlot;
                    model.boardGrid[w, h] = newSlot;
                }
            }
        }

        public SlotModel.SlotSign CheckWinner()
        {
            if (model.boardGrid[0, 0].model.sign == model.boardGrid[0, 1].model.sign && model.boardGrid[0, 1].model.sign == model.boardGrid[0, 2].model.sign ||
                model.boardGrid[1, 0].model.sign == model.boardGrid[1, 1].model.sign && model.boardGrid[1, 1].model.sign == model.boardGrid[1, 2].model.sign)
            {
                return model.boardGrid[0, 0].model.sign;
            }

            return SlotModel.SlotSign.None;
        }
    }
}