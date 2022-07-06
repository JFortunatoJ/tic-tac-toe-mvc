using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game.Player
{
    public class PlayerFactory
    {
        public HumanController LoadHumanPlayer(GameController gameController, SlotSign playerSign)
        {
            GameObject prefab = Resources.Load<GameObject>("BasePlayer");
            GameObject instance = Object.Instantiate(prefab);

            HumanController controller = instance.AddComponent<HumanController>();
            controller.Construct(new PlayerModel(playerSign), gameController);

            return controller;
        }

        public AIController LoadAiPlayer(GameController gameController, SlotSign playerSign)
        {
            GameObject prefab = Resources.Load<GameObject>("BasePlayer");
            GameObject instance = Object.Instantiate(prefab);

            AIController controller = instance.AddComponent<AIController>();
            controller.Construct(new PlayerModel(playerSign), gameController);

            return controller;
        }
    }
}