
select * from kappabd.achat;

SELECT * FROM kappabd.client;

SELECT * FROM kappabd.representation;

select * FROM kappabd.sallespectacle;


select Motdepasse from kappabd.client where Nom = 'Test';

INSERT INTO kappabd.client(Nom, Ville, MembreReseau, Motdepasse) VALUES ('Test', 'Mtl', 1, '1234')

delimiter |

CREATE PROCEDURE VerificationMDP(in prace varchar(45))
Begin
select Motdepasse from kappabd.client where Nom = prace;
end |

delimiter |

CREATE procedure InsertionClient(in pNom varchar(45), in pVille varchar(45), in pMembreReseau tinyint(1), in pMotdepasse varchar(45))
Begin
Insert into kappabd.client(Nom, Ville, MembreReseau, Motdepasse) Values(pNom, pVille, pMembreReseau, pMotdepasse);
end |

CREATE procedure ListerSpectacle()
Begin
 Select * from kappabd.representation;
end |

CREATE procedure VerificationAdmin(in pNom varchar(45))
Begin
 Select MembreReseau from kappabd.client where Nom = pNom;
end |

CREATE procedure Supprimer(in pNom varchar(45))
Begin
 Select MembreReseau from kappabd.client where Nom = pNom;
end |


INSERT INTO kappabd.client(Nom, Ville, MembreReseau, Motdepasse) VALUES ('Admin', 'Admin', 1, '1111');

insert into kappabd.representation(Dates, Heure, Categorie, SalleSpectacle_Nom, Artiste) values('2006-05-00', 21, 'Humour', 'Lionel-Groulx', 'Tupac');
insert into kappabd.representation(Dates, Heure, Categorie, SalleSpectacle_Nom, Artiste) values('2017-05-00', 21, 'Humour', 'Lionel-Groulx', 'Redman');
insert into kappabd.representation(Dates, Heure, Categorie, SalleSpectacle_Nom, Artiste) values('2017-05-00', 22, 'Danse', 'Stade Olympique', 'Nekfeu');
insert into kappabd.representation(Dates, Heure, Categorie, SalleSpectacle_Nom, Artiste) values('2017-05-00', 20, 'Humour', 'Centre Bell', 'booba');

