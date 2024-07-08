@echo off
:: Establecer las variables de entorno permanentemente
setx GOOGLE_CLIENT_ID "your-google-client-id"
setx GOOGLE_CLIENT_SECRET "your-google-client-secret"

:: Establecer las variables de entorno para la sesión actual
set GOOGLE_CLIENT_ID=your-google-client-id
set GOOGLE_CLIENT_SECRET=your-google-client-secret

:: Confirmar que las variables se han establecido
echo Variables de entorno configuradas:
echo GOOGLE_CLIENT_ID=%GOOGLE_CLIENT_ID%
echo GOOGLE_CLIENT_SECRET=%GOOGLE_CLIENT_SECRET%
pause
