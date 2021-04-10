using System;
using System.Collections.Generic;
using System.Linq;

namespace TupleMerger
{
    public class TupleMerger
    {
        public List<object> Tuples { get; private set; }

        public TupleMerger()
        {
            Tuples = new List<object>();
        }

        public void Add<T1>(Tuple<T1> tuple)
        {
            Tuples.Add(tuple);
        }

        public void Add<T1, T2>(Tuple<T1, T2> tuple)
        {
            Tuples.Add(tuple);
        }

        public void Add<T1, T2, T3>(Tuple<T1, T2, T3> tuple)
        {
            Tuples.Add(tuple);
        }

        public void Add<T1, T2, T3, T4>(Tuple<T1, T2, T3, T4> tuple)
        {
            Tuples.Add(tuple);
        }

        public void Add<T1, T2, T3, T4, T5>(Tuple<T1, T2, T3, T4, T5> tuple)
        {
            Tuples.Add(tuple);
        }

        public void Add<T1, T2, T3, T4, T5, T6>(Tuple<T1, T2, T3, T4, T5, T6> tuple)
        {
            Tuples.Add(tuple);
        }

        public void Add<T1, T2, T3, T4, T5, T6, T7>(Tuple<T1, T2, T3, T4, T5, T6, T7> tuple)
        {
            Tuples.Add(tuple);
        }


        public object Merge()
        {
            var values = Array.Empty<string>();

            foreach (var t in Tuples)
            {
                if (t.GetType().GetFields().Any())
                {
                    var valuesFromFields = t.GetType().GetFields().Select(x => x.GetValue(t).ToString()).ToArray();
                    values = values.Concat(valuesFromFields).ToArray();
                }

                if (t.GetType().GetProperties().Any())
                {
                    var valuesFromProperties = t.GetType().GetProperties().Select(x => x.GetValue(t).ToString()).ToArray();
                    values = values.Concat(valuesFromProperties).ToArray();
                }
            }


            switch (values.Length)
            {
                case 0: return default(ValueTuple);
                case 1: return Tuple.Create(values[0]);
                case 2: return (values[0], values[1]);
                case 3: return (values[0], values[1], values[2]);
                case 4: return (values[0], values[1], values[2], values[3]);
                case 5: return (values[0], values[1], values[2], values[3], values[4]);
                case 6: return (values[0], values[1], values[2], values[3], values[4], values[5]);
                case 7: return (values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
                case 8: return (values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
            }

            return new ArgumentException($"The tuple cannot be created. There are {values.Length} elements.");

        }
    }
}
