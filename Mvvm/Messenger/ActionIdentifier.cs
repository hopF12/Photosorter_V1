using System;

namespace Mvvm.Messenger
{
    public class ActionIdentifier
    {
        public WeakReferenceAction Action { get; set; }
        public string IdentificationCode { get; set; }
    }

    public class WeakReferenceAction<T> : WeakReferenceAction, IActionParameter
    {
        public WeakReferenceAction(object target, Action<T> action)
            : base(target, null)
        {
            Action = action;
        }

        public new void Execute()
        {
            if (Action != null && Target != null && Target.IsAlive)
                Action(default(T));
        }

        public void Execute(T parameter)
        {
            if (Action != null && Target != null && Target.IsAlive)
                Action(parameter);
        }

        public Action<T> Action { get; }

        public void ExecuteWithParameter(object parameter)
        {
            Execute((T)parameter);
        }
    }
}