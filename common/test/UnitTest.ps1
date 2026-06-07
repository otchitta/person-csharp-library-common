# ====================================================================
# 検証実行スクリプト
# ====================================================================
# 変数定義
$outputPath = "bin/Result"

# 消去処理
Remove-Item $outputPath -Recurse -Force

# 構築処理
dotnet test --collect:"XPlat Code Coverage" --results-directory $outputPath
if ($?) {
	# 検証成功
	reportgenerator -reports:"bin/Result/**/coverage.cobertura.xml" -targetdir:$outputPath -reporttypes:Html
	if ($?) {
		# 生成成功
		Start-Process bin/Result/index.html
	}
}
