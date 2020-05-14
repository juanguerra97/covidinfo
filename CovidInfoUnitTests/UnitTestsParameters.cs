using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CovidInfoUnitTests
{
    class FiltrarPorFechaData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, new DateTime(2020, 01, 01) };
            yield return new object[] { 1, new DateTime(2020, 03, 14) };
            yield return new object[] { 3, new DateTime(2020, 03, 17) };
            yield return new object[] { 3, new DateTime(2020, 03, 18) };
            yield return new object[] { 1, new DateTime(2020, 03, 19) };
            yield return new object[] { 1, new DateTime(2020, 03, 21) };
            yield return new object[] { 1, new DateTime(2020, 03, 28) };
            yield return new object[] { 1, new DateTime(2020, 03, 30) };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
