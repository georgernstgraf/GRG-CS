@echo off
REM Skript für die Selbstkontrolle der Arbeit
REM Führt einen dotnet restore aus, aber nicht wenn die Datei auf P: liegt (kein Internet)
REM Führt pro Aufgabe die Tests durch.
REM (c) 2025, Michael Schletz

chcp 65001 >nul
del aufgabe*test_results.xml > nul 2>&1

echo Persönliche Angaben aus README.md:
for %%L in ("Klasse:" "Vorname:" "Zuname:" "Schulaccount") do (
    for /f "delims=" %%A in ('findstr /i %%~L README.md') do (
        echo %%A
        echo %%A | findstr /i "xxx" >nul
        if not errorlevel 1 (
            echo ⚠️ Sie müssen Ihre Daten angeben, sonst kann nicht bewertet werden!
            pause
            goto restore
        )
    )
)

:restore
if /I not "%~d0"=="P:" (
    echo ℹ️ Führe dotnet restore aus...
    dotnet restore --no-cache > nul 2>&1
    if errorlevel 1 (
        echo ❌ Restore fehlgeschlagen. Abbruch.
        goto end
    )    
) else (
    echo ℹ️ dotnet restore wird übersprungen (Laufwerk P:)
)

:aufgabe1
echo.
echo ℹ️ Kompiliere und teste Aufgabe 1...
dotnet build ./test/SPG_Fachtheorie.Aufgabe1.Test --no-restore > nul
if errorlevel 1 (
    echo ❌ Build für Aufgabe 1 fehlgeschlagen. Tests werden übersprungen.
    goto aufgabe2
)
dotnet test ./test/SPG_Fachtheorie.Aufgabe1.Test -l:"trx;LogFileName=aufgabe1_test_results.xml" --results-directory . --verbosity quiet
powershell -NoProfile -Command "[xml]$xml = Get-Content 'aufgabe1_test_results.xml'; $xml.GetElementsByTagName('UnitTestResult') | Sort-Object testName | ForEach-Object { $d = [timespan]::Parse($_.duration).TotalMilliseconds; $s = if ($_.outcome -eq 'Passed') { '✅' } else { '❌' }; $name = $_.testName -replace 'SPG_Fachtheorie\.Aufgabe\d+\.Test\.', ''; Write-Output \"$s $name [$d ms]\" }"

:aufgabe2
echo.
echo ℹ️ Kompiliere und teste Aufgabe 2...
dotnet build ./test/SPG_Fachtheorie.Aufgabe2.Test --no-restore > nul
if errorlevel 1 (
    echo ❌ Build für Aufgabe 3 fehlgeschlagen. Tests werden übersprungen.
    goto aufgabe3
)
dotnet test ./test/SPG_Fachtheorie.Aufgabe2.Test -l:"trx;LogFileName=aufgabe2_test_results.xml" --results-directory . --verbosity quiet
powershell -NoProfile -Command "[xml]$xml = Get-Content 'aufgabe2_test_results.xml'; $xml.GetElementsByTagName('UnitTestResult') | Sort-Object testName | ForEach-Object { $d = [timespan]::Parse($_.duration).TotalMilliseconds; $s = if ($_.outcome -eq 'Passed') { '✅' } else { '❌' }; $name = $_.testName -replace 'SPG_Fachtheorie\.Aufgabe\d+\.Test\.', ''; Write-Output \"$s $name [$d ms]\" }"

:aufgabe3
echo.
echo ℹ️ Kompiliere und teste Aufgabe 3...
dotnet build ./test/SPG_Fachtheorie.Aufgabe3.Test --no-restore > nul
if errorlevel 1 (
    echo ❌ Build für Aufgabe 3 fehlgeschlagen. Tests werden übersprungen.
    goto end
)
dotnet test ./test/SPG_Fachtheorie.Aufgabe3.Test -l:"trx;LogFileName=aufgabe3_test_results.xml" --results-directory . --verbosity quiet
powershell -NoProfile -Command "[xml]$xml = Get-Content 'aufgabe3_test_results.xml'; $xml.GetElementsByTagName('UnitTestResult') | Sort-Object testName | ForEach-Object { $d = [timespan]::Parse($_.duration).TotalMilliseconds; $s = if ($_.outcome -eq 'Passed') { '✅' } else { '❌' }; $name = $_.testName -replace 'SPG_Fachtheorie\.Aufgabe\d+\.Test\.', ''; Write-Output \"$s $name [$d ms]\" }"

:end
pause
