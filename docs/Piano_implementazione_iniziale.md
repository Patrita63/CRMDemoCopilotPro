# Piano di implementazione iniziale — FormazioneCRM
_Basato su `Checklist_Operativa.md`, `Piano_operativo.md`, `Specifica_Requisiti_FormazioneCRM.md`_

## 1) Obiettivo della prima iterazione (MVP)
Realizzare una baseline funzionante con:
- autenticazione/autorizzazione a ruoli (`Admin`, `Segreteria`, `Docente`, `Discente`);
- CRUD minimo corsi;
- assegnazione docenti/discenti ai corsi;
- registrazione e consultazione presenze/assenze giornaliere;
- ricerca base per corso/docente/discente/periodo;
- logging applicativo e base deploy-ready.

> Nota: i requisiti citano MVC, ma l’implementazione viene allineata al workspace corrente **Razor Pages** (.NET 10).

---

## 2) Architettura target (3 layer)
## `FormazioneCRM.Web` (Presentazione - Razor Pages)
- Pagine Razor + PageModel.
- Policy di autorizzazione per ruolo.
- Binding input/view model.
- Nessuna logica di dominio complessa.

## `FormazioneCRM.Application` (Logica applicativa)
- Use case / service applicativi:
  - gestione corsi;
  - assegnazioni docenti/discenti;
  - presenze;
  - ricerca.
- Contratti (`Interfaces`) per repository/unit of work.
- DTO e validazioni applicative.

## `FormazioneCRM.Infrastructure` (Accesso dati)
- `DbContext` EF Core + ASP.NET Core Identity.
- Implementazioni repository.
- Configurazioni Fluent API.
- Migrazioni e seed iniziale ruoli/admin.
- Serilog sink/config.

---

## 3) Modello dominio minimo (MVP)
Entità iniziali:
- `Course` (Corso)
- `CourseSessionDay` (giornata/calendario corso)
- `TeacherProfile`
- `StudentProfile`
- `CourseTeacherAssignment`
- `CourseStudentAssignment`
- `AttendanceRecord` (presenza/assenza per giornata)

Vincoli minimi:
- univocità logica su assegnazioni (no duplicati attivi);
- `AttendanceRecord` univoco per `(CourseSessionDay, Student)`;
- docente operabile solo su corsi assegnati.

Predisposizione evolutiva:
- campi `ValidFrom` / `ValidTo` su tabelle assegnazione (future-proof storico).

---

## 4) Sicurezza e autorizzazioni
Ruoli:
- `Admin`: pieno accesso, creazione utenti.
- `Segreteria`: calendario corsi, assegnazione docenti, lettura frequenze.
- `Docente`: gestione solo corsi assegnati, assegnazione discenti, presenze.
- `Discente`: sola lettura corsi/frequenze proprie.

Policy applicative:
- `RequireAdmin`
- `RequireSegreteriaOrAdmin`
- `RequireTeacherOrAdmin`
- `RequireAuthenticatedUser`
- regola ownership docente su corso (controllo in Application + query filtrate in Infrastructure).

---

## 5) Piano operativo per fasi

## Fase 0 — Bootstrap tecnico
1. Aggiungere riferimenti tra progetti:
   - `Web -> Application`
   - `Infrastructure -> Application`
2. Aggiungere progetto test (`FormazioneCRM.Application.Tests`).
3. Strutturare cartelle base per layer.

**Output:** solution allineata al layering.

## Fase 1 — Persistence + Identity
1. Integrare EF Core PostgreSQL.
2. Creare `ApplicationDbContext` in Infrastructure.
3. Integrare ASP.NET Core Identity.
4. Migrazione iniziale + update database.
5. Seed ruoli + utente admin iniziale.

**Output:** login funzionante e ruoli disponibili.

## Fase 2 — Application core
1. Definire interfacce repository e servizi applicativi.
2. Implementare use case:
   - gestione corsi;
   - assegnazioni docenti;
   - assegnazioni discenti;
   - registrazione presenze;
   - consultazione e ricerca base.
3. Introdurre validazioni applicative centrali.

**Output:** logica business testabile senza UI.

## Fase 3 — Razor Pages MVP
1. Pagine autenticazione/area protetta.
2. Pagine corsi (`Index/Create/Edit/Details`).
3. Pagine assegnazione docenti/discenti.
4. Pagine presenze giornaliere (input + consultazione).
5. Pagina ricerca con filtri base.

**Output:** flusso utente completo MVP.

## Fase 4 — Logging, hardening, deploy readiness
1. Configurare Serilog (console + file).
2. Error handling coerente (pagine errore, validazioni UI).
3. Configurare `appsettings` per ambienti.
4. Preparazione publish IIS + gestione secret/config sensibili.

**Output:** baseline pronta per test ambiente.

---

## 6) Backlog Must (prima iterazione)
- M1: Login + autorizzazione per ruolo.
- M2: CRUD corsi (base).
- M3: Assegnazione docente a corso (Segreteria/Admin).
- M4: Assegnazione discente a corso (Docente su corsi assegnati).
- M5: Registrazione presenza/assenza giornaliera.
- M6: Consultazione frequenze filtrata.
- M7: Ricerca base (corso/docente/discente/periodo).
- M8: Creazione utente da Admin.
- M9: Logging operazioni principali.

---

## 7) Criteri di accettazione tecnici (minimi)
- Utente non autenticato bloccato su pagine applicative.
- Visibilità funzionalità coerente con ruolo.
- Docente non modifica dati fuori dai corsi assegnati.
- Presenza salvabile una sola volta per discente/giornata.
- Ricerca base restituisce risultati corretti.
- Operazioni principali tracciate nei log.

---

## 8) Test plan iniziale
- Unit test Application:
  - vincoli autorizzativi docente;
  - validazioni assegnazioni;
  - regole frequenza.
- Integration test (successivo):
  - repository EF Core;
  - pipeline auth base.

---

## 9) Sequenza consigliata di implementazione (ordine pratico)
1. Identity + DB + migrazione.
2. Entità + mapping EF Core.
3. Servizi Application (corsi, assegnazioni, presenze).
4. Razor Pages corsi.
5. Razor Pages assegnazioni.
6. Razor Pages presenze + ricerca.
7. Logging + rifiniture + test.

---

## 10) Deliverable della prima milestone
- Solution compilabile con flusso login e ruoli.
- Use case MVP implementati end-to-end.
- Database migrato e seedato.
- Test unitari minimi su regole core.
- Pacchetto pronto per publish di test su IIS.