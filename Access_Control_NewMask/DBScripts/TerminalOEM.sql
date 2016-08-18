		--TerminalOEM

IF EXISTS(SELECT * FROM TerminalOEM WHERE TermOEMId = '2') 
BEGIN 
UPDATE TerminalOEM SET TermOEMDesc = 'Datafox' WHERE TermOEMId = '2'
END 
ELSE 
BEGIN 
INSERT INTO TerminalOEM (TermOEMId , TermOEMDesc ) VALUES('2' , 'Datafox' ) 
END 
GO 

IF EXISTS(SELECT * FROM TerminalOEM WHERE TermOEMId = '1') 
BEGIN 
UPDATE TerminalOEM SET TermOEMDesc = 'Krutec ZK' WHERE TermOEMId = '1'
END 
ELSE 
BEGIN 
INSERT INTO TerminalOEM (TermOEMId , TermOEMDesc ) VALUES('1' , 'Krutec ZK' ) 
END 
GO 

