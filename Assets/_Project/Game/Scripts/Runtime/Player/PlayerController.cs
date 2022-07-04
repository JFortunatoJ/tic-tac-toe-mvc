using TicTacToe.Game.Slot;

namespace TicTacToe.Game.Player
{
    public class PlayerController : BaseController<PlayerModel>
    {
        protected GameController _gameController;
        
        public void Construct(GameController gameController, PlayerModel model)
        {
            _gameController = gameController;
            this.model = model;
        }

        public virtual void AllowPlay()
        {
        }
        
        protected virtual void PlayerAction()
        {
        }

        public virtual void SelectSlot(SlotController slot)
        {
        }

        protected bool MyTurn()
        {
            return _gameController.CurrentPlayer == this;
        }
    }
}