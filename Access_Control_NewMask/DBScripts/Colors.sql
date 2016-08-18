		--Colors
IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#00FF00') 
BEGIN 
UPDATE Colors SET ColorCode = '0,255,255,255', ColorComment = '' WHERE ColorName = '#00FF00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#00FF00' , '0,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#33CCCC') 
BEGIN 
UPDATE Colors SET ColorCode = '51,204,204,255', ColorComment = '' WHERE ColorName = '#33CCCC'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#33CCCC' , '51,204,204,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFF00') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFF00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFF00' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFFF' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFCC') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFCC'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFCC' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FF6600') 
BEGIN 
UPDATE Colors SET ColorCode = '255,102,102,255', ColorComment = '' WHERE ColorName = '#FF6600'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FF6600' , '255,102,102,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#800000') 
BEGIN 
UPDATE Colors SET ColorCode = '128,0,0,255', ColorComment = '' WHERE ColorName = '#800000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#800000' , '128,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#00FF00') 
BEGIN 
UPDATE Colors SET ColorCode = '0,255,255,255', ColorComment = '' WHERE ColorName = '#00FF00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#00FF00' , '0,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFCC00') 
BEGIN 
UPDATE Colors SET ColorCode = '255,204,204,255', ColorComment = '' WHERE ColorName = '#FFCC00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFCC00' , '255,204,204,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#00FF00') 
BEGIN 
UPDATE Colors SET ColorCode = '0,255,255,255', ColorComment = '' WHERE ColorName = '#00FF00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#00FF00' , '0,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFCC00') 
BEGIN 
UPDATE Colors SET ColorCode = '255,204,204,255', ColorComment = '' WHERE ColorName = '#FFCC00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFCC00' , '255,204,204,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFF00') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFF00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFF00' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFCC') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFCC'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFCC' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFF00') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFF00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFF00' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFF99') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFF99'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFF99' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#008000') 
BEGIN 
UPDATE Colors SET ColorCode = '0,128,128,255', ColorComment = '' WHERE ColorName = '#008000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#008000' , '0,128,128,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFCC') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFCC'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFCC' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#800000') 
BEGIN 
UPDATE Colors SET ColorCode = '128,0,0,255', ColorComment = '' WHERE ColorName = '#800000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#800000' , '128,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#008000') 
BEGIN 
UPDATE Colors SET ColorCode = '0,128,128,255', ColorComment = '' WHERE ColorName = '#008000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#008000' , '0,128,128,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#3366FF') 
BEGIN 
UPDATE Colors SET ColorCode = '51,102,102,255', ColorComment = '' WHERE ColorName = '#3366FF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#3366FF' , '51,102,102,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#808000') 
BEGIN 
UPDATE Colors SET ColorCode = '128,128,128,255', ColorComment = '' WHERE ColorName = '#808000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#808000' , '128,128,128,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#993300') 
BEGIN 
UPDATE Colors SET ColorCode = '153,51,51,255', ColorComment = '' WHERE ColorName = '#993300'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#993300' , '153,51,51,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#00FFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '0,255,255,255', ColorComment = '' WHERE ColorName = '#00FFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#00FFFF' , '0,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#33CCCC') 
BEGIN 
UPDATE Colors SET ColorCode = '51,204,204,255', ColorComment = '' WHERE ColorName = '#33CCCC'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#33CCCC' , '51,204,204,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFFF' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CC99FF') 
BEGIN 
UPDATE Colors SET ColorCode = '204,153,153,255', ColorComment = '' WHERE ColorName = '#CC99FF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CC99FF' , '204,153,153,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFCC') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFCC'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFCC' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FF00FF') 
BEGIN 
UPDATE Colors SET ColorCode = '255,0,0,255', ColorComment = '' WHERE ColorName = '#FF00FF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FF00FF' , '255,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFFF' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FF6600') 
BEGIN 
UPDATE Colors SET ColorCode = '255,102,102,255', ColorComment = '' WHERE ColorName = '#FF6600'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FF6600' , '255,102,102,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FF6600') 
BEGIN 
UPDATE Colors SET ColorCode = '255,102,102,255', ColorComment = '' WHERE ColorName = '#FF6600'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FF6600' , '255,102,102,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFFF' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFFF' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#000000') 
BEGIN 
UPDATE Colors SET ColorCode = '0,0,0,255', ColorComment = '' WHERE ColorName = '#000000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#000000' , '0,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#000000') 
BEGIN 
UPDATE Colors SET ColorCode = '0,0,0,255', ColorComment = '' WHERE ColorName = '#000000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#000000' , '0,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFFF' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFFFF' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FF0000') 
BEGIN 
UPDATE Colors SET ColorCode = '255,0,0,255', ColorComment = '' WHERE ColorName = '#FF0000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FF0000' , '255,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FF0000') 
BEGIN 
UPDATE Colors SET ColorCode = '255,0,0,255', ColorComment = '' WHERE ColorName = '#FF0000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FF0000' , '255,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFFFF' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#00FF00') 
BEGIN 
UPDATE Colors SET ColorCode = '0,255,255,255', ColorComment = '' WHERE ColorName = '#00FF00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#00FF00' , '0,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFFF' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#800000') 
BEGIN 
UPDATE Colors SET ColorCode = '128,0,0,255', ColorComment = '' WHERE ColorName = '#800000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#800000' , '128,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFFFF' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#800000') 
BEGIN 
UPDATE Colors SET ColorCode = '128,0,0,255', ColorComment = '' WHERE ColorName = '#800000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#800000' , '128,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFFFF' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FF0000') 
BEGIN 
UPDATE Colors SET ColorCode = '255,0,0,255', ColorComment = '' WHERE ColorName = '#FF0000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FF0000' , '255,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFFFF' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FF0000') 
BEGIN 
UPDATE Colors SET ColorCode = '255,0,0,255', ColorComment = '' WHERE ColorName = '#FF0000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FF0000' , '255,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFFFF' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#000000') 
BEGIN 
UPDATE Colors SET ColorCode = '0,0,0,255', ColorComment = '' WHERE ColorName = '#000000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#000000' , '0,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#CCFFCC') 
BEGIN 
UPDATE Colors SET ColorCode = '204,255,255,255', ColorComment = '' WHERE ColorName = '#CCFFCC'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#CCFFCC' , '204,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFCC00') 
BEGIN 
UPDATE Colors SET ColorCode = '255,204,204,255', ColorComment = '' WHERE ColorName = '#FFCC00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFCC00' , '255,204,204,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFFFF' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#000000') 
BEGIN 
UPDATE Colors SET ColorCode = '0,0,0,255', ColorComment = '' WHERE ColorName = '#000000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#000000' , '0,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFCC00') 
BEGIN 
UPDATE Colors SET ColorCode = '255,204,204,255', ColorComment = '' WHERE ColorName = '#FFCC00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFCC00' , '255,204,204,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#000000') 
BEGIN 
UPDATE Colors SET ColorCode = '0,0,0,255', ColorComment = '' WHERE ColorName = '#000000'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#000000' , '0,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFCC00') 
BEGIN 
UPDATE Colors SET ColorCode = '255,204,204,255', ColorComment = '' WHERE ColorName = '#FFCC00'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFCC00' , '255,204,204,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#0000FF') 
BEGIN 
UPDATE Colors SET ColorCode = '0,0,0,255', ColorComment = '' WHERE ColorName = '#0000FF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#0000FF' , '0,0,0,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '#FFFFFF') 
BEGIN 
UPDATE Colors SET ColorCode = '255,255,255,255', ColorComment = '' WHERE ColorName = '#FFFFFF'
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('#FFFFFF' , '255,255,255,255' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '') 
BEGIN 
UPDATE Colors SET ColorCode = '0,0,0,0', ColorComment = '' WHERE ColorName = ''
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('' , '0,0,0,0' , '' ) 
END 
GO 

IF EXISTS(SELECT * FROM Colors WHERE ColorName = '') 
BEGIN 
UPDATE Colors SET ColorCode = '0,0,0,0', ColorComment = '' WHERE ColorName = ''
END 
ELSE 
BEGIN 
INSERT INTO Colors (ColorName , ColorCode , ColorComment ) VALUES('' , '0,0,0,0' , '' ) 
END 
GO 


