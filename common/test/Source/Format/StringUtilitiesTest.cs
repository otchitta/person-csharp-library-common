namespace Otchitta.Libraries.String.Format;

/// <summary>
/// <see cref="StringUtilities" />検証処理です。
/// </summary>
public class StringUtilitiesTest {
	#region 検証メソッド定義:ToString
	/// <summary>
	/// <see cref="StringUtilities.ToString(object?)" />検証処理です。
	/// </summary>
	[TestFixture]
	public sealed class ToStringTest {
		#region 内部メソッド定義
		/// <summary>
		/// 検証情報を生成します。
		/// </summary>
		/// <returns></returns>
		private static ToStringTest New() {
			return new();
		}
		#endregion 内部メソッド定義

		#region 実装メソッド定義
		/// <summary>
		/// 当該情報を表現文字列へ変換します。
		/// </summary>
		/// <returns></returns>
		public override string? ToString() {
			return null;
		}
		#endregion 実装メソッド定義

		#region 検証メソッド定義
		/// <summary>
		/// <see cref="StringUtilities.ToString(object?)" />を検証します。
		/// </summary>
		[Test]
		public void TestToStringA() {
			using (Assert.EnterMultipleScope()) {
				Assert.That(StringUtilities.ToString(null), Is.EqualTo("NULL"));
				Assert.That(StringUtilities.ToString(1234), Is.EqualTo("(System.Int32)1234"));
				Assert.That(StringUtilities.ToString(new()), Is.EqualTo("(System.Object)System.Object"));
				Assert.That(StringUtilities.ToString(New()), Is.EqualTo("(Otchitta.Libraries.String.Format.StringUtilitiesTest+ToStringTest)NULL"));
			}
		}
		#endregion 検証メソッド定義
	}
	#endregion 検証メソッド定義:ToString
}
