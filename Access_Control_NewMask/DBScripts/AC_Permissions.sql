
			--AC_Permissions
IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Terminal Configuration Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to TermKonfig' WHERE Permission = 'Terminal Configuration Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Terminal Configuration Complete Access' , 'Allow access to TermKonfig' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Access Control Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to anything in Access Control' WHERE Permission = 'Access Control Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Access Control Complete Access' , 'Allow access to anything in Access Control' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Settings ') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to all Settings In Access Controls' WHERE Permission = 'Settings '
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Settings ' , 'Allow access to all Settings In Access Controls' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Personnel Dataset Settings Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to all Personnel dataset Settings' WHERE Permission = 'Personnel Dataset Settings Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Personnel Dataset Settings Complete Access' , 'Allow access to all Personnel dataset Settings' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Location Setting') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Location Settings for the Personnel dataset' WHERE Permission = 'Location Setting'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Location Setting' , 'Allow access to Location Settings for the Personnel dataset' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Department Setting') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Department Settings for the Personnel dataset' WHERE Permission = 'Department Setting'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Department Setting' , 'Allow access to Department Settings for the Personnel dataset' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Cost Center Setting') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Cost Center Settings for the Personnel dataset' WHERE Permission = 'Cost Center Setting'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Cost Center Setting' , 'Allow access to Cost Center Settings for the Personnel dataset' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Vehicle Settings') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Vehicle Settings for the Personnel dataset' WHERE Permission = 'Vehicle Settings'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Vehicle Settings' , 'Allow access to Vehicle Settings for the Personnel dataset' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Access Control Settings Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to all Access Control Configurations' WHERE Permission = 'Access Control Settings Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Access Control Settings Complete Access' , 'Allow access to all Access Control Configurations' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'General Settings Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to General Access Control Settings' WHERE Permission = 'General Settings Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('General Settings Complete Access' , 'Allow access to General Access Control Settings' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Language ') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow Change of Language' WHERE Permission = 'Language '
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Language ' , 'Allow Change of Language' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Profile Group ') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Profile Groups' WHERE Permission = 'Profile Group '
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Profile Group ' , 'Allow access to Profile Groups' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Plan Group ') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Plan Groups' WHERE Permission = 'Plan Group '
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Plan Group ' , 'Allow access to Plan Groups' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Icons') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Icons' WHERE Permission = 'Icons'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Icons' , 'Allow access to Icons' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Rights Assignment ') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Rights Assignment and creation' WHERE Permission = 'Rights Assignment '
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Rights Assignment ' , 'Allow access to Rights Assignment and creation' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Password Setting') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow Change of Passwords' WHERE Permission = 'Password Setting'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Password Setting' , 'Allow Change of Passwords' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Master Data Settings Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to all Master DataSet' WHERE Permission = 'Master Data Settings Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Master Data Settings Complete Access' , 'Allow access to all Master DataSet' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Personnel DataSet Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Personnel DataSet' WHERE Permission = 'Personnel DataSet Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Personnel DataSet Complete Access' , 'Allow access to Personnel DataSet' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Building Plan Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Building Plan' WHERE Permission = 'Building Plan Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Building Plan Complete Access' , 'Allow access to Building Plan' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Access Plan Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to all Access Plan Settings and Info' WHERE Permission = 'Access Plan Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Access Plan Complete Access' , 'Allow access to all Access Plan Settings and Info' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Access Plan Settings Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Access Plan Settings' WHERE Permission = 'Access Plan Settings Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Access Plan Settings Access' , 'Allow access to Access Plan Settings' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Access Plan Info Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Access Plan Information' WHERE Permission = 'Access Plan Info Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Access Plan Info Access' , 'Allow access to Access Plan Information' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Switch Plan Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow aceess to all Switch Plan Settings and Info' WHERE Permission = 'Switch Plan Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Switch Plan Complete Access' , 'Allow aceess to all Switch Plan Settings and Info' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Switch Plan Settings Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Switch Plan Settings' WHERE Permission = 'Switch Plan Settings Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Switch Plan Settings Access' , 'Allow access to Switch Plan Settings' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Switch Plan Info Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow Access to Switch Plan Information' WHERE Permission = 'Switch Plan Info Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Switch Plan Info Access' , 'Allow Access to Switch Plan Information' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Visitor Managment Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to all Visitor Management settings' WHERE Permission = 'Visitor Managment Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Visitor Managment Complete Access' , 'Allow access to all Visitor Management settings' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Visitor Login Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Visitor Login settings' WHERE Permission = 'Visitor Login Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Visitor Login Access' , 'Allow access to Visitor Login settings' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Visitor DataSet Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Visitor DataSet' WHERE Permission = 'Visitor DataSet Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Visitor DataSet Access' , 'Allow access to Visitor DataSet' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Visitor Plan Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Visitor Plans' WHERE Permission = 'Visitor Plan Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Visitor Plan Access' , 'Allow access to Visitor Plans' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Safety Managment Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to all Safety Managemrnt Modules' WHERE Permission = 'Safety Managment Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Safety Managment Complete Access' , 'Allow access to all Safety Managemrnt Modules' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Grader Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Grader' WHERE Permission = 'Grader Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Grader Access' , 'Allow access to Grader' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Safety Control Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Safety Control Center' WHERE Permission = 'Safety Control Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Safety Control Access' , 'Allow access to Safety Control Center' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Alarm Function Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Alarm Function' WHERE Permission = 'Alarm Function Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Alarm Function Access' , 'Allow access to Alarm Function' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Lists Complete Access') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow access to Lists' WHERE Permission = 'Lists Complete Access'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Lists Complete Access' , 'Allow access to Lists' ) 
END 
GO 

IF EXISTS(SELECT * FROM AC_Permissions WHERE Permission = 'Communication') 
BEGIN 
UPDATE AC_Permissions SET Memo = 'Allow Communication operations' WHERE Permission = 'Communication'
END 
ELSE 
BEGIN 
INSERT INTO AC_Permissions (Permission , Memo ) VALUES('Communication' , 'Allow Communication operations' ) 
END 
GO 


