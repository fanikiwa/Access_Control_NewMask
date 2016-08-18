     --Status_Static

IF EXISTS(SELECT * FROM Status_Static WHERE StatusNr = '0') 
BEGIN 
UPDATE Status_Static SET StatusName = 'Auto' WHERE StatusNr = '0'
END 
ELSE 
BEGIN 
INSERT INTO Status_Static (StatusNr , StatusName ) VALUES('0' , 'Auto' ) 
END 
GO 

IF EXISTS(SELECT * FROM Status_Static WHERE StatusNr = '-1') 
BEGIN 
UPDATE Status_Static SET StatusName = 'Kommt' WHERE StatusNr = '-1'
END 
ELSE 
BEGIN 
INSERT INTO Status_Static (StatusNr , StatusName ) VALUES('-1' , 'Kommt' ) 
END 
GO 

IF EXISTS(SELECT * FROM Status_Static WHERE StatusNr = '-2') 
BEGIN 
UPDATE Status_Static SET StatusName = 'Geht' WHERE StatusNr = '-2'
END 
ELSE 
BEGIN 
INSERT INTO Status_Static (StatusNr , StatusName ) VALUES('-2' , 'Geht' ) 
END 
GO 

IF EXISTS(SELECT * FROM Status_Static WHERE StatusNr = '-3') 
BEGIN 
UPDATE Status_Static SET StatusName = 'Auftrag' WHERE StatusNr = '-3'
END 
ELSE 
BEGIN 
INSERT INTO Status_Static (StatusNr , StatusName ) VALUES('-3' , 'Auftrag' ) 
END 
GO 

IF EXISTS(SELECT * FROM Status_Static WHERE StatusNr = '-4') 
BEGIN 
UPDATE Status_Static SET StatusName = 'Auftr.D' WHERE StatusNr = '-4'
END 
ELSE 
BEGIN 
INSERT INTO Status_Static (StatusNr , StatusName ) VALUES('-4' , 'Auftr.D' ) 
END 
GO 

IF EXISTS(SELECT * FROM Status_Static WHERE StatusNr = '-5') 
BEGIN 
UPDATE Status_Static SET StatusName = 'Auftr.P' WHERE StatusNr = '-5'
END 
ELSE 
BEGIN 
INSERT INTO Status_Static (StatusNr , StatusName ) VALUES('-5' , 'Auftr.P' ) 
END 
GO 

IF EXISTS(SELECT * FROM Status_Static WHERE StatusNr = '-6') 
BEGIN 
UPDATE Status_Static SET StatusName = 'Auftr. Ende' WHERE StatusNr = '-6'
END 
ELSE 
BEGIN 
INSERT INTO Status_Static (StatusNr , StatusName ) VALUES('-6' , 'Auftr. Ende' ) 
END 
GO 

