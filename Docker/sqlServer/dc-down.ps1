[CmdletBinding()]
param (
  [Parameter(Mandatory = $false)][boolean]$Local = $false
)

$USER=${env:UserName}.replace(".","")

if ($Private -eq $true) {
  Write-Host "Stopping environment for '$USER'";
  $ENV = ".$USER"
}
else {
  Write-Host "Stopping environment for 'GLOBAL'";
  $ENV = ""
}

docker-compose down --remove-orphans

exit