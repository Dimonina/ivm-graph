using System;
using System.Collections.Generic;
using System.Linq;

namespace IvmGraph.Reactive
{
    public static class Operators
    {
        /// <summary>
        /// Perform value modifications
        /// </summary>
        public static Observable<TOut> Map<TIn, TOut>(this Observable<TIn> input, Func<TIn, TOut> func) 
        {
            Observable<TOut> result = new ();
            input.OnChange(x =>
            {
                TOut funcResult = func.Invoke(x);
                result.Next(funcResult);
                
            });
            return result;
        }
        
        /// <summary>
        /// Side effect in a pipe
        /// </summary>
        public static Observable<TIn> Tap<TIn>(this Observable<TIn> input, Action<TIn> func) 
        {
            Observable<TIn> result = new ();
            input.OnChange(x =>
            {
                func.Invoke(x);
                result.Next(x);
                
            });
            return result;
        }
    }
}
