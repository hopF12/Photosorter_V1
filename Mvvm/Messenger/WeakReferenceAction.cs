using System;

namespace Mvvm.Messenger
{
    public class WeakReferenceAction
    {
        private Action _action;

        protected WeakReferenceAction(object target, Action action)
        {
            Target = new WeakReference(target);
            _action = action;
        }

        public WeakReference Target { get; private set; }

        public void Execute()
        {
            if (_action != null && Target != null && Target.IsAlive)
                _action.Invoke();
        }

        public void Unload()
        {
            Target = null;
            _action = null;
        }
    }
}