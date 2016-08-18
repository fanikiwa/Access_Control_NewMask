
--Terminals
IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TM 560bc') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'Biometric/RFID', Access = 'Nein', Image = '/Images/FormImages/tm560bcsm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'TM560bc.aspx' WHERE TermType = 'TM 560bc'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TM 560bc' , 'TCPIP' , 'Biometric/RFID' , 'Nein' , '/Images/FormImages/tm560bcsm.png' , 'Krutec ZK' , '1' , 'TM560bc.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TM 560tc') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'RFID', Access = 'Nein', Image = '/Images/FormImages/tm560tcsm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'TM560tc.aspx' WHERE TermType = 'TM 560tc'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TM 560tc' , 'TCPIP' , 'RFID' , 'Nein' , '/Images/FormImages/tm560tcsm.png' , 'Krutec ZK' , '1' , 'TM560tc.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TM 680tc') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'RFID', Access = 'Nein', Image = '/Images/FormImages/TM680tsm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'TM680tc.aspx' WHERE TermType = 'TM 680tc'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TM 680tc' , 'TCPIP' , 'RFID' , 'Nein' , '/Images/FormImages/TM680tsm.png' , 'Krutec ZK' , '1' , 'TM680tc.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TM 680bc') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'Biometric/RFID', Access = 'Ja', Image = '/Images/FormImages/tm680bc-50px.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'TM680bc.aspx' WHERE TermType = 'TM 680bc'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TM 680bc' , 'TCPIP' , 'Biometric/RFID' , 'Ja' , '/Images/FormImages/tm680bc-50px.png' , 'Krutec ZK' , '1' , 'TM680bc.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TM 900bc') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'Biometric/RFID', Access = 'Ja', Image = '/Images/FormImages/tm900bcsm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'TM900bc.aspx' WHERE TermType = 'TM 900bc'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TM 900bc' , 'TCPIP' , 'Biometric/RFID' , 'Ja' , '/Images/FormImages/tm900bcsm.png' , 'Krutec ZK' , '1' , 'TM900bc.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'SC403') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'RFID', Access = 'Ja', Image = '/Images/FormImages/sc403sm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'SC403.aspx' WHERE TermType = 'SC403'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('SC403' , 'TCPIP' , 'RFID' , 'Ja' , '/Images/FormImages/sc403sm.png' , 'Krutec ZK' , '1' , 'SC403.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'SCR 100') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'RFID', Access = 'Ja', Image = '/Images/FormImages/src100sm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'SRC100.aspx' WHERE TermType = 'SCR 100'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('SCR 100' , 'TCPIP' , 'RFID' , 'Ja' , '/Images/FormImages/src100sm.png' , 'Krutec ZK' , '1' , 'SRC100.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'MA300out') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'Biometric/RFID', Access = 'Ja', Image = '/Images/FormImages/MA300outsm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'MA300out.aspx' WHERE TermType = 'MA300out'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('MA300out' , 'TCPIP' , 'Biometric/RFID' , 'Ja' , '/Images/FormImages/MA300outsm.png' , 'Krutec ZK' , '1' , 'MA300out.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TF 1700') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'Biometric/RFID', Access = 'Ja', Image = '/Images/FormImages/zf1700sm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'TF1700.aspx' WHERE TermType = 'TF 1700'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TF 1700' , 'TCPIP' , 'Biometric/RFID' , 'Ja' , '/Images/FormImages/zf1700sm.png' , 'Krutec ZK' , '1' , 'TF1700.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'ZB702in') 
BEGIN 

UPDATE Terminals SET Connection = 'TCPIP', Reader = 'Biometric/RFID', Access = 'Ja', Image = '/Images/FormImages/zb702insm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'ZB702in.aspx' WHERE TermType = 'ZB702in'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('ZB702in' , 'TCPIP' , 'Biometric/RFID' , 'Ja' , '/Images/FormImages/zb702insm.png' , 'Krutec ZK' , '1' , 'ZB702in.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'ZB703in') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'Biometric/RFID', Access = 'Ja', Image = '/Images/FormImages/ZB703insm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'ZB703in.aspx' WHERE TermType = 'ZB703in'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('ZB703in' , 'TCPIP' , 'Biometric/RFID' , 'Ja' , '/Images/FormImages/ZB703insm.png' , 'Krutec ZK' , '1' , 'ZB703in.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'ZBBi-402') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'Biometric/RFID', Access = 'Ja', Image = '/Images/FormImages/ZBBI402sm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'ZBBI402_New.aspx' WHERE TermType = 'ZBBi-402'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('ZBBi-402' , 'TCPIP' , 'Biometric/RFID' , 'Ja' , '/Images/FormImages/ZBBI402sm.png' , 'Krutec ZK' , '1' , 'ZBBI402_New.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'ZBBi-404') 
BEGIN 
UPDATE Terminals SET Connection = 'TCPIP', Reader = 'Biometric/RFID', Access = 'Ja', Image = '/Images/FormImages/ZBBI402sm.png', TermOEM = 'Krutec ZK', TermOEMID = '1', TerminalPage = 'ZBBi-404New.aspx' WHERE TermType = 'ZBBi-404'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('ZBBi-404' , 'TCPIP' , 'Biometric/RFID' , 'Ja' , '/Images/FormImages/ZBBI402sm.png' , 'Krutec ZK' , '1' , 'ZBBi-404New.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TM EVO 2.8') 
BEGIN 
UPDATE Terminals SET Connection = '', Reader = '', Access = '', Image = '/Images/FormImages/evo2sm.png', TermOEM = 'Datafox', TermOEMID = '2', TerminalPage = 'DatafoxNew.aspx' WHERE TermType = 'TM EVO 2.8'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TM EVO 2.8' , '' , '' , '' , '/Images/FormImages/evo2sm.png' , 'Datafox' , '2' , 'DatafoxNew.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TM EVO 4.3') 
BEGIN 
UPDATE Terminals SET Connection = '', Reader = '', Access = '', Image = '/Images/FormImages/evo4sm.png', TermOEM = 'Datafox', TermOEMID = '2', TerminalPage = 'DatafoxNewEvo43.aspx' WHERE TermType = 'TM EVO 4.3'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TM EVO 4.3' , '' , '' , '' , '/Images/FormImages/evo4sm.png' , 'Datafox' , '2' , 'DatafoxNewEvo43.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'PZE- MasterIV') 
BEGIN 
UPDATE Terminals SET Connection = '', Reader = '', Access = '', Image = '/Images/FormImages/pze-masterIVsm.png', TermOEM = 'Datafox', TermOEMID = '2', TerminalPage = 'DatafoxPZEMasterIV.aspx' WHERE TermType = 'PZE- MasterIV'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('PZE- MasterIV' , '' , '' , '' , '/Images/FormImages/pze-masterIVsm.png' , 'Datafox' , '2' , 'DatafoxPZEMasterIV.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TM Master IV') 
BEGIN 
UPDATE Terminals SET Connection = '', Reader = '', Access = '', Image = '/Images/FormImages/TmmasterIVsm.png', TermOEM = 'Datafox', TermOEMID = '2', TerminalPage = 'DatafoxTMMasterIV.aspx' WHERE TermType = 'TM Master IV'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TM Master IV' , '' , '' , '' , '/Images/FormImages/TmmasterIVsm.png' , 'Datafox' , '2' , 'DatafoxTMMasterIV.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'TM Flex Master') 
BEGIN 
UPDATE Terminals SET Connection = '', Reader = '', Access = '', Image = '/Images/FormImages/Tmflexmastersm.png', TermOEM = 'Datafox', TermOEMID = '2', TerminalPage = 'DatafoxTMFlexMaster.aspx' WHERE TermType = 'TM Flex Master'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('TM Flex Master' , '' , '' , '' , '/Images/FormImages/Tmflexmastersm.png' , 'Datafox' , '2' , 'DatafoxTMFlexMaster.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'Timeboy IV') 
BEGIN 
UPDATE Terminals SET Connection = '', Reader = '', Access = '', Image = '/Images/FormImages/TimeboyIVsm.png', TermOEM = 'Datafox', TermOEMID = '2', TerminalPage = 'DatafoxTimeboxIV.aspx' WHERE TermType = 'Timeboy IV'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('Timeboy IV' , '' , '' , '' , '/Images/FormImages/TimeboyIVsm.png' , 'Datafox' , '2' , 'DatafoxTimeboxIV.aspx' ) 
END 
GO 

IF EXISTS(SELECT * FROM Terminals WHERE TermType = 'ZK Master IV') 
BEGIN 
UPDATE Terminals SET Connection = '', Reader = '', Access = '', Image = '/Images/FormImages/zk-mastersm.png', TermOEM = 'Datafox', TermOEMID = '2', TerminalPage = 'DatafoxMasterIV.aspx' WHERE TermType = 'ZK Master IV'
END 
ELSE 
BEGIN 
INSERT INTO Terminals (TermType , Connection , Reader , Access , Image , TermOEM , TermOEMID , TerminalPage ) VALUES('ZK Master IV' , '' , '' , '' , '/Images/FormImages/zk-mastersm.png' , 'Datafox' , '2' , 'DatafoxMasterIV.aspx' ) 
END 
GO 


