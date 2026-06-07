namespace Otchitta.Libraries.String.Format;

public class ObjectUtilitiesTest {
	#region 内部メソッド定義
	/// <summary>
	/// 検証情報を生成します。
	/// </summary>
	/// <returns></returns>
	private static ObjectUtilitiesTest New() {
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
	/// <see cref="ObjectUtilities.ToString(object?)" />を検証します。
	/// </summary>
	[Test]
	public void TestToStringA() {
		using (Assert.EnterMultipleScope()) {
			Assert.That(ObjectUtilities.ToString(null), Is.EqualTo("NULL"));
			Assert.That(ObjectUtilities.ToString(1234), Is.EqualTo("1234"));
			Assert.That(ObjectUtilities.ToString(new()), Is.EqualTo("(System.Object)System.Object"));
			Assert.That(ObjectUtilities.ToString(New()), Is.EqualTo("(Otchitta.Libraries.String.Format.ObjectUtilitiesTest)NULL"));

			Assert.That(ObjectUtilities.ToString(new Exception("S")), Is.EqualTo("(System.Exception)System.Exception: S"));
		}
	}
	#endregion 検証メソッド定義
}
