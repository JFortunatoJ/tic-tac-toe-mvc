using UnityEngine;

namespace TicTacToe.Game
{
    public class BaseController<TM, TV> : MonoBehaviour where TM : BaseModel where TV : BaseView
    {
        [SerializeField]
        protected TM model;
        public TM Model
        { 
            get => model;
            protected set => model = value;
        }

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