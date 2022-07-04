using UnityEngine;

namespace TicTacToe.Game
{
    public class BaseController<TM, TV> : MonoBehaviour where TM : BaseModel where TV : BaseView
    {
        public TM model;

        public TV View { get; private set; }

        protected void Awake()
        {
            View = GetComponent<TV>();
        }
    }
    
    public class BaseController<TM> : MonoBehaviour where TM : BaseModel
    {
        public TM model;
    }
}