-- Setup PostgreSQL locale per FormazioneCRM
-- Eseguire con un utente con privilegi amministrativi (es. postgres)

-- 1) Crea il database applicativo
CREATE DATABASE "FormazioneCRM";

-- 2) Crea un utente dedicato (consigliato)
CREATE USER formazionecrm_user WITH PASSWORD 'StrongPassword123!';

-- 3) Concedi privilegi sul database
GRANT ALL PRIVILEGES ON DATABASE "FormazioneCRM" TO formazionecrm_user;

-- 4) Connettiti al database creato
\connect "FormazioneCRM"

-- 5) Concedi privilegi sullo schema public
GRANT USAGE, CREATE ON SCHEMA public TO formazionecrm_user;
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO formazionecrm_user;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO formazionecrm_user;

-- 6) Privilegi automatici per oggetti futuri
ALTER DEFAULT PRIVILEGES IN SCHEMA public
GRANT ALL ON TABLES TO formazionecrm_user;

ALTER DEFAULT PRIVILEGES IN SCHEMA public
GRANT ALL ON SEQUENCES TO formazionecrm_user;
