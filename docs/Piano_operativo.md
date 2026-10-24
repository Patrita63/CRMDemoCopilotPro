# Piano operativo - Sessione da 90 minuti (FormazioneCRM)

## Obiettivo sessione
Chiudere le decisioni bloccanti e lasciare pronta la base per creare la solution senza rework.

## Timebox (90 minuti)

## 0-10 min — Allineamento rapido
- Verifica obiettivo MVP della prima iterazione.
- Conferma ruoli e confini operativi già definiti:
  - Amministratore
  - Segreteria
  - Docente
  - Discente
- Conferma output atteso a fine sessione.

**Output:** scope MVP confermato.

## 10-30 min — Campi minimi e regole dati
- Definire campi indispensabili per:
  - Corso
  - Calendario corso
  - Docente
  - Discente
  - Presenza/assenza giornaliera
- Definire validazioni minime (obbligatori, vincoli date, unicità logiche).

**Output:** elenco campi/validazioni pronto per traduzione tecnica.

## 30-45 min — Autorizzazioni dettagliate
- Mappare permessi per funzionalità:
  - visualizzazione
  - creazione
  - modifica
  - cancellazione (se prevista)
- Confermare vincolo: docente opera solo sui corsi assegnati.
- Confermare visibilità Segreteria su presenze/assenze.

**Output:** matrice autorizzativa completa.

## 45-60 min — Ricerca e consultazione
- Confermare filtri di ricerca base:
  - corso
  - docente
  - discente
  - periodo
- Definire risultato minimo atteso della ricerca (campi mostrati e ordinamento base).

**Output:** specifica consultazione MVP.

## 60-75 min — Backlog MVP (operativo)
- Scrivere 6–10 user story prioritarie.
- Classificare: Must / Should / Could.
- Aggiungere criterio di accettazione sintetico per ogni Must.

**Output:** backlog sprint-0 pronto.

## 75-90 min — Handoff tecnico per creazione solution
- Preparare check di avvio implementazione:
  - layering a 3 livelli
  - stack confermato (.NET MVC + EF Core + PostgreSQL + Identity + Serilog)
  - prerequisiti deploy IIS
  - predisposizione futura Azure
- Identificare rischi aperti e owner.

**Output:** pacchetto “ready-to-build”.

---

## Deliverable di fine sessione
- Requisiti MVP consolidati.
- Matrice autorizzativa.
- Specifica ricerca base.
- Backlog prioritizzato con criteri di accettazione.
- Handoff tecnico per avvio solution Visual Studio.

## Rischi da evitare
- Aggiungere requisiti non richiesti dal cliente.
- Definire troppi dettagli non MVP.
- Iniziare la solution senza chiusura delle regole autorizzative.

## Definizione di “sessione riuscita”
La sessione è conclusa con successo se:
1. non restano ambiguità bloccanti;
2. backlog Must è approvato;
3. il team può creare la solution subito dopo, senza decisioni architetturali pendenti.