namespace Otchitta.Libraries.String.Format;

/// <summary>
/// 文字共通関数です。
/// </summary>
public static class StringUtilities {
	/// <summary>
	/// 構造情報へ変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <returns>変換情報</returns>
	public static string ToString(object? source) {
		return ObjectUtilities.ToString(source);
	}
}
