# Specifica Requisiti - FormazioneCRM

## 1. Scopo

Realizzare un'applicazione web per la gestione di corsi di formazione, docenti e discenti, con gestione presenze/assenze e accesso riservato a utenti autorizzati.

## 2. Ambito

L'applicazione copre:

- gestione anagrafiche funzionali (corsi, docenti, discenti);
- assegnazione docenti ai corsi;
- assegnazione discenti ai corsi;
- registrazione e consultazione presenze/assenze per giornata;
- consultazione e ricerca base delle informazioni principali.

Fuori ambito in questa fase:

- storico completo delle assegnazioni (prevista solo predisposizione tecnica);
- self-registration, inviti o reset autonomo utenti (prevista solo predisposizione tecnica).

## 3. Attori e ruoli

### 3.1 Amministratore
Permessi:
- lettura/scrittura completa;
- creazione utenti;
- piena gestione dati applicativi.

### 3.2 Segreteria
Permessi:
- gestione calendario corsi;
- assegnazione docente al corso;
- consultazione presenze/assenze.

### 3.3 Docente
Permessi:
- opera su uno o più corsi, ma solo sui corsi a lui assegnati;
- gestione del proprio corso;
- assegnazione discenti al proprio corso;
- registrazione presenze/assenze per giornata.

### 3.4 Discente
Permessi:
- sola lettura delle informazioni dei corsi a cui è assegnato.

## 4. Requisiti funzionali

### RF-01 - Gestione corsi
Il sistema deve consentire la creazione, modifica e consultazione dei corsi secondo i permessi del ruolo.

### RF-02 - Assegnazione docenti ai corsi
Il sistema deve consentire l’assegnazione di uno o più docenti ai corsi, secondo i permessi autorizzati.

### RF-03 - Assegnazione discenti ai corsi
Il sistema deve consentire l’assegnazione dei discenti ai corsi da parte del docente, limitatamente ai corsi a lui assegnati.

### RF-04 - Presenze/assenze per giornata
Il sistema deve consentire la registrazione di presenza/assenza dei discenti per singola giornata di corso.

### RF-05 - Consultazione presenze/assenze
Il sistema deve consentire la consultazione delle registrazioni di frequenza secondo i permessi di ruolo.

### RF-06 - Ricerca base
Il sistema deve consentire ricerca/filtri base per:
- corso;
- docente;
- discente;
- periodo.

### RF-07 - Autenticazione e autorizzazione
L’accesso deve essere consentito solo a utenti autenticati e autorizzati in base al ruolo.

### RF-08 - Gestione utenti (fase attuale)
La creazione utenti deve essere consentita solo all’Amministratore.

## 5. Casi d’uso principali

### UC-01 - Login
**Attori:** tutti i ruoli  
**Precondizione:** utente registrato  
**Postcondizione:** accesso all’area consentita dal ruolo

### UC-02 - Creare utente
**Attore:** Amministratore  
**Precondizione:** Amministratore autenticato  
**Postcondizione:** nuovo utente creato e associabile a uno o più ruoli

### UC-03 - Pianificare calendario corso
**Attore:** Segreteria  
**Precondizione:** corso esistente  
**Postcondizione:** calendario aggiornato

### UC-04 - Assegnare docente a corso
**Attore:** Segreteria  
**Precondizione:** corso e docente esistenti  
**Postcondizione:** docente associato al corso

### UC-05 - Assegnare discente a corso
**Attore:** Docente  
**Precondizione:** docente assegnato al corso; discente esistente  
**Postcondizione:** discente associato al corso

### UC-06 - Registrare presenza/assenza
**Attore:** Docente  
**Precondizione:** docente assegnato al corso; giornata valida  
**Postcondizione:** stato di frequenza salvato per discente e giornata

### UC-07 - Consultare frequenze
**Attori:** Amministratore, Segreteria, Docente, Discente (nei limiti ruolo)  
**Precondizione:** dati presenti  
**Postcondizione:** visualizzazione elenco/risultati filtrati

### UC-08 - Eseguire ricerca base
**Attori:** utenti autorizzati  
**Precondizione:** autenticazione avvenuta  
**Postcondizione:** risultati filtrati per corso/docente/discente/periodo

## 6. Regole di autorizzazione (sintesi)

- Amministratore: accesso completo.
- Segreteria: gestione calendario + assegnazione docenti + lettura frequenze.
- Docente: operatività solo sui corsi assegnati.
- Discente: sola lettura dei propri corsi assegnati.
- Nessun utente non autenticato può accedere ai dati applicativi.

## 7. Requisiti non funzionali

### RNF-01 - Architettura
Applicazione con tre livelli logici:
1. presentazione;
2. logica applicativa;
3. accesso ai dati.

### RNF-02 - Stack tecnologico
- C#
- ASP.NET Core MVC
- Entity Framework Core
- PostgreSQL

### RNF-03 - Sicurezza
- Autenticazione/autorizzazione tramite ASP.NET Core Identity.
- Accesso ai dati vincolato al ruolo e alla titolarità del corso (per il docente).

### RNF-04 - Logging
- Logging applicativo con Serilog.

### RNF-05 - Deploy
- Pubblicazione su IIS.
- Predisposizione futura per Azure.

## 8. Predisposizioni evolutive (future-proofing)

### PE-01 - Storico assegnazioni
Pur non essendo richiesto in questa fase, il modello dati dovrà poter evolvere per tracciare storicità (inizio/fine validità) di:
- assegnazione docente-corso;
- assegnazione discente-corso.

### PE-02 - Provisioning utenti evoluto
Pur non essendo richiesto in questa fase, il modello dovrà poter supportare in futuro:
- inviti utente;
- registrazione/self-service controllato;
- flussi di recupero account più estesi.

## 9. Criteri di accettazione (alto livello)

1. Un utente non autenticato non accede alle funzionalità applicative.
2. Ogni ruolo vede solo funzionalità e dati consentiti.
3. Il docente non può modificare corsi non assegnati a lui.
4. La frequenza è registrabile e consultabile per singola giornata.
5. Le ricerche base restituiscono risultati per corso/docente/discente/periodo.
6. L’Amministratore può creare utenti.
7. Le operazioni principali risultano tracciate nei log applicativi.