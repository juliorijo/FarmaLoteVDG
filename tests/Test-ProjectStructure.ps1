param(
    [switch]$SkipBuild
)

$ErrorActionPreference = 'Stop'
$script:passed = 0
$script:failures = New-Object 'System.Collections.Generic.List[string]'
$repoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..')).Path

function Assert-Structure {
    param(
        [bool]$Condition,
        [string]$Description
    )

    if ($Condition) {
        $script:passed++
        Write-Host "[PASS] $Description" -ForegroundColor Green
    }
    else {
        $script:failures.Add($Description)
        Write-Host "[FAIL] $Description" -ForegroundColor Red
    }
}

function Read-ProjectFile {
    param([string]$RelativePath)
    $path = Join-Path $repoRoot $RelativePath
    Assert-Structure (Test-Path -LiteralPath $path -PathType Leaf) "Existe $RelativePath"
    if (-not (Test-Path -LiteralPath $path -PathType Leaf)) {
        throw "Falta el archivo esencial: $RelativePath"
    }
    return [System.IO.File]::ReadAllText($path)
}

function Find-MSBuild {
    $command = Get-Command 'MSBuild.exe' -ErrorAction SilentlyContinue
    if ($command) {
        return $command.Source
    }

    $programFilesX86 = [Environment]::GetFolderPath('ProgramFilesX86')
    $vswhere = Join-Path $programFilesX86 'Microsoft Visual Studio\Installer\vswhere.exe'
    if (Test-Path -LiteralPath $vswhere) {
        $candidates = @(& $vswhere -latest -products '*' -find 'MSBuild\**\Bin\MSBuild.exe')
        $candidate = $candidates | Where-Object {
            $_ -match '\\MSBuild\\Current\\Bin\\MSBuild\.exe$' -and $_ -notmatch '\\amd64\\'
        } | Select-Object -First 1
        if ($candidate) {
            return $candidate
        }
    }

    return $null
}

$projectPath = Join-Path $repoRoot 'FarmaLoteVDG.csproj'
$projectText = Read-ProjectFile 'FarmaLoteVDG.csproj'
$solutionText = Read-ProjectFile 'FarmaLoteVDG.slnx'
$programText = Read-ProjectFile 'Program.cs'
$formText = Read-ProjectFile 'Form1.cs'
$designerText = Read-ProjectFile 'Form1.Designer.cs'
$appConfigText = Read-ProjectFile 'App.config'
$resourceText = Read-ProjectFile 'Properties\Resources.resx'
$projectXml = New-Object System.Xml.XmlDocument
$projectXml.LoadXml($projectText)
$namespaces = New-Object System.Xml.XmlNamespaceManager($projectXml.NameTable)
$namespaces.AddNamespace('msb', 'http://schemas.microsoft.com/developer/msbuild/2003')

$targetFramework = $projectXml.SelectSingleNode('//msb:TargetFrameworkVersion', $namespaces)
$outputType = $projectXml.SelectSingleNode('//msb:OutputType', $namespaces)
$assemblyName = $projectXml.SelectSingleNode('//msb:AssemblyName', $namespaces)
$winFormsReference = $projectXml.SelectSingleNode("//msb:Reference[@Include='System.Windows.Forms']", $namespaces)
$compileItems = @($projectXml.SelectNodes('//msb:Compile', $namespaces))
$designerItem = $compileItems | Where-Object { $_.GetAttribute('Include') -eq 'Form1.Designer.cs' } | Select-Object -First 1
$linkedDesigner = $designerItem -and $designerItem.SelectSingleNode('msb:DependentUpon', $namespaces).InnerText -eq 'Form1.cs'

Assert-Structure ($targetFramework -and $targetFramework.InnerText -eq 'v4.8') 'El proyecto conserva .NET Framework 4.8'
Assert-Structure ($outputType -and $outputType.InnerText -eq 'WinExe') 'El proyecto conserva su tipo de aplicacion Windows'
Assert-Structure ($assemblyName -and $assemblyName.InnerText -eq 'FarmaLoteVDG') 'Se conserva el nombre del ensamblado inicial'
Assert-Structure ($null -ne $winFormsReference) 'El proyecto conserva la referencia a Windows Forms'
Assert-Structure ($null -ne ($compileItems | Where-Object { $_.GetAttribute('Include') -eq 'Program.cs' })) 'El punto de entrada sigue incluido en el proyecto'
Assert-Structure ($null -ne ($compileItems | Where-Object { $_.GetAttribute('Include') -eq 'Form1.cs' })) 'El formulario inicial sigue incluido en el proyecto'
Assert-Structure $linkedDesigner 'Form1.Designer.cs sigue vinculado a Form1.cs'
Assert-Structure ($solutionText -match '<Project\s+Path="FarmaLoteVDG\.csproj"\s*/>') 'La solucion sigue apuntando al proyecto WinForms'

