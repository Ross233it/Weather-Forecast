# Introduzione al progetto

Repository git


## INTRO
Il progetto mette a disposizione due servizi principali e fra loro indipendenti:

- WeatherForecast è un client Web che permette di selezionare le località disponibili nel servizio pubblico messo a disposizione dalla Provincia Autonoma di Trento e visualizzare tutte le previsioni meteo disponibili -


- WsSoapTranslator attinge le informazioni dal medesimo servizio e le configura come un Web Service SOAP.

### Sintesi delle caratteristiche tecniche dei servizi:
#### CommonClassLibrary:
progetto del tipo “libreria di classi” accoglie i Model necessari a mappare i dati ricavati dal servizio remoto di previsioni meteo.
le classi previste sono suddivise in modo conforme agli oggetti presenti nel json di risposta del servizio

#### Weather Forecast:
- Progetto Asp Net MVC
- Mappato sulla porta 1115 del container
- Implementa i Controller e le View 
- Utilizza i Model dalla libreria comune 
- Dispone delle risorse statiche per le view (immagini, file css, file  javascript etc)
- Il servizio recupera tramite una chiamata ad un endpoint API tutte le località per cui sono disponibili
previsioni meteo. Costruisce un elenco dinamico delle località e per ciascuna, cliccando sul link generato,
è in grado di visualizzare le condizioni meteo ipotizzate, divise per data.
- 
#### WsSoapTranslator:
- Progetto .Net Core;
- Mappato sulla porta 1118 del container;
- Utilizza i Model della libreria comune
- Utilizza la libreria SOAP Core;
- Si articola principalmente in una Interfaccia e nella classe concreta che la implementa;
- Mette a disposizione due possibili servizi:
  - ricerca delle previsioni in base alla Località;
  - ricerca delle previsione in base a Località e giorno nel formato YYYY-MM-DD;

### Esecuzione in container Docker
L’esecuzione dei servizi è volutamente stata lasciata indipendente su due containers separati collegati tramite docker-compose.
Questo consente di gestire, aggiornare e scalare i due servizi in modo indipendente aumentando le condizioni di sicurezza e stabilità se uno dei due accusa malfunzionamenti.
I due servizi condividono la libreria dei Model, ma ciascuno effettua la propria chiamata al servizio remoto esterno per il recupero
delle informazioni meteorologiche.
