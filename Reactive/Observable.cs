using System;
using System.Collections.Generic;

namespace IvmGraph.Reactive
{

    public class Observable<TValue>: IDisposable
    {
        private readonly List<Action<TValue>> _actions = new();
        
        public void Next(TValue value)
        {
            foreach (Action<TValue> action in _actions)
            {
                action.Invoke(value);
            }
        }
        
        public void OnChange(Action<TValue> action)
        {
            if (_actions.Contains(action))
            {
                this._actions.Remove(action);
            }
            
            _actions.Add(action);
        }

        public void Dispose()
        {
            this._actions.Clear();
        }
    }

}
