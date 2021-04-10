using System;
using System.Globalization;
using Xunit;

namespace TupleMerger.Tests
{
    public class TupleMergerTest
    {
        private TupleMerger _tupleMerger;

        public TupleMergerTest()
        {
            _tupleMerger = new TupleMerger();
        }

        [Fact]
        public void Add_TupleSimpleItemString_GetCountItems()
        {
            var tuple = Tuple.Create("Starwars");
            _tupleMerger.Add<string>(tuple);

            Assert.Single(_tupleMerger.Tuples);
        }

        [Fact]
        public void Add_TwoTuplesWith1ItemString_GetCountItems()
        {
            var tuple1 = Tuple.Create("Episode IV - A New Hope");
            var tuple2 = Tuple.Create("Episode V – The Empire Strikes Back");

            _tupleMerger.Add<string>(tuple1);
            _tupleMerger.Add<string>(tuple2);

            Assert.Equal(2, _tupleMerger.Tuples.Count);
        }


        [Fact]
        public void Add_TupleWith2ItemsString_GetCountItems()
        {
            var tuple = Tuple.Create("Episode IV - A New Hope", "1977");
            _tupleMerger.Add<string, string>(tuple);
            Assert.Single(_tupleMerger.Tuples);
        }


        [Fact]
        public void Add_TupleWith3ItemsString_GetCountItems()
        {
            var tuple = Tuple.Create("Episode IV - A New Hope", "1977", "1977-04-25");
            _tupleMerger.Add<string, string, string>(tuple);
            Assert.Single(_tupleMerger.Tuples);
        }

        [Fact]
        public void Add_TupleWith4ItemsString_GetCountItems()
        {
            var tuple = Tuple.Create("Episode IV - A New Hope", "1977", "1977-04-25", "George Lucas");
            _tupleMerger.Add<string, string, string, string>(tuple);
            Assert.Single(_tupleMerger.Tuples);
        }

        [Fact]
        public void Add_TupleWith5ItemsString_GetCountItems()
        {
            var tuple = Tuple.Create("Episode IV - A New Hope", "1977", "1977-04-25", "George Lucas", "value5");
            _tupleMerger.Add<string, string, string, string, string>(tuple);
            Assert.Single(_tupleMerger.Tuples);
        }

        [Fact]
        public void Add_TupleWith6ItemsString_GetCountItems()
        {
            var tuple = Tuple.Create("Episode IV - A New Hope", "1977", "1977-04-25", "George Lucas", "value5", "value6");
            _tupleMerger.Add<string, string, string, string, string, string>(tuple);
            Assert.Single(_tupleMerger.Tuples);
        }

        [Fact]
        public void Add_TupleWith7ItemsString_GetCountItems()
        {
            var tuple = Tuple.Create("Episode IV - A New Hope", "1977", "1977-04-25", "George Lucas", "value5", "value6", "value7");
            _tupleMerger.Add<string, string, string, string, string, string, string>(tuple);
            Assert.Single(_tupleMerger.Tuples);
        }


        [Fact]
        public void Add_TupleWithDifferentsItems_GetCountItems()
        {
            var tuple1 = Tuple.Create("Episode IV - A New Hope");
            var tuple2 = Tuple.Create("Episode V – The Empire Strikes Back", "1980");

            _tupleMerger.Add<string>(tuple1);
            _tupleMerger.Add<string, string>(tuple2);

            Assert.Equal(2, _tupleMerger.Tuples.Count);
        }

        [Fact]
        public void Add_2TupleWithDifferentsItemsTypes_GetCountItems()
        {
            var tuple1 = Tuple.Create("Episode IV - A New Hope", 1977);
            var tuple2 = Tuple.Create("Episode V – The Empire Strikes Back", new DateTime(1980, 4, 21));

            _tupleMerger.Add<string, int>(tuple1);
            _tupleMerger.Add<string, DateTime>(tuple2);

            Assert.Equal(2, _tupleMerger.Tuples.Count);
        }

        [Fact]
        public void Add_3TupleWithDifferentsItemsTypes_GetCountItems()
        {
            var tuple1 = Tuple.Create("Episode IV - A New Hope", 1977);
            var tuple2 = Tuple.Create("Episode V – The Empire Strikes Back", new DateTime(1980, 4, 21));
            var tuple3 = Tuple.Create("Episode VI – Return of the Jedi", (long)1983);

            _tupleMerger.Add<string, int>(tuple1);
            _tupleMerger.Add<string, DateTime>(tuple2);
            _tupleMerger.Add<string, long>(tuple3);

            Assert.Equal(3, _tupleMerger.Tuples.Count);
        }

        [Fact]
        public void Merge_EmptyTuples_GetEmptyTupleString()
        {
            var result = _tupleMerger.Merge();

            Assert.Empty(_tupleMerger.Tuples);
            Assert.NotNull(result);
            Assert.Equal("()", result.ToString());
        }


        [Fact]
        public void Merge_1TupleWith1Item_GetTupleStringAndVerifyItemProperty()
        {
            var tuple1 = Tuple.Create("Episode IV - A New Hope");

            _tupleMerger.Add<string>(tuple1);

            var result = _tupleMerger.Merge();

            Tuple<string> resultTuple = (Tuple<string>)result;

            Assert.Single(_tupleMerger.Tuples);
            Assert.Equal("Episode IV - A New Hope", resultTuple.Item1);
            Assert.Equal("(Episode IV - A New Hope)", result.ToString());
        }

        [Fact]
        public void Merge_2TuplesWith1Item_GetTupleStringAndVerifyItemProperty()
        {
            var tuple1 = Tuple.Create("Episode IV - A New Hope");
            var tuple2 = Tuple.Create("Episode V – The Empire Strikes Back");

            _tupleMerger.Add<string>(tuple1);
            _tupleMerger.Add<string>(tuple2);

            var result = _tupleMerger.Merge();

            (string, string) resultTuple = ((string, string))result;

            Assert.Equal(2, _tupleMerger.Tuples.Count);
            Assert.Equal("Episode IV - A New Hope", resultTuple.Item1);
            Assert.Equal("Episode V – The Empire Strikes Back", resultTuple.Item2);
            Assert.Equal("(Episode IV - A New Hope, Episode V – The Empire Strikes Back)", resultTuple.ToString());
        }

        [Fact]
        public void Merge_3TuplesWith1Item_GetTupleStringAndVerifyItemProperty()
        {
            var tuple1 = Tuple.Create("Episode IV - A New Hope");
            var tuple2 = Tuple.Create("Episode V – The Empire Strikes Back");
            var tuple3 = Tuple.Create("Episode VI – Return of the Jedi");

            _tupleMerger.Add<string>(tuple1);
            _tupleMerger.Add<string>(tuple2);
            _tupleMerger.Add<string>(tuple3);

            var result = _tupleMerger.Merge();

            (string, string, string) resultTuple = ((string, string, string))result;

            Assert.Equal(3, _tupleMerger.Tuples.Count);

            Assert.Equal("Episode IV - A New Hope", resultTuple.Item1);
            Assert.Equal("Episode V – The Empire Strikes Back", resultTuple.Item2);
            Assert.Equal("Episode VI – Return of the Jedi", resultTuple.Item3);

            Assert.Equal("(Episode IV - A New Hope, Episode V – The Empire Strikes Back, Episode VI – Return of the Jedi)", resultTuple.ToString());
        }


        [Fact]
        public void Merge_2TuplesWithDifferentItemsTypes_GetTupleStringAndVerifyItemProperty()
        {
            var tuple1 = Tuple.Create("Episode IV - A New Hope", 1977);
            var tuple2 = Tuple.Create("Episode V – The Empire Strikes Back");

            _tupleMerger.Add<string, int>(tuple1);
            _tupleMerger.Add<string>(tuple2);

            var result = _tupleMerger.Merge();

            (string, string, string) resultTuple = ((string, string, string))result;

            Assert.Equal(2, _tupleMerger.Tuples.Count);
            Assert.Equal("Episode IV - A New Hope", resultTuple.Item1);
            Assert.Equal("1977", resultTuple.Item2);
            Assert.Equal("Episode V – The Empire Strikes Back", resultTuple.Item3);
            Assert.Equal("(Episode IV - A New Hope, 1977, Episode V – The Empire Strikes Back)", resultTuple.ToString());

        }


        [Fact]
        public void Merge_2TuplesWithDifferentItemsTypesStringIntDouble_GetTupleStringAndVerifyItemProperty()
        {

            var tuple1 = Tuple.Create("Episode IV - A New Hope", 1977);
            var tuple2 = Tuple.Create("Episode V – The Empire Strikes Back", 1980, 1234.56);

            _tupleMerger.Add<string, int>(tuple1);
            _tupleMerger.Add<string, int, double>(tuple2);

            var result = _tupleMerger.Merge();

            (string, string, string, string, string) resultTuple =
                                ((string, string, string, string, string))result;

            Assert.Equal(2, _tupleMerger.Tuples.Count);

            Assert.Equal("Episode IV - A New Hope", resultTuple.Item1);
            Assert.Equal("1977", resultTuple.Item2);
            Assert.Equal("Episode V – The Empire Strikes Back", resultTuple.Item3);
            Assert.Equal("1980", resultTuple.Item4);
            Assert.Equal("1234,56", resultTuple.Item5);

            Assert.Equal("(Episode IV - A New Hope, 1977, Episode V – The Empire Strikes Back, 1980, 1234,56)", resultTuple.ToString());
        }
    }
}
