USE
annuaire_cubes;

INSERT INTO Site (nom_site, ville)
VALUES ("Siège administratif", "Paris"),
       ("Site de production", "Nantes"),
       ("Site de production", "Toulouse"),
       ("Site de production", "Nice"),
       ("Site de production", "Lille");

INSERT
IGNORE INTO Services (Id, Nom)
VALUES (1, "IT");

INSERT
IGNORE INTO Salaries (Id, Nom, Prenom, TelFixe, TelPortable, Email, Service, Site)
VALUES (1, "Eliott", "Bidault-Hervouet", 1010101010, 1010101010, "eliottbidaul@test.com", 1, 1);

INSERT
IGNORE INTO Admins (Id, IdUser)
VALUES (1, 1);