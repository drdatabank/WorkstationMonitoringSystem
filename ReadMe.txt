//-------------------------ENGLISH----------------------------------

Run.bat - file for running the task. It starts the server that transmits and the client that receives the stream.

The time between subsequent stream broadcasts can be set in the Server configuration file:

	Server -> appsettings.json -> "AppSettings" -> "SendingReportTimeSpan": "10000"

This time is given in milliseconds and by default it is 10s
  
In the 'appsettings.json' configuration file you can also set the format in which the Service will transmit data

	Server -> appsettings.json -> "AppSettings" -> "ReportType": ""

The following emitted data formats can be set in the configuration file: 

	"YAML", "JSON" or "XML"

The type of transferred data can be set both in the configuration file and directly in the program using Enum. If there is no type setting in the server configuration file, the data type implemented by default in the program, i.e. "YAML", is selected.

The data types provided by the 'DiskMonitoringLibrary' library are selected based on the enum:
	public enum ReportType
	{
     	  YAML,
     	  JSON,
     	  XML
	}


Data is collected using nLog in text form. The 'DiskMonitoringLibrary' library provides the 'IDriveInfo' interface, which allows you to easily transform client-side data into objects.

Reports are available in the following files:
- server
	Server -> Logs -> ReportsLogs.txt
- Client
	Client -> Logs -> ReportsLogs.txt

//-------------------------POLISH-----------------------------------

Run.bat - plik do uruchamiania zadania. Uruchomia serwer który nadaje oraz klienta który odbiera strumień.

Czas pomiędzy kolejnymi emisjami strumienia można ustawić w pliku konfiguracyjnym Servera:

	Server -> appsettings.json -> "AppSettings" -> "SendingReportTimeSpan": "10000"

Czas ten podawany jest w milisekundach i domyślnie wynosi 10s
  
W pliku konfiguracyjnym 'appsettings.json' można również ustawić w jakim formacie Servis będzie przekazywał dane

	Server -> appsettings.json -> "AppSettings" -> "ReportType": ""

W pliku konfiguracyjnym można ustawić następujące formaty emitowanych danych: 

	"YAML", "JSON" lub "XML" 

Typ przekazywanych danych można ustawić zarówno w pliku konfiguracyjnym jak i bezpośrednio w programie przy pomocy Enum. W przypadku braku ustawienia typu w pliku konfiguracujnym servera wybierany jest typ danych domyślnie zaimplementowany w programie czyli YAML.

Typy danych jakie dostarca biblioteka 'DiskMonitoringLibrary' bybierane są na podstawie enuma:
	public enum ReportType
	{
    	  YAML,
    	  JSON,
    	  XML
	}

Dane zbierane są przy pomocy nLog w postaci tekstowej. Billioteka 'DiskMonitoringLibrary' udostępnia interfejs 'IDriveInfo' dzięki któremu w łatwy sposób można przekształcić dane po stronie klienta do postaci obiektów.

Raporty dostępne są w plikach:
- serwer
	Server -> Logs -> ReportsLogs.txt
- klient
	Client -> Logs -> ReportsLogs.txt