[CmdletBinding()]
param (
  [switch]$Private = $false
)

function Wait-Until()
{
  param(
    [string]$Message = "Waiting",  
    [int]$Delay = 15
  )

  For ($i=$Delay;$i -gt 0;$i--) { Write-Host -ForegroundColor Red -NoNewline "`r${Message} : ${i}sec left..."; Start-Sleep -Seconds 1 }
  Write-Host -ForegroundColor DarkGreen -NoNewline "`rdone                                                                                   "
  Write-Host
}

$USER=${env:UserName}.replace(".","")

if ($Private -eq $true) {
  Write-Host "Starting environment for '$USER'";
  $ENV = ".$USER"
}
else {
  Write-Host "Starting environment for 'GLOBAL'";
  $ENV = ""
}

docker-compose up -d --force-recreate
Wait-Until -Message "Waiting for infrastructure services to start"