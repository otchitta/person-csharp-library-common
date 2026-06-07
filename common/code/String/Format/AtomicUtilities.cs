namespace Otchitta.Libraries.String.Format;

using System.Globalization;
using static System.String;

/// <summary>
/// 根源共通関数です。
/// </summary>
internal static class AtomicUtilities {
	#region 内部メソッド定義:ToString
	/// <summary>
	/// 要素情報を変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <returns>変換情報</returns>
	private static string ToString(string source) {
		var result = source.Replace("\\", "\\\\")
		                   .Replace("\t", "\\t")
		                   .Replace("\r", "\\r")
		                   .Replace("\n", "\\n")
		                   .Replace("\"", "\\\"");
		return $"\"{result}\"";
	}
	/// <summary>
	/// 要素情報を変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <returns>変換情報</returns>
	private static string ToString(float source) {
		if (Single.IsNaN(source))                   return "(Single)NaN";
		else if (Single.IsPositiveInfinity(source)) return "(Single)+Infinity";
		else if (Single.IsNegativeInfinity(source)) return "(Single)-Infinity";
		else if (Single.Epsilon == source)          return "(Single)Epsilon";
		else                                        return source.ToString("+0.000000E+00;-0.000000E+00;+0.000000E+00", CultureInfo.InvariantCulture);
	}
	/// <summary>
	/// 要素情報を変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <returns>変換情報</returns>
	private static string ToString(double source) {
		if (Double.IsNaN(source))                   return "(Double)NaN";
		else if (Double.IsPositiveInfinity(source)) return "(Double)+Infinity";
		else if (Double.IsNegativeInfinity(source)) return "(Double)-Infinity";
		else if (Double.Epsilon == source)          return "(Double)Epsilon";
		else                                        return source.ToString("+0.0000000000000000E+00;-0.0000000000000000E+00;+0.0000000000000000E+00", CultureInfo.InvariantCulture);
	}
	/// <summary>
	/// 要素情報を変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <returns>変換情報</returns>
	private static string ToString(decimal source) {
		return source.ToString("+0.0000000000000000E+00'M';-0.0000000000000000E+00'M';+0.0000000000000000E+00'M'", CultureInfo.InvariantCulture);
	}
	/// <summary>
	/// 要素情報を変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <returns>変換情報</returns>
	private static string ToString(TimeSpan source) {
		if (source < TimeSpan.Zero) {
			return source.ToString("\\-ddd\\.hh\\:mm\\:ss\\.fffffff");
		} else {
			return source.ToString("\\+ddd\\.hh\\:mm\\:ss\\.fffffff");
		}
	}
	#endregion 内部メソッド定義:ToString

	#region 内部メソッド定義:Convert0
	/// <summary>
	/// 文字情報を取得します。
	/// </summary>
	/// <param name="source">抽出処理</param>
	/// <param name="prefix">接頭文字</param>
	/// <param name="suffix">接尾文字</param>
	/// <returns>文字情報</returns>
	private static string Convert0(Func<string> source, string prefix, string suffix) {
		return $"{prefix}{source()}{suffix}";
	}
	/// <summary>
	/// 文字情報を取得します。
	/// </summary>
	/// <param name="source">整形処理</param>
	/// <param name="format">整形内容</param>
	/// <returns>文字情報</returns>
	private static string Convert0(Func<string, CultureInfo, string> source, string format) {
		return source(format, CultureInfo.InvariantCulture);
	}
	#endregion 内部メソッド定義:Convert0

	#region 内部メソッド定義:Convert1/Convert2/Convert3/Convert4
	/// <summary>
	/// 基本情報へ変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <param name="result">変換情報</param>
	/// <returns><paramref name="source" />の変換に成功した場合、<c>True</c>を返却</returns>
	private static bool Convert1(object source, [MaybeNullWhen(false)]out string result) {
		if      (source is bool   phaseA) { result = phaseA.ToString(); return true; }
		else if (source is string phaseB) { result = ToString(phaseB); return true; }
		else                              { result = default; return false; }
	}
	/// <summary>
	/// 整数情報へ変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <param name="result">変換情報</param>
	/// <returns><paramref name="source" />の変換に成功した場合、<c>True</c>を返却</returns>
	private static bool Convert2(object source, [MaybeNullWhen(false)]out string result) {
		if      (source is sbyte  phaseA) { result = Convert0(phaseA.ToString, Empty, "B");  return true;  }
		else if (source is byte   phaseB) { result = Convert0(phaseB.ToString, Empty, "UB"); return true;  }
		else if (source is short  phaseC) { result = Convert0(phaseC.ToString, Empty, "S");  return true;  }
		else if (source is ushort phaseD) { result = Convert0(phaseD.ToString, Empty, "US"); return true;  }
		else if (source is int    phaseE) { result = Convert0(phaseE.ToString, Empty, "");   return true;  }
		else if (source is uint   phaseF) { result = Convert0(phaseF.ToString, Empty, "U");  return true;  }
		else if (source is long   phaseG) { result = Convert0(phaseG.ToString, Empty, "L");  return true;  }
		else if (source is ulong  phaseH) { result = Convert0(phaseH.ToString, Empty, "UL"); return true;  }
		else                              { result = default;                                return false; }
	}
	/// <summary>
	/// 実数情報へ変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <param name="result">変換情報</param>
	/// <returns><paramref name="source" />の変換に成功した場合、<c>True</c>を返却</returns>
	private static bool Convert3(object source, [MaybeNullWhen(false)]out string result) {
		if      (source is float   phaseA) { result = ToString(phaseA); return true;  }
		else if (source is double  phaseB) { result = ToString(phaseB); return true;  }
		else if (source is decimal phaseC) { result = ToString(phaseC); return true;  }
		else                               { result = default;          return false; }
	}
	/// <summary>
	/// 時間情報へ変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <param name="result">変換情報</param>
	/// <returns><paramref name="source" />の変換に成功した場合、<c>True</c>を返却</returns>
	private static bool Convert4(object source, [MaybeNullWhen(false)]out string result) {
		if      (source is DateOnly phaseA) { result = Convert0(phaseA.ToString, "yyyy-MM-dd");      return true;  }
		else if (source is TimeOnly phaseB) { result = Convert0(phaseB.ToString, "HH:mm:ss.ffffff"); return true;  }
		else if (source is TimeSpan phaseC) { result = ToString(phaseC); return true; }
		else                                { result = default;                                      return false; }
	}
	#endregion 内部メソッド定義:Convert1/Convert2/Convert3/Convert4

	#region 公開メソッド定義:TryFormat
	/// <summary>
	/// 根源情報へ変換します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <param name="result">変換情報</param>
	/// <returns><paramref name="source" />の変換に成功した場合、<c>True</c>を返却</returns>
	public static bool ToString(object source, [MaybeNullWhen(false)]out string result) {
		return Convert1(source, out result)
		    || Convert2(source, out result)
		    || Convert3(source, out result)
		    || Convert4(source, out result);
	}
	#endregion 公開メソッド定義:TryFormat
}
