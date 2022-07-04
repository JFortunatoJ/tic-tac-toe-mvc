using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game.Player
{
    public class PlayerFactory
    {
        public HumanController LoadHumanPlayer(GameController gameController, SlotModel.SlotSign playerSign)
        {
            GameObject prefab = Resources.Load<GameObject>("BasePlayer");
            GameObject instance = Object.Instantiate(prefab);
            
            HumanController controller = instance.AddComponent<HumanController>();
            controller.Construct(gameController, new PlayerModel(playerSign));

            return controller;
        }
        
        public AIController LoadAiPlayer(GameController gameController, SlotModel.SlotSign playerSign)
        {
            GameObject prefab = Resources.Load<GameObject>("BasePlayer");
            GameObject instance = Object.Instantiate(prefab);
            
            AIController controller = instance.AddComponent<AIController>();
            controller.Construct(gameController, new PlayerModel(playerSign));

            return controller;
        }
    }
}