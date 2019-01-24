Param(
  [string] $apiManagementRg,
  [string] $apiManagementName,
  [string] $apiUrl,
  [string] $apiDescriptionPath,
  [string] $apiName,
  [string] $apiId
)

$ApiMgmtContext = New-AzureRmApiManagementContext -ResourceGroupName "$apiManagementRg" -ServiceName "$apiManagementName"

Write-verbose "$ApiMgmtContext" -verbose

$SwaggerUrl = $apiUrl + $apiDescriptionPath
Write-verbose "$SwaggerUrl" -verbose

wget $SwaggerUrl  -outfile "apiswagger.json"

Import-AzureRmApiManagementApi -Context $ApiMgmtContext -SpecificationFormat "Swagger" -SpecificationPath "apiswagger.json" -Path "$apiName" -ApiId "$apiId"