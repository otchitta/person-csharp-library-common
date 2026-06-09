namespace Otchitta.Libraries.String.Format;

using System.Text;

/// <summary>
/// 要素共通関数です。
/// </summary>
internal static class ObjectUtilities {
	#region 内部メソッド定義:ToIndent
	/// <summary>
	/// 階層内容へ変換します。
	/// </summary>
	/// <param name="source">階層番号</param>
	/// <returns>階層内容</returns>
	private static string ToIndent(int source) {
		var result = new StringBuilder(source * 2);
		for (var index = 0; index < source; index ++) {
			result.Append("  ");
		}
		return result.ToString();
	}
	#endregion 内部メソッド定義:ToIndent

	#region 内部メソッド定義:ToString
	/// <summary>
	/// 表現内容へ変換します。
	/// </summary>
	/// <param name="action">変換処理</param>
	/// <param name="source">要素情報</param>
	/// <param name="indent">階層番号</param>
	private static void ToString(Action<string> action, object? source, int indent) {
		if (source == null) {
			action("NULL");
		} else if (AtomicUtilities.ToString(source, out var value1)) {
			action(value1);
		} else if (source is System.Collections.IEnumerable value2) {
			var method = source.GetType();
			#nullable disable
			action(method.FullName); // TODO 仮実装
			#nullable restore
			action(" [");
			foreach (var choose in value2) {
				action(Environment.NewLine);
				action(ToIndent(indent + 1));
				ToString(action, choose, indent + 1);
			}
			action(Environment.NewLine);
			action(ToIndent(indent));
			action("]");
		} else {
			var choose = source.GetType();
			#nullable disable
			action(choose.FullName); // TODO 仮実装
			#nullable restore
			action(" {");
			foreach (var method in choose.GetProperties()) {
				action(Environment.NewLine);
				var values = method.GetValue(source);
				action(ToIndent(indent + 1));
				action(method.Name);
				action(": ");
				ToString(action, values, indent + 1);
			}
			action(Environment.NewLine);
			action(ToIndent(indent));
			action("}");
		}
	}
	#endregion 内部メソッド定義:ToString

	#region 公開メソッド定義:ToString
	/// <summary>
	/// 構造情報へ変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <returns>変換情報</returns>
	public static string ToString(object? source) {
		var buffer = new StringBuilder();
		ToString(source => buffer.Append(source), source, 0);
		return buffer.ToString();
	}
	#endregion 公開メソッド定義:ToString
}
