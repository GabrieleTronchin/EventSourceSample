## required openssl
## Useful links:
## https://chocolatey.org/install#psdsc
## https://www.baeldung.com/openssl-self-signed-cert
## https://www.sslshopper.com/article-most-common-openssl-commands.html


[CmdletBinding()]
param (
    [Parameter(
        Mandatory = $true,
        Position = 0,
        HelpMessage = "Insert NEW destionation folder name"
    )]
    [string]$certFolder,
    [Parameter(
        Mandatory = $true,
        Position = 0,
        HelpMessage = "Insert Cert Name"
    )]
    [string]$certName,
    [Parameter(
        Mandatory = $true,
        Position = 0,
        HelpMessage = "Insert CA Cert Name"
    )]
    [string]$certCAName
)

New-Item -Path ".\" -Name $certFolder -ItemType "directory" -Force 

Write-Output "Folder Created"

Copy-Item -Path "config.ext" -Destination (".\" + $certFolder) -Recurse

Read-Host -Prompt "File config.ext must be customized if necessary on created folder. Click enter to continue"

Read-Host -Prompt "FILL ALL CERTIFICATE FIELDS - CERTIFICATE INVALID IF FIELDS ARE MISSING.  Click enter to continue"

#1. Creating a Private Key
openssl genrsa -des3 -out $certFolder\$certName.key 2048

#2. Creating a Certificate Signing Request
## An important field is “Common Name,” which should be the exact Fully Qualified Domain Name (FQDN) of our domain.
openssl req -key $certFolder\$certName.key -new -out $certFolder\$certName.csr

#3  Creating a Self-Signed Certificate
openssl x509 -signkey $certFolder\$certName.key -in $certFolder\$certName.csr -req -days 365 -out $certFolder\$certName.crt

#4 Create a Self-Signed Root CA
openssl req -x509 -sha256 -days 1825 -newkey rsa:2048 -keyout $certFolder\$certCAName.key -out $certFolder\$certCAName.crt

#5 Sign Our CSR With Root CA
openssl x509 -req -CA $certFolder\$certCAName.crt -CAkey $certFolder\$certCAName.key -in $certFolder\$certName.csr -out $certFolder\$certName.crt -days 365 -CAcreateserial -extfile $certFolder\config.ext

#6 Check certificate
openssl x509 -text -noout -in $certFolder\$certName.crt

#7 Convert Cetificate to pfx
openssl pkcs12 -export -out $certFolder\$certName.pfx -inkey $certFolder\$certName.key -in $certFolder\$certName.crt -certfile $certFolder\$certCAName.crt
