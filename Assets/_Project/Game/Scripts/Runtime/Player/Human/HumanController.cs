using TicTacToe.Game.Slot;
using UnityEngine;

namespace TicTacToe.Game.Player
{
    public class HumanController : PlayerController
    {
        private readonly LayerMask _slotLayer = (1 << 6);
        private bool _canPlay;
        private Camera _mainCamera;
        private Camera MainCamera
        {
            get
            {
                if (_mainCamera != null)
                {
                    return _mainCamera;
                }
                
                _mainCamera = Camera.main;
                return _mainCamera;
            }
        }

        private void Update()
        {
            if(!_canPlay) return;
            
            PlayerAction();
        }

        public override void AllowPlay()
        {
            _canPlay = true;
        }

        protected override void PlayerAction()
        {
            if(!MyTurn()) return;
            
            if(!Input.GetMouseButtonUp(0)) return;

            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, float.PositiveInfinity, _slotLayer);

            if(hit.transform == null || !hit.transform.TryGetComponent(out SlotController slot)) return;
            
            SelectSlot(slot);
        }
    }
}