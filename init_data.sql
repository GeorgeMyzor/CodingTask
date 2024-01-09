CREATE TABLE facilities (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    city VARCHAR(255) NOT NULL
);

CREATE TABLE patients (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    age INT NOT NULL
);

CREATE TABLE payers (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    city VARCHAR(255) NOT NULL
);

CREATE TABLE encounters (
    encounter_id SERIAL PRIMARY KEY,
    patient_id INT NOT NULL,
    facility_id INT NOT NULL,
    payer_id INT NOT NULL,
    FOREIGN KEY (patient_id) REFERENCES patients(id),
    FOREIGN KEY (facility_id) REFERENCES facilities(id),
    FOREIGN KEY (payer_id) REFERENCES payers(id)
);

INSERT INTO facilities (name, city) VALUES
('Facility1', 'Philadelphia'),
('Facility2', 'New York'),
('Facility3', 'Boston');

INSERT INTO patients (first_name, last_name, age) VALUES
('Frank', 'Sinatra', 20),
('James', 'Hetfield', 15),
('Layne', 'Staley', 25);

INSERT INTO payers (name, city) VALUES
('Payer1', 'Warsaw'),
('Payer2', 'Krakow'),
('Payer3', 'Gdansk'),
('Payer4', 'Warsaw');

INSERT INTO encounters (patient_id, facility_id, payer_id) VALUES
(1, 1, 1),
(1, 2, 4),
(2, 2, 1),
(2, 3, 3),
(3, 1, 2),
(3, 3, 3),
(3, 3, 4);