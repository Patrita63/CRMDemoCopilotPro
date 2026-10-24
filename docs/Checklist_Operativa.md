# Checklist operativa - completamento analisi e creazione solution Visual Studio

## 1) Chiusura analisi funzionale (bloccante)
- [ ] Confermare campi minimi per:
  - [ ] Corso
  - [ ] Calendario corso
  - [ ] Docente
  - [ ] Discente
  - [ ] Presenza/assenza giornaliera
- [ ] Definire regole di validazione principali (obbligatorietà, unicità, date)
- [ ] Confermare visibilità dati per ruolo (Amministratore, Segreteria, Docente, Discente)
- [ ] Confermare filtri ricerca base:
  - [ ] Corso
  - [ ] Docente
  - [ ] Discente
  - [ ] Periodo

## 2) Backlog MVP (prima iterazione)
- [ ] Scrivere elenco user story minime
- [ ] Definire priorità (Must/Should/Could)
- [ ] Associare criteri di accettazione testabili a ogni story
- [ ] Individuare dipendenze tecniche tra story

## 3) Setup solution Visual Studio (3 livelli logici)
- [ ] Creare solution `FormazioneCRM`
- [ ] Creare progetto Presentazione (ASP.NET Core MVC)
- [ ] Creare progetto Logica Applicativa
- [ ] Creare progetto Accesso Dati
- [ ] Configurare riferimenti tra progetti coerenti con layering
- [ ] Aggiungere progetto test (consigliato per MVP tecnico)

## 4) Configurazione tecnica base
- [ ] Integrare ASP.NET Core Identity
- [ ] Integrare Entity Framework Core con PostgreSQL
- [ ] Predisporre migrazioni iniziali
- [ ] Integrare Serilog (console + file)
- [ ] Configurare ambienti (Development/Staging/Production)

## 5) Sicurezza e autorizzazioni
- [ ] Definire ruoli applicativi iniziali
- [ ] Mappare policy/autorizzazioni per area funzionale
- [ ] Applicare vincolo: docente opera solo sui corsi assegnati
- [ ] Verificare accesso in sola lettura per discente

## 6) Prontezza deploy
- [ ] Configurare publish profile IIS
- [ ] Parametrizzare configurazioni sensibili (connection string, secret)
- [ ] Aggiungere logging utile per troubleshooting post-deploy
- [ ] Predisporre struttura config compatibile con futura adozione Azure

## 7) Definizione “Done” della baseline
- [ ] Login funzionante con ruoli
- [ ] CRUD minimo corsi attivo
- [ ] Assegnazione docente/discente attiva
- [ ] Presenze/assenze giornaliere registrabili e consultabili
- [ ] Ricerca base funzionante (corso/docente/discente/periodo)
- [ ] Deploy IIS riuscito in ambiente di test

## Stima rapida residua
- Chiusura analisi dettagliata: **1–2h**
- Backlog tecnico + accettazione: **0.5–1h**
- Creazione solution + setup base: **1.5–3h**
- Totale: **3.5–6h**