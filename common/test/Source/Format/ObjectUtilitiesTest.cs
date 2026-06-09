namespace Otchitta.Libraries.String.Format;

/// <summary>
/// <see cref="ObjectUtilities" />検証処理です。
/// </summary>
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
			Assert.That(ObjectUtilities.ToString(new()), Is.EqualTo($"System.Object {{{Environment.NewLine}}}"));
			Assert.That(ObjectUtilities.ToString(New()), Is.EqualTo($"Otchitta.Libraries.String.Format.ObjectUtilitiesTest {{{Environment.NewLine}}}"));
			Assert.That(ObjectUtilities.ToString(new string[] {"AA", "BB"}), Is.EqualTo(@"System.String[] [
  ""AA""
  ""BB""
]"));
			Assert.That(ObjectUtilities.ToString(new Exception("S")), Is.EqualTo(@"System.Exception {
  TargetSite: NULL
  Message: ""S""
  Data: System.Collections.ListDictionaryInternal [
  ]
  InnerException: NULL
  HelpLink: NULL
  Source: NULL
  HResult: -2146233088
  StackTrace: NULL
}"));
			Assert.That(ObjectUtilities.ToString(new Exception("1", new Exception("S"))), Is.EqualTo(@"System.Exception {
  TargetSite: NULL
  Message: ""1""
  Data: System.Collections.ListDictionaryInternal [
  ]
  InnerException: System.Exception {
    TargetSite: NULL
    Message: ""S""
    Data: System.Collections.ListDictionaryInternal [
    ]
    InnerException: NULL
    HelpLink: NULL
    Source: NULL
    HResult: -2146233088
    StackTrace: NULL
  }
  HelpLink: NULL
  Source: NULL
  HResult: -2146233088
  StackTrace: NULL
}"));
		}
	}
	#endregion 検証メソッド定義
}
