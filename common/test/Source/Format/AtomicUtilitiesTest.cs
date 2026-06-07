namespace Otchitta.Libraries.String.Format;

/// <summary>
/// <see cref="AtomicUtilities" />検証処理です。
/// </summary>
[TestFixture]
public class AtomicUtilitiesTest {
	/// <summary>
	/// 成功一覧を生成します。
	/// </summary>
	/// <returns>成功一覧</returns>
	private static IEnumerable<TestCaseData> SuccessCase() {
		// Convert1
		yield return new TestCaseData(true,             "True" );
		yield return new TestCaseData(false,            "False");
		yield return new TestCaseData("ABC",            "\"ABC\"");
		yield return new TestCaseData("\"BC",           "\"\\\"BC\"");
		yield return new TestCaseData("A\"C",           "\"A\\\"C\"");
		yield return new TestCaseData("AB\"",           "\"AB\\\"\"");
		// Convert2
		yield return new TestCaseData(SByte.MinValue,   "-128B"                 );
		yield return new TestCaseData(SByte.MaxValue,   "127B"                  );
		yield return new TestCaseData(Byte.MinValue,    "0UB"                   );
		yield return new TestCaseData(Byte.MaxValue,    "255UB"                 );
		yield return new TestCaseData(Int16.MinValue,   "-32768S"               );
		yield return new TestCaseData(Int16.MaxValue,   "32767S"                );
		yield return new TestCaseData(UInt16.MinValue,  "0US"                   );
		yield return new TestCaseData(UInt16.MaxValue,  "65535US"               );
		yield return new TestCaseData(Int32.MinValue,   "-2147483648"           );
		yield return new TestCaseData(Int32.MaxValue,   "2147483647"            );
		yield return new TestCaseData(UInt32.MinValue,  "0U"                    );
		yield return new TestCaseData(UInt32.MaxValue,  "4294967295U"           );
		yield return new TestCaseData(Int64.MinValue,   "-9223372036854775808L" );
		yield return new TestCaseData(Int64.MaxValue,   "9223372036854775807L"  );
		yield return new TestCaseData(UInt64.MinValue,  "0UL"                   );
		yield return new TestCaseData(UInt64.MaxValue,  "18446744073709551615UL");
		// Convert3
		yield return new TestCaseData(Single.MinValue,         "-3.402823E+38"           );
		yield return new TestCaseData(Single.MaxValue,         "+3.402823E+38"           );
		yield return new TestCaseData(Single.NaN,              "(Single)NaN"             );
		yield return new TestCaseData(Single.Epsilon,          "(Single)Epsilon"         );
		yield return new TestCaseData(Single.NegativeInfinity, "(Single)-Infinity"       );
		yield return new TestCaseData(Single.PositiveInfinity, "(Single)+Infinity"       );
		yield return new TestCaseData((float)0 / 0,            "(Single)NaN"             );
		yield return new TestCaseData((float)1 / 3,            "+3.333333E-01"           );
		yield return new TestCaseData(Double.MinValue,         "-1.7976931348623200E+308");
		yield return new TestCaseData(Double.MaxValue,         "+1.7976931348623200E+308");
		yield return new TestCaseData(Double.NaN,              "(Double)NaN"             );
		yield return new TestCaseData(Double.Epsilon,          "(Double)Epsilon"         );
		yield return new TestCaseData(Double.NegativeInfinity, "(Double)-Infinity"       );
		yield return new TestCaseData(Double.PositiveInfinity, "(Double)+Infinity"       );
		yield return new TestCaseData((double)0 / 0,           "(Double)NaN"             );
		yield return new TestCaseData((double)1 / 3,           "+3.3333333333333300E-01" );
		yield return new TestCaseData(Decimal.MinValue,        "-7.9228162514264338E+28M");
		yield return new TestCaseData(Decimal.MaxValue,        "+7.9228162514264338E+28M");

		yield return new TestCaseData(DateOnly.MinValue, "0001-01-01");
		yield return new TestCaseData(DateOnly.MaxValue, "9999-12-31");
		yield return new TestCaseData(TimeOnly.MinValue, "00:00:00.000000");
		yield return new TestCaseData(TimeOnly.MaxValue, "23:59:59.999999");

		yield return new TestCaseData(TimeSpan.Zero,             "+000.00:00:00.0000000");
		yield return new TestCaseData(TimeSpan.MinValue,         "-10675199.02:48:05.4775808");
		yield return new TestCaseData(TimeSpan.MaxValue,         "+10675199.02:48:05.4775807");
		yield return new TestCaseData(TimeSpan.FromDays(+365.5), "+365.12:00:00.0000000");
		yield return new TestCaseData(TimeSpan.FromDays(-365.5), "-365.12:00:00.0000000");
		yield return new TestCaseData(TimeSpan.FromHours(+26.5), "+001.02:30:00.0000000");
		yield return new TestCaseData(TimeSpan.FromHours(-26.5), "-001.02:30:00.0000000");
	}
	/// <summary>
	/// 成功処理を検証します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <param name="expect">想定情報</param>
	[Test]
	[TestCaseSource(nameof(SuccessCase))]
	public void SuccessCode(object source, string expect) {
		Assert.That(AtomicUtilities.ToString(source, out var actual), Is.True);
		Assert.That(actual, Is.EqualTo(expect));
	}
	/// <summary>
	/// 失敗処理を検証します。
	/// </summary>
	[Test]
	public void FailureCode() {
		using (Assert.EnterMultipleScope()) {
			Assert.That(AtomicUtilities.ToString(new object(), out var actual), Is.False);
			Assert.That(actual, Is.Null);
		}
	}
}