Assert-Structure ($programText -match '\[STAThread\]' -and $programText -match 'static\s+void\s+Main\s*\(') 'Se conserva el punto de entrada STA de Windows Forms'
Assert-Structure ($programText -match 'Application\.EnableVisualStyles\s*\(') 'La aplicacion sigue activando los estilos visuales'
Assert-Structure ($programText -match 'Application\.Run\s*\(\s*new\s+Form1\s*\(\s*\)\s*\)') 'La aplicacion inicia el formulario principal'
Assert-Structure ($formText -match 'partial\s+class\s+Form1\s*:\s*Form' -and $formText -match 'InitializeComponent\s*\(') 'Form1 conserva su clase parcial WinForms y su inicializacion'
Assert-Structure ($designerText -match 'partial\s+class\s+Form1' -and $designerText -match 'void\s+InitializeComponent\s*\(') 'El disenador conserva el inicializador del formulario'
Assert-Structure ($designerText -match 'components\.Dispose\s*\(' -and $designerText -match 'base\.Dispose\s*\(') 'El formulario conserva la liberacion de recursos'
Assert-Structure ($appConfigText -match 'supportedRuntime\s+version="v4\.0"\s+sku="\.NETFramework,Version=v4\.8"') 'La configuracion de inicio conserva el runtime .NET Framework 4.8'

$logoResource = $resourceText -match '<data\s+name="PharmacyLogo"' -and $resourceText -match 'Resources\\FarmaciaVDG\.png'
$logoSvg = Join-Path $repoRoot 'Resources\FarmaciaVDG.svg'
$logoPng = Join-Path $repoRoot 'Resources\FarmaciaVDG.png'
$svgIsRegistered = $null -ne ($projectXml.SelectNodes('//msb:None', $namespaces) | Where-Object { $_.GetAttribute('Include') -eq 'Resources\FarmaciaVDG.svg' })
Assert-Structure $logoResource 'El logo mantiene su recurso de imagen tipado'
Assert-Structure (Test-Path -LiteralPath $logoPng -PathType Leaf) 'Existe el logo PNG utilizado por Windows Forms'
Assert-Structure ((Test-Path -LiteralPath $logoSvg -PathType Leaf) -and $svgIsRegistered) 'El logo SVG original sigue incluido como recurso del proyecto'

if (-not $SkipBuild) {
    $msbuild = Find-MSBuild
    if (-not $msbuild) {
        $script:failures.Add('No se encontro MSBuild; instala Visual Studio con el destino .NET Framework 4.8 o ejecuta de nuevo con -SkipBuild.')
        Write-Host '[FAIL] No se encontro MSBuild para compilar el proyecto.' -ForegroundColor Red
    }
    else {
        $temporaryRoot = Join-Path ([System.IO.Path]::GetTempPath()) ('FarmaLoteVDG-structure-tests-' + [Guid]::NewGuid().ToString('N'))
        $buildOutput = Join-Path $temporaryRoot 'bin\'
        $intermediateOutput = Join-Path $temporaryRoot 'obj\'
        New-Item -ItemType Directory -Path $temporaryRoot | Out-Null
        try {
            Write-Host "`nCompilando en una carpeta temporal con MSBuild..." -ForegroundColor Cyan
            & $msbuild $projectPath '/t:Build' "/p:OutputPath=$buildOutput" "/p:IntermediateOutputPath=$intermediateOutput" '/nologo' '/verbosity:minimal'
            if ($LASTEXITCODE -ne 0) {
                $script:failures.Add("La compilacion de MSBuild termino con el codigo $LASTEXITCODE.")
                Write-Host "[FAIL] MSBuild termino con el codigo $LASTEXITCODE." -ForegroundColor Red
            }
            else {
                $builtExecutable = Join-Path $buildOutput 'FarmaLoteVDG.exe'
                Assert-Structure (Test-Path -LiteralPath $builtExecutable -PathType Leaf) 'MSBuild genera FarmaLoteVDG.exe sin alterar los artefactos del repositorio'
            }
        }
        finally {
            if (Test-Path -LiteralPath $temporaryRoot) {
                Remove-Item -LiteralPath $temporaryRoot -Recurse -Force
            }
        }
    }
}

Write-Host "`nPruebas de estructura correctas: $script:passed"
if ($script:failures.Count -gt 0) {
    Write-Host "Pruebas fallidas: $($script:failures.Count)" -ForegroundColor Red
    foreach ($failure in $script:failures) {
        Write-Host " - $failure" -ForegroundColor Red
    }
    exit 1
}

Write-Host 'Todas las comprobaciones pasaron.' -ForegroundColor Green
exit 0
