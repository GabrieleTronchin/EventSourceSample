# Gestione Certificati

## Prerequisiti
1. Scaricare chocolatey per installazione openssl: https://chocolatey.org/install#psdsc
	Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

2. Installare openssl come admin da powershell
	choco install openssl

## Generare un certificato self signed
Seguire la procedura indicata nello script ./generate-certs.ps1
Verranno generati i seguenti certificati:
 - mycertName.crt => certificato client
 - mycertName.key => chiave certificato client
 - mycertNameCA.crt => certificato authority
 - mycertNameCA.key => hiave certificato authority
 - mycertName.pfx => certificato client convertito in ( pfx )

Tutte le password dei certificati sulla folder mycertName sono: **mycertName**

## Riferimenti
- https://www.baeldung.com/openssl-self-signed-cert
- https://www.sslshopper.com/article-most-common-openssl-commands.html