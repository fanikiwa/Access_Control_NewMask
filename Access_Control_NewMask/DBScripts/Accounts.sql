						--Accounts
IF EXISTS(SELECT * FROM Accounts WHERE AccountNo = '1') 
BEGIN 
UPDATE Accounts SET Name = 'Sollzeit', StandardAccount = 'True', DisplayFormat = 'STD:MIN', AccInfo = 'It tracks the total number working hours an employee should work', Abbr = ' ', TransferAcc = ' ', BillingMacro = ' ' WHERE AccountNo = '1'
END 
ELSE 
BEGIN 
INSERT INTO Accounts (AccountNo , Name , StandardAccount , DisplayFormat , AccInfo , Abbr , TransferAcc , BillingMacro ) VALUES('1' , 'Sollzeit' , 'True' , 'STD:MIN' , 'It tracks the total number working hours an employee should work' , ' ' , ' ' , ' ' ) 
END 
GO 

IF EXISTS(SELECT * FROM Accounts WHERE AccountNo = '2') 
BEGIN 
UPDATE Accounts SET Name = 'Istzeit', StandardAccount = 'True', DisplayFormat = 'STD:MIN', AccInfo = 'Istzeit', Abbr = ' ', TransferAcc = ' ', BillingMacro = ' ' WHERE AccountNo = '2'
END 
ELSE 
BEGIN 
INSERT INTO Accounts (AccountNo , Name , StandardAccount , DisplayFormat , AccInfo , Abbr , TransferAcc , BillingMacro ) VALUES('2' , 'Istzeit' , 'True' , 'STD:MIN' , 'Istzeit' , ' ' , ' ' , ' ' ) 
END 
GO 

IF EXISTS(SELECT * FROM Accounts WHERE AccountNo = '3') 
BEGIN 
UPDATE Accounts SET Name = 'Differenzkonto', StandardAccount = 'True', DisplayFormat = 'STD:MIN', AccInfo = 'Tracks the difference between Sollzeit and Istzeit', Abbr = ' ', TransferAcc = ' ', BillingMacro = ' ' WHERE AccountNo = '3'
END 
ELSE 
BEGIN 
INSERT INTO Accounts (AccountNo , Name , StandardAccount , DisplayFormat , AccInfo , Abbr , TransferAcc , BillingMacro ) VALUES('3' , 'Differenzkonto' , 'True' , 'STD:MIN' , 'Tracks the difference between Sollzeit and Istzeit' , ' ' , ' ' , ' ' ) 
END 
GO 

IF EXISTS(SELECT * FROM Accounts WHERE AccountNo = '4') 
BEGIN 
UPDATE Accounts SET Name = 'Pausen', StandardAccount = 'True', DisplayFormat = 'STD:MIN', AccInfo = 'Tracks the time an employee has spent on breaks', Abbr = ' ', TransferAcc = ' ', BillingMacro = ' ' WHERE AccountNo = '4'
END 
ELSE 
BEGIN 
INSERT INTO Accounts (AccountNo , Name , StandardAccount , DisplayFormat , AccInfo , Abbr , TransferAcc , BillingMacro ) VALUES('4' , 'Pausen' , 'True' , 'STD:MIN' , 'Tracks the time an employee has spent on breaks' , ' ' , ' ' , ' ' ) 
END 
GO 


