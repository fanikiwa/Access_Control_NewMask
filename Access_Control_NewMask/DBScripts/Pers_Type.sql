		--Pers_Type

IF EXISTS(SELECT * FROM Pers_Type WHERE Name = 'Mitarbeiter') 
BEGIN 
UPDATE Pers_Type SET TypeNr = '0', Memo = 'Test Memo Edit' WHERE Name = 'Mitarbeiter'
END 
ELSE 
BEGIN 
INSERT INTO Pers_Type (Name , TypeNr , Memo ) VALUES('Mitarbeiter' , '0' , 'Test Memo Edit' ) 
END 
GO 

IF EXISTS(SELECT * FROM Pers_Type WHERE Name = 'Lieferant') 
BEGIN 
UPDATE Pers_Type SET TypeNr = '2', Memo = '' WHERE Name = 'Lieferant'
END 
ELSE 
BEGIN 
INSERT INTO Pers_Type (Name , TypeNr , Memo ) VALUES('Lieferant' , '2' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Pers_Type WHERE Name = 'Zeitpersonal') 
BEGIN 
UPDATE Pers_Type SET TypeNr = '3', Memo = '' WHERE Name = 'Zeitpersonal'
END 
ELSE 
BEGIN 
INSERT INTO Pers_Type (Name , TypeNr , Memo ) VALUES('Zeitpersonal' , '3' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Pers_Type WHERE Name = 'Mitarbeiter2') 
BEGIN 
UPDATE Pers_Type SET TypeNr = '0', Memo = 'Mitarbeiter2MemoEdit' WHERE Name = 'Mitarbeiter2'
END 
ELSE 
BEGIN 
INSERT INTO Pers_Type (Name , TypeNr , Memo ) VALUES('Mitarbeiter2' , '0' , 'Mitarbeiter2MemoEdit' ) 
END 
GO 


