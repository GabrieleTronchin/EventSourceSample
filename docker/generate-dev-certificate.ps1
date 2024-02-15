$Name = Read-Host -Prompt 'Certificate Name'
$Password = Read-Host -Prompt 'Password'

dotnet dev-certs https -ep .\$Name.pfx  -p $Password