# Checklist MVP CRM testabile

## 1) Accesso utenti
- [ ] Seed ruoli applicativi: `Admin`, `Segreteria`, `Docente`, `Discente`
- [ ] Seed utente admin iniziale
- [ ] Login UI funzionante per accesso aree protette

## 2) Funzionalità core CRM (MVP)
- [ ] Corsi: CRUD minimo (`Index/Create/Edit/Details`)
- [ ] Calendario corso: gestione giornate
- [ ] Assegnazione docenti ai corsi
- [ ] Assegnazione discenti ai corsi
- [ ] Presenze/assenze giornaliere: inserimento, modifica, consultazione
- [ ] Ricerca base: filtro per corso/docente/discente/periodo

## 3) Autorizzazioni per ruolo
- [ ] Docente opera solo sui corsi assegnati
- [ ] Discente in sola lettura sui propri corsi/frequenze
- [ ] Segreteria: calendario + assegnazione docenti + lettura frequenze
- [ ] Admin: pieno controllo + creazione utenti

## 4) Modello dati MVP
- [ ] `CourseSessionDay`
- [ ] `TeacherProfile`
- [ ] `StudentProfile`
- [ ] `CourseTeacherAssignment`
- [ ] `CourseStudentAssignment`
- [ ] `AttendanceRecord`
- [ ] Vincoli univoci e integrità (assegnazioni/presenze)

## 5) Application layer
- [ ] Servizi/use case per corsi, assegnazioni, presenze, ricerca
- [ ] Validazioni business centralizzate
- [ ] DTO/ViewModel coerenti con Razor Pages

## 6) Logging e robustezza
- [ ] Serilog configurato (console + file)
- [ ] Gestione errori e messaggi di validazione coerenti
- [ ] Audit minimo operazioni principali

## 7) Test minimi
- [ ] Unit test su regole applicative (autorizzazioni/vincoli/presenze)
- [ ] Smoke test manuale completo per ruolo

## 8) Prontezza ambiente test
- [ ] `appsettings.Development` coerente
- [ ] Script bootstrap DB + migration + seed ripetibile
- [ ] Verifica publish IIS (anche dry-run)
