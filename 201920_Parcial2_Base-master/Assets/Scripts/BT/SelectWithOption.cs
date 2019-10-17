using UnityEngine;

namespace AI
{
    public abstract class SelectWithOption : Node
    {
        [SerializeField]
        private Node successTree;

        [SerializeField]
        private Node failTree;

        public abstract bool Check();

        public override void Execute()
        {
            if (Check())
            {
                successTree.Execute();
            }
            else
            {
                failTree.Execute();
            }
        }
    }
}