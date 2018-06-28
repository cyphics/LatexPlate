--select * from TemplateEnvironment

INSERT INTO TemplatePackage  (Template_FK, Package_FK)
VALUES (
	(select Nom from Template where Nom = 'Lettre_Officielle'), 
	(select Nom from Package where Nom = 'linguex')
	)