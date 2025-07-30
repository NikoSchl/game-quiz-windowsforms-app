$ScriptDirectory = Split-Path -Parent $MyInvocation.MyCommand.Path
$FolderNames = @(".vs", "bin", "obj")

foreach ($Name in $FolderNames) {
    $FoldersToDelete = Get-ChildItem -Path $ScriptDirectory -Recurse -Directory -Force | Where-Object { $_.Name -eq $Name }

    foreach ($Folder in $FoldersToDelete) {
        Remove-Item -Path $Folder.FullName -Recurse -Force
    }
}

$ParentDirectory = Split-Path -Parent $ScriptDirectory
$ZipFileName = "$ParentDirectory\$(Split-Path -Leaf $ScriptDirectory).zip"
Add-Type -AssemblyName System.IO.Compression.FileSystem
[System.IO.Compression.ZipFile]::CreateFromDirectory($ScriptDirectory, $ZipFileName)
