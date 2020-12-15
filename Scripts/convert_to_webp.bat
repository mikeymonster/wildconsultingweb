REM requires cwebp - download from link on https://developers.google.com/speed/webp
SET toolpath=C:\temp\libwebp-1.1.0-windows-x64\bin
SET images=..\WildConsulting.WebSite.Core\wwwroot\images

%toolpath%\cwebp -lossless %images%\logo.jpg -q 80 -o %images%\logo.webp

%toolpath%\cwebp -lossless %images%\cloud.png -q 65 -o %images%\cloud.webp
%toolpath%\cwebp -lossless %images%\code.png -q 65 -o %images%\code.webp
%toolpath%\cwebp -lossless %images%\database_search.png -q 65 -o %images%\database_search.webp
%toolpath%\cwebp -lossless %images%\data_science.png	-q 65 -o %images%\data_science.webp
%toolpath%\cwebp -lossless %images%\workplacesmap.png -q 65 -o %images%\workplacesmap.webp
																					 