using System.Collections.Generic;
using System.Linq;

namespace IvmGraph.Reactive
{
    public static partial class Unions
    {
        #region [ CombineLatest<T1, T2> ]
        
        public static Observable<(T1, T2)> CombineLatest<T1, T2>(Observable<T1> o1, Observable<T2> o2)
        {
            List<bool> valuesInitialized = Enumerable.Range(1, 2).Select(x => false).ToList();

            T1? value1 = default(T1);
            T2? value2 = default(T2);
            
            Observable<(T1, T2)> result = new();
            
            o1.OnChange(x =>
            {
                value1 = x;
                valuesInitialized[0] = true;

                if (!valuesInitialized.All(yes => yes)) return;
                if (value2 != null) { result.Next((value1, value2)); }
            });
            
            o2.OnChange(x =>
            {
                value2 = x;
                valuesInitialized[1] = true;

                if (!valuesInitialized.All(yes => yes)) return;
                if (value1 != null) { result.Next((value1, value2)); }
            });
            
            return result;
        }
        
        #endregion
        
        #region [ CombineLatest<T1, T2, T3> ]
        
        public static Observable<(T1, T2, T3)> CombineLatest<T1, T2, T3>(Observable<T1> o1, Observable<T2> o2, Observable<T3> o3)
        {
            List<bool> valuesInitialized = Enumerable.Range(1, 3).Select(x => false).ToList();

            T1? value1 = default(T1);
            T2? value2 = default(T2);
            T3? value3 = default(T3);
            
            Observable<(T1, T2, T3)> result = new();
            
            o1.OnChange(x =>
            {
                value1 = x;
                valuesInitialized[0] = true;

                if (!valuesInitialized.All(yes => yes)) return;
                if (value2 != null && value3 != null) { result.Next((value1, value2, value3)); }
            });
            
            o2.OnChange(x =>
            {
                value2 = x;
                valuesInitialized[1] = true;

                if (!valuesInitialized.All(yes => yes)) return;
                if (value1 != null && value3 != null) { result.Next((value1, value2, value3)); }
            });
            
            o3.OnChange(x =>
            {
                value3 = x;
                valuesInitialized[2] = true;

                if (!valuesInitialized.All(yes => yes)) return;
                if (value1 != null && value2 != null) { result.Next((value1, value2, value3)); }
            });
            
            return result;
        }

        #endregion
        
        
        #region [ CombineLatest<T1, T2, T3, T4> ]
        
        public static Observable<(T1, T2, T3, T4)> CombineLatest<T1, T2, T3, T4>(Observable<T1> o1, Observable<T2> o2, Observable<T3> o3, Observable<T4> o4)
        {
            List<bool> valuesInitialized = Enumerable.Range(1, 4).Select(x => false).ToList();

            T1? value1 = default(T1);
            T2? value2 = default(T2);
            T3? value3 = default(T3);
            T4? value4 = default(T4);
            
            Observable<(T1, T2, T3, T4)> result = new();
            
            o1.OnChange(x =>
            {
                value1 = x;
                valuesInitialized[0] = true;

                if (!valuesInitialized.All(yes => yes)) return;
                if (value2 != null && value3 != null && value4 != null) { result.Next((value1, value2, value3, value4)); }
            });
            
            o2.OnChange(x =>
            {
                value2 = x;
                valuesInitialized[1] = true;

                if (!valuesInitialized.All(yes => yes)) return;
                if (value1 != null && value3 != null && value4 != null) { result.Next((value1, value2, value3, value4)); }
            });
            
            o3.OnChange(x =>
            {
                value3 = x;
                valuesInitialized[2] = true;

                if (!valuesInitialized.All(yes => yes)) return;
                if (value1 != null && value2 != null && value4 != null) { result.Next((value1, value2, value3, value4)); }
            });
            
            o4.OnChange(x =>
            {
                value4 = x;
                valuesInitialized[3] = true;

                if (!valuesInitialized.All(yes => yes)) return;
                if (value1 != null && value2 != null && value3 != null) { result.Next((value1, value2, value3, value4)); }
            });
            
            return result;
        }

        #endregion
    }
}
