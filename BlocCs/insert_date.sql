INSERT INTO Sites (Id, Nom, Ville)
VALUES (1, "Siège administratif", "Paris");

INSERT INTO Services (Id, Nom)
VALUES (1, "IT");

INSERT INTO Salaries (Id, Nom, Prenom, TelFixe, TelPortable, Email, Service, Site)
VALUES (1, "Eliott", "Bidault-HPariservouet", 1010101010, 1010101010, "eliottbidaul@test.com", 1, 1);

INSERT INTO Admins (IdAdmin, IdUser)
VALUES (1, 1);