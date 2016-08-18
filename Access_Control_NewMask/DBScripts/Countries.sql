
				--Countries

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AF') 
BEGIN 
UPDATE Countries SET EN_Name = 'Afghanistan', DE_Name = 'Afghanistan' WHERE Code = 'AF'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AF' , 'Afghanistan' , 'Afghanistan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AX') 
BEGIN 
UPDATE Countries SET EN_Name = 'Aland', DE_Name = 'Åland' WHERE Code = 'AX'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AX' , 'Aland' , 'Åland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AL') 
BEGIN 
UPDATE Countries SET EN_Name = 'Albania', DE_Name = 'Albanien' WHERE Code = 'AL'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AL' , 'Albania' , 'Albanien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'DZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Algeria', DE_Name = 'Algerien' WHERE Code = 'DZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('DZ' , 'Algeria' , 'Algerien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AS') 
BEGIN 
UPDATE Countries SET EN_Name = 'American Samoa', DE_Name = 'Amerikanisch-Samoa' WHERE Code = 'AS'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AS' , 'American Samoa' , 'Amerikanisch-Samoa' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AD') 
BEGIN 
UPDATE Countries SET EN_Name = 'Andorra', DE_Name = 'Andorra' WHERE Code = 'AD'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AD' , 'Andorra' , 'Andorra' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Angola', DE_Name = 'Angola' WHERE Code = 'AO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AO' , 'Angola' , 'Angola' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Anguilla', DE_Name = 'Anguilla' WHERE Code = 'AI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AI' , 'Anguilla' , 'Anguilla' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AQ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Antarctica', DE_Name = 'Antarktis' WHERE Code = 'AQ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AQ' , 'Antarctica' , 'Antarktis' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Antigua And Barbuda', DE_Name = 'Antigua/Barbuda' WHERE Code = 'AG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AG' , 'Antigua And Barbuda' , 'Antigua/Barbuda' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Argentina', DE_Name = 'Argentinien' WHERE Code = 'AR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AR' , 'Argentina' , 'Argentinien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Armenia', DE_Name = 'Armenien' WHERE Code = 'AM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AM' , 'Armenia' , 'Armenien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AW') 
BEGIN 
UPDATE Countries SET EN_Name = 'Aruba', DE_Name = 'Aruba' WHERE Code = 'AW'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AW' , 'Aruba' , 'Aruba' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AU') 
BEGIN 
UPDATE Countries SET EN_Name = 'Australia', DE_Name = 'Australien' WHERE Code = 'AU'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AU' , 'Australia' , 'Australien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Austria', DE_Name = 'Österreich' WHERE Code = 'AT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AT' , 'Austria' , 'Österreich' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Azerbaijan', DE_Name = 'Aserbaidschan' WHERE Code = 'AZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AZ' , 'Azerbaijan' , 'Aserbaidschan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BS') 
BEGIN 
UPDATE Countries SET EN_Name = 'Bahamas', DE_Name = 'Bahamas' WHERE Code = 'BS'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BS' , 'Bahamas' , 'Bahamas' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BH') 
BEGIN 
UPDATE Countries SET EN_Name = 'Bahrain', DE_Name = 'Bahrain' WHERE Code = 'BH'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BH' , 'Bahrain' , 'Bahrain' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BD') 
BEGIN 
UPDATE Countries SET EN_Name = 'Bangladesh', DE_Name = 'Bangladesh' WHERE Code = 'BD'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BD' , 'Bangladesh' , 'Bangladesh' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BB') 
BEGIN 
UPDATE Countries SET EN_Name = 'Barbados', DE_Name = 'Barbados' WHERE Code = 'BB'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BB' , 'Barbados' , 'Barbados' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BY') 
BEGIN 
UPDATE Countries SET EN_Name = 'Belarus', DE_Name = 'Weißrussland' WHERE Code = 'BY'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BY' , 'Belarus' , 'Weißrussland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Belgium', DE_Name = 'Belgien' WHERE Code = 'BE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BE' , 'Belgium' , 'Belgien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Belize', DE_Name = 'Belize' WHERE Code = 'BZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BZ' , 'Belize' , 'Belize' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BJ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Benin', DE_Name = 'Benin' WHERE Code = 'BJ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BJ' , 'Benin' , 'Benin' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Bermuda', DE_Name = 'Bermuda' WHERE Code = 'BM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BM' , 'Bermuda' , 'Bermuda' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Bhutan', DE_Name = 'Bhutan' WHERE Code = 'BT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BT' , 'Bhutan' , 'Bhutan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Bolivia', DE_Name = 'Bolivien' WHERE Code = 'BO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BO' , 'Bolivia' , 'Bolivien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Bosnia And Herzegowina', DE_Name = 'Bosnien/Herzegowina' WHERE Code = 'BA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BA' , 'Bosnia And Herzegowina' , 'Bosnien/Herzegowina' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BW') 
BEGIN 
UPDATE Countries SET EN_Name = 'Botswana', DE_Name = 'Botsuana' WHERE Code = 'BW'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BW' , 'Botswana' , 'Botsuana' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BV') 
BEGIN 
UPDATE Countries SET EN_Name = 'Bouvet Island', DE_Name = 'Bouvetinsel' WHERE Code = 'BV'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BV' , 'Bouvet Island' , 'Bouvetinsel' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Brazil', DE_Name = 'Brasilien' WHERE Code = 'BR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BR' , 'Brazil' , 'Brasilien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'IO') 
BEGIN 
UPDATE Countries SET EN_Name = 'British Indian Ocean Territory', DE_Name = 'British Indian Ocean Territory' WHERE Code = 'IO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('IO' , 'British Indian Ocean Territory' , 'British Indian Ocean Territory' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Brunei Darussalam', DE_Name = 'Brunei Darussalam' WHERE Code = 'BN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BN' , 'Brunei Darussalam' , 'Brunei Darussalam' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Bulgaria', DE_Name = 'Bulgarien' WHERE Code = 'BG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BG' , 'Bulgaria' , 'Bulgarien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BF') 
BEGIN 
UPDATE Countries SET EN_Name = 'Burkina Faso', DE_Name = 'Burkina Faso' WHERE Code = 'BF'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BF' , 'Burkina Faso' , 'Burkina Faso' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Burundi', DE_Name = 'Burundi' WHERE Code = 'BI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BI' , 'Burundi' , 'Burundi' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KH') 
BEGIN 
UPDATE Countries SET EN_Name = 'Cambodia', DE_Name = 'Kambodscha' WHERE Code = 'KH'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KH' , 'Cambodia' , 'Kambodscha' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Cameroon', DE_Name = 'Kamerun' WHERE Code = 'CM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CM' , 'Cameroon' , 'Kamerun' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Canada', DE_Name = 'Kanada' WHERE Code = 'CA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CA' , 'Canada' , 'Kanada' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CV') 
BEGIN 
UPDATE Countries SET EN_Name = 'Cape Verde', DE_Name = 'Cabo Verde' WHERE Code = 'CV'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CV' , 'Cape Verde' , 'Cabo Verde' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KY') 
BEGIN 
UPDATE Countries SET EN_Name = 'Cayman Islands', DE_Name = 'Kaimaninseln' WHERE Code = 'KY'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KY' , 'Cayman Islands' , 'Kaimaninseln' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CF') 
BEGIN 
UPDATE Countries SET EN_Name = 'Central African Republic', DE_Name = 'Zentralafrikanische Republik' WHERE Code = 'CF'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CF' , 'Central African Republic' , 'Zentralafrikanische Republik' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TD') 
BEGIN 
UPDATE Countries SET EN_Name = 'Chad', DE_Name = 'Tschad' WHERE Code = 'TD'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TD' , 'Chad' , 'Tschad' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CL') 
BEGIN 
UPDATE Countries SET EN_Name = 'Chile', DE_Name = 'Chile' WHERE Code = 'CL'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CL' , 'Chile' , 'Chile' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CN') 
BEGIN 
UPDATE Countries SET EN_Name = 'China', DE_Name = 'China' WHERE Code = 'CN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CN' , 'China' , 'China' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CX') 
BEGIN 
UPDATE Countries SET EN_Name = 'Christmas Island', DE_Name = 'Weihnachtsinsel' WHERE Code = 'CX'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CX' , 'Christmas Island' , 'Weihnachtsinsel' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CC') 
BEGIN 
UPDATE Countries SET EN_Name = 'Cocos (Keeling) Islands', DE_Name = 'Kokosinseln' WHERE Code = 'CC'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CC' , 'Cocos (Keeling) Islands' , 'Kokosinseln' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Colombia', DE_Name = 'Kolumbien' WHERE Code = 'CO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CO' , 'Colombia' , 'Kolumbien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Comoros', DE_Name = 'Komoren' WHERE Code = 'KM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KM' , 'Comoros' , 'Komoren' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Congo', DE_Name = 'Kongo' WHERE Code = 'CG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CG' , 'Congo' , 'Kongo' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CK') 
BEGIN 
UPDATE Countries SET EN_Name = 'Cook Islands', DE_Name = 'Cookinseln' WHERE Code = 'CK'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CK' , 'Cook Islands' , 'Cookinseln' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Costa Rica', DE_Name = 'Costa Rica' WHERE Code = 'CR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CR' , 'Costa Rica' , 'Costa Rica' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Cote D''Ivoire', DE_Name = 'Elfenbeinküste' WHERE Code = 'CI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CI' , 'Cote D''Ivoire' , 'Elfenbeinküste' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'HR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Croatia (Local Name: Hrvatska)', DE_Name = 'Kroatien' WHERE Code = 'HR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('HR' , 'Croatia (Local Name: Hrvatska)' , 'Kroatien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CU') 
BEGIN 
UPDATE Countries SET EN_Name = 'Cuba', DE_Name = 'Cuba' WHERE Code = 'CU'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CU' , 'Cuba' , 'Cuba' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CY') 
BEGIN 
UPDATE Countries SET EN_Name = 'Cyprus', DE_Name = 'Zypern' WHERE Code = 'CY'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CY' , 'Cyprus' , 'Zypern' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Czech Republic', DE_Name = 'Tschechoslowakei' WHERE Code = 'CZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CZ' , 'Czech Republic' , 'Tschechoslowakei' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'DK') 
BEGIN 
UPDATE Countries SET EN_Name = 'Denmark', DE_Name = 'Dänemark' WHERE Code = 'DK'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('DK' , 'Denmark' , 'Dänemark' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'DJ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Djibouti', DE_Name = 'Dschibuti' WHERE Code = 'DJ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('DJ' , 'Djibouti' , 'Dschibuti' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'DM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Dominica', DE_Name = 'Dominica' WHERE Code = 'DM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('DM' , 'Dominica' , 'Dominica' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'DO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Dominican Republic', DE_Name = 'Dominikanische Republik' WHERE Code = 'DO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('DO' , 'Dominican Republic' , 'Dominikanische Republik' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TP') 
BEGIN 
UPDATE Countries SET EN_Name = 'East Timor', DE_Name = 'East Timor' WHERE Code = 'TP'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TP' , 'East Timor' , 'East Timor' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'EC') 
BEGIN 
UPDATE Countries SET EN_Name = 'Ecuador', DE_Name = 'Ecuador' WHERE Code = 'EC'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('EC' , 'Ecuador' , 'Ecuador' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'EG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Egypt', DE_Name = 'Ägypten' WHERE Code = 'EG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('EG' , 'Egypt' , 'Ägypten' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SV') 
BEGIN 
UPDATE Countries SET EN_Name = 'El Salvador', DE_Name = 'El Salvador' WHERE Code = 'SV'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SV' , 'El Salvador' , 'El Salvador' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GQ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Equatorial Guinea', DE_Name = 'Äquatorialguinea' WHERE Code = 'GQ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GQ' , 'Equatorial Guinea' , 'Äquatorialguinea' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ER') 
BEGIN 
UPDATE Countries SET EN_Name = 'Eritrea', DE_Name = 'Eritrea' WHERE Code = 'ER'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ER' , 'Eritrea' , 'Eritrea' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'EE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Estonia', DE_Name = 'Estland' WHERE Code = 'EE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('EE' , 'Estonia' , 'Estland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ET') 
BEGIN 
UPDATE Countries SET EN_Name = 'Ethiopia', DE_Name = 'Äthiopien' WHERE Code = 'ET'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ET' , 'Ethiopia' , 'Äthiopien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'FK') 
BEGIN 
UPDATE Countries SET EN_Name = 'Falkland Islands (Malvinas)', DE_Name = 'Falklandinseln' WHERE Code = 'FK'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('FK' , 'Falkland Islands (Malvinas)' , 'Falklandinseln' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'FO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Faroe Islands', DE_Name = 'Färöer' WHERE Code = 'FO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('FO' , 'Faroe Islands' , 'Färöer' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'FJ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Fiji', DE_Name = 'Fidschi' WHERE Code = 'FJ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('FJ' , 'Fiji' , 'Fidschi' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'FI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Finland', DE_Name = 'Finnland' WHERE Code = 'FI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('FI' , 'Finland' , 'Finnland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'FR') 
BEGIN 
UPDATE Countries SET EN_Name = 'France', DE_Name = 'Frankreich' WHERE Code = 'FR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('FR' , 'France' , 'Frankreich' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GF') 
BEGIN 
UPDATE Countries SET EN_Name = 'French Guiana', DE_Name = 'Französisch-Guayana' WHERE Code = 'GF'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GF' , 'French Guiana' , 'Französisch-Guayana' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PF') 
BEGIN 
UPDATE Countries SET EN_Name = 'French Polynesia', DE_Name = 'Französisch-Polynesien' WHERE Code = 'PF'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PF' , 'French Polynesia' , 'Französisch-Polynesien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TF') 
BEGIN 
UPDATE Countries SET EN_Name = 'French Southern Territories', DE_Name = 'Französische Südpolarterritorien' WHERE Code = 'TF'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TF' , 'French Southern Territories' , 'Französische Südpolarterritorien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Gabon', DE_Name = 'Gabun' WHERE Code = 'GA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GA' , 'Gabon' , 'Gabun' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Gambia', DE_Name = 'Gambia' WHERE Code = 'GM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GM' , 'Gambia' , 'Gambia' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Georgia', DE_Name = 'Georgien' WHERE Code = 'GE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GE' , 'Georgia' , 'Georgien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'DE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Germany', DE_Name = 'Deutschland' WHERE Code = 'DE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('DE' , 'Germany' , 'Deutschland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GH') 
BEGIN 
UPDATE Countries SET EN_Name = 'Ghana', DE_Name = 'Ghana' WHERE Code = 'GH'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GH' , 'Ghana' , 'Ghana' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Gibraltar', DE_Name = 'Gibraltar' WHERE Code = 'GI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GI' , 'Gibraltar' , 'Gibraltar' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Greece', DE_Name = 'Griechenland' WHERE Code = 'GR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GR' , 'Greece' , 'Griechenland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GL') 
BEGIN 
UPDATE Countries SET EN_Name = 'Greenland', DE_Name = 'Grönland' WHERE Code = 'GL'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GL' , 'Greenland' , 'Grönland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GD') 
BEGIN 
UPDATE Countries SET EN_Name = 'Grenada', DE_Name = 'Grenada' WHERE Code = 'GD'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GD' , 'Grenada' , 'Grenada' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GP') 
BEGIN 
UPDATE Countries SET EN_Name = 'Guadeloupe', DE_Name = 'Guadeloupe' WHERE Code = 'GP'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GP' , 'Guadeloupe' , 'Guadeloupe' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GU') 
BEGIN 
UPDATE Countries SET EN_Name = 'Guam', DE_Name = 'Guam' WHERE Code = 'GU'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GU' , 'Guam' , 'Guam' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Guatemala', DE_Name = 'Guatemala' WHERE Code = 'GT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GT' , 'Guatemala' , 'Guatemala' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Guernsey', DE_Name = 'Guernsey' WHERE Code = 'GG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GG' , 'Guernsey' , 'Guernsey' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Guinea', DE_Name = 'Guinea' WHERE Code = 'GN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GN' , 'Guinea' , 'Guinea' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GW') 
BEGIN 
UPDATE Countries SET EN_Name = 'Guinea-Bissau', DE_Name = 'Guinea-Bissau' WHERE Code = 'GW'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GW' , 'Guinea-Bissau' , 'Guinea-Bissau' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GY') 
BEGIN 
UPDATE Countries SET EN_Name = 'Guyana', DE_Name = 'Guyana' WHERE Code = 'GY'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GY' , 'Guyana' , 'Guyana' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'HT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Haiti', DE_Name = 'Haiti' WHERE Code = 'HT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('HT' , 'Haiti' , 'Haiti' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'HM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Heard And Mc Donald Islands', DE_Name = 'Heard und McDonaldinseln' WHERE Code = 'HM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('HM' , 'Heard And Mc Donald Islands' , 'Heard und McDonaldinseln' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'VA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Holy See (Vatican City State)', DE_Name = 'Vatikanstadt' WHERE Code = 'VA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('VA' , 'Holy See (Vatican City State)' , 'Vatikanstadt' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'HN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Honduras', DE_Name = 'Honduras' WHERE Code = 'HN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('HN' , 'Honduras' , 'Honduras' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'HK') 
BEGIN 
UPDATE Countries SET EN_Name = 'Hong Kong', DE_Name = 'Hong Kong' WHERE Code = 'HK'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('HK' , 'Hong Kong' , 'Hong Kong' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'HU') 
BEGIN 
UPDATE Countries SET EN_Name = 'Hungary', DE_Name = 'Ungarn' WHERE Code = 'HU'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('HU' , 'Hungary' , 'Ungarn' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'IS') 
BEGIN 
UPDATE Countries SET EN_Name = 'Icel And', DE_Name = 'Island' WHERE Code = 'IS'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('IS' , 'Icel And' , 'Island' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'IN') 
BEGIN 
UPDATE Countries SET EN_Name = 'India', DE_Name = 'Indien' WHERE Code = 'IN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('IN' , 'India' , 'Indien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ID') 
BEGIN 
UPDATE Countries SET EN_Name = 'Indonesia', DE_Name = 'Indonesien' WHERE Code = 'ID'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ID' , 'Indonesia' , 'Indonesien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'IR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Islamic Republic Of Iran ', DE_Name = 'Iran' WHERE Code = 'IR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('IR' , 'Islamic Republic Of Iran ' , 'Iran' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'IQ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Iraq', DE_Name = 'Irak' WHERE Code = 'IQ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('IQ' , 'Iraq' , 'Irak' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'IE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Ireland', DE_Name = 'Irland' WHERE Code = 'IE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('IE' , 'Ireland' , 'Irland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'IM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Isle Of Man', DE_Name = 'Isle Of Man' WHERE Code = 'IM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('IM' , 'Isle Of Man' , 'Isle Of Man' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'IL') 
BEGIN 
UPDATE Countries SET EN_Name = 'Israel', DE_Name = 'Israel' WHERE Code = 'IL'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('IL' , 'Israel' , 'Israel' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'IT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Italy', DE_Name = 'Italien' WHERE Code = 'IT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('IT' , 'Italy' , 'Italien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'JM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Jamaica', DE_Name = 'Jamaika' WHERE Code = 'JM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('JM' , 'Jamaica' , 'Jamaika' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'JP') 
BEGIN 
UPDATE Countries SET EN_Name = 'Japan', DE_Name = 'Japan' WHERE Code = 'JP'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('JP' , 'Japan' , 'Japan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'JE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Jersey', DE_Name = 'Jersey' WHERE Code = 'JE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('JE' , 'Jersey' , 'Jersey' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'JO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Jordan', DE_Name = 'Jordanien' WHERE Code = 'JO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('JO' , 'Jordan' , 'Jordanien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Kazakhstan', DE_Name = 'Kasachstan' WHERE Code = 'KZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KZ' , 'Kazakhstan' , 'Kasachstan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Kenya', DE_Name = 'Kenia' WHERE Code = 'KE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KE' , 'Kenya' , 'Kenia' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Kiribati', DE_Name = 'Kiribati' WHERE Code = 'KI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KI' , 'Kiribati' , 'Kiribati' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KP') 
BEGIN 
UPDATE Countries SET EN_Name = 'North Korea', DE_Name = 'Nordkorea' WHERE Code = 'KP'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KP' , 'North Korea' , 'Nordkorea' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KR') 
BEGIN 
UPDATE Countries SET EN_Name = 'SouthKorea', DE_Name = 'Südkorea' WHERE Code = 'KR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KR' , 'SouthKorea' , 'Südkorea' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KW') 
BEGIN 
UPDATE Countries SET EN_Name = 'Kuwait', DE_Name = 'Kuwait' WHERE Code = 'KW'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KW' , 'Kuwait' , 'Kuwait' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Kyrgyzstan', DE_Name = 'Kirgisistan' WHERE Code = 'KG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KG' , 'Kyrgyzstan' , 'Kirgisistan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Lao Peoples Republic', DE_Name = 'Laos' WHERE Code = 'LA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LA' , 'Lao Peoples Republic' , 'Laos' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LV') 
BEGIN 
UPDATE Countries SET EN_Name = 'Latvia', DE_Name = 'Lettland' WHERE Code = 'LV'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LV' , 'Latvia' , 'Lettland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LB') 
BEGIN 
UPDATE Countries SET EN_Name = 'Lebanon', DE_Name = 'Libanon' WHERE Code = 'LB'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LB' , 'Lebanon' , 'Libanon' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LS') 
BEGIN 
UPDATE Countries SET EN_Name = 'Lesotho', DE_Name = 'Lesotho' WHERE Code = 'LS'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LS' , 'Lesotho' , 'Lesotho' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Liberia', DE_Name = 'Liberia' WHERE Code = 'LR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LR' , 'Liberia' , 'Liberia' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LY') 
BEGIN 
UPDATE Countries SET EN_Name = 'Libyan Arab Jamahiriya', DE_Name = 'Libyen' WHERE Code = 'LY'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LY' , 'Libyan Arab Jamahiriya' , 'Libyen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Liechtenstein', DE_Name = 'Liechtenstein' WHERE Code = 'LI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LI' , 'Liechtenstein' , 'Liechtenstein' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Lithuania', DE_Name = 'Litauen' WHERE Code = 'LT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LT' , 'Lithuania' , 'Litauen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LU') 
BEGIN 
UPDATE Countries SET EN_Name = 'Luxembourg', DE_Name = 'Luxemburg' WHERE Code = 'LU'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LU' , 'Luxembourg' , 'Luxemburg' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Macau', DE_Name = 'Macao' WHERE Code = 'MO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MO' , 'Macau' , 'Macao' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MK') 
BEGIN 
UPDATE Countries SET EN_Name = 'Macedonia', DE_Name = 'Mazedonien' WHERE Code = 'MK'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MK' , 'Macedonia' , 'Mazedonien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Madagascar', DE_Name = 'Madagaskar' WHERE Code = 'MG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MG' , 'Madagascar' , 'Madagaskar' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MW') 
BEGIN 
UPDATE Countries SET EN_Name = 'Malawi', DE_Name = 'Malawi' WHERE Code = 'MW'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MW' , 'Malawi' , 'Malawi' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MY') 
BEGIN 
UPDATE Countries SET EN_Name = 'Malaysia', DE_Name = 'Malaysia' WHERE Code = 'MY'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MY' , 'Malaysia' , 'Malaysia' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MV') 
BEGIN 
UPDATE Countries SET EN_Name = 'Maldives', DE_Name = 'Maldiven' WHERE Code = 'MV'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MV' , 'Maldives' , 'Maldiven' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ML') 
BEGIN 
UPDATE Countries SET EN_Name = 'Mali', DE_Name = 'Mali' WHERE Code = 'ML'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ML' , 'Mali' , 'Mali' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Malta', DE_Name = 'Malta' WHERE Code = 'MT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MT' , 'Malta' , 'Malta' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MH') 
BEGIN 
UPDATE Countries SET EN_Name = 'Marshall Islands', DE_Name = 'Marshallinseln' WHERE Code = 'MH'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MH' , 'Marshall Islands' , 'Marshallinseln' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MQ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Martinique', DE_Name = 'Martinique' WHERE Code = 'MQ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MQ' , 'Martinique' , 'Martinique' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Mauritania', DE_Name = 'Mauretanien' WHERE Code = 'MR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MR' , 'Mauritania' , 'Mauretanien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MU') 
BEGIN 
UPDATE Countries SET EN_Name = 'Mauritius', DE_Name = 'Mauritius' WHERE Code = 'MU'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MU' , 'Mauritius' , 'Mauritius' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'YT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Mayotte', DE_Name = 'Mayotte' WHERE Code = 'YT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('YT' , 'Mayotte' , 'Mayotte' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MX') 
BEGIN 
UPDATE Countries SET EN_Name = 'Mexico', DE_Name = 'Mexiko' WHERE Code = 'MX'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MX' , 'Mexico' , 'Mexiko' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'FM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Micronesia Federal State', DE_Name = 'Mikronesien' WHERE Code = 'FM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('FM' , 'Micronesia Federal State' , 'Mikronesien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MD') 
BEGIN 
UPDATE Countries SET EN_Name = 'Republic Of Moldova', DE_Name = 'Moldawien' WHERE Code = 'MD'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MD' , 'Republic Of Moldova' , 'Moldawien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MC') 
BEGIN 
UPDATE Countries SET EN_Name = 'Monaco', DE_Name = 'Monaco' WHERE Code = 'MC'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MC' , 'Monaco' , 'Monaco' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Mongolia', DE_Name = 'Mongolei' WHERE Code = 'MN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MN' , 'Mongolia' , 'Mongolei' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ME') 
BEGIN 
UPDATE Countries SET EN_Name = 'Montenegro', DE_Name = 'Montenegro' WHERE Code = 'ME'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ME' , 'Montenegro' , 'Montenegro' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MS') 
BEGIN 
UPDATE Countries SET EN_Name = 'Montserrat', DE_Name = 'Montserrat' WHERE Code = 'MS'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MS' , 'Montserrat' , 'Montserrat' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Morocco', DE_Name = 'Morokko' WHERE Code = 'MA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MA' , 'Morocco' , 'Morokko' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Mozambique', DE_Name = 'Mosambik' WHERE Code = 'MZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MZ' , 'Mozambique' , 'Mosambik' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Myanmar', DE_Name = 'Myanmar' WHERE Code = 'MM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MM' , 'Myanmar' , 'Myanmar' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Namibia', DE_Name = 'Namibia' WHERE Code = 'NA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NA' , 'Namibia' , 'Namibia' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Nauru', DE_Name = 'Nauru' WHERE Code = 'NR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NR' , 'Nauru' , 'Nauru' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NP') 
BEGIN 
UPDATE Countries SET EN_Name = 'Nepal', DE_Name = 'Nepal' WHERE Code = 'NP'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NP' , 'Nepal' , 'Nepal' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NL') 
BEGIN 
UPDATE Countries SET EN_Name = 'Netherlands', DE_Name = 'Niederlande' WHERE Code = 'NL'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NL' , 'Netherlands' , 'Niederlande' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Netherlands Ant Illes', DE_Name = 'Niederländische Antillen' WHERE Code = 'AN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AN' , 'Netherlands Ant Illes' , 'Niederländische Antillen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NC') 
BEGIN 
UPDATE Countries SET EN_Name = 'New Caledonia', DE_Name = 'Neukaledonien' WHERE Code = 'NC'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NC' , 'New Caledonia' , 'Neukaledonien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'New Zealand', DE_Name = 'Neuseeland' WHERE Code = 'NZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NZ' , 'New Zealand' , 'Neuseeland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Nicaragua', DE_Name = 'Nicaragua' WHERE Code = 'NI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NI' , 'Nicaragua' , 'Nicaragua' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Niger', DE_Name = 'Niger' WHERE Code = 'NE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NE' , 'Niger' , 'Niger' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Nigeria', DE_Name = 'Nigeria' WHERE Code = 'NG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NG' , 'Nigeria' , 'Nigeria' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NU') 
BEGIN 
UPDATE Countries SET EN_Name = 'Niue', DE_Name = 'Niue' WHERE Code = 'NU'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NU' , 'Niue' , 'Niue' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NF') 
BEGIN 
UPDATE Countries SET EN_Name = 'Norfolk Island', DE_Name = 'Norfolkinsel' WHERE Code = 'NF'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NF' , 'Norfolk Island' , 'Norfolkinsel' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MP') 
BEGIN 
UPDATE Countries SET EN_Name = 'Northern Mariana Islands', DE_Name = 'Nördliche Marianen' WHERE Code = 'MP'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MP' , 'Northern Mariana Islands' , 'Nördliche Marianen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'NO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Norway', DE_Name = 'Norwegen' WHERE Code = 'NO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('NO' , 'Norway' , 'Norwegen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'OM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Oman', DE_Name = 'Oman' WHERE Code = 'OM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('OM' , 'Oman' , 'Oman' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PK') 
BEGIN 
UPDATE Countries SET EN_Name = 'Pakistan', DE_Name = 'Pakistan' WHERE Code = 'PK'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PK' , 'Pakistan' , 'Pakistan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PW') 
BEGIN 
UPDATE Countries SET EN_Name = 'Palau', DE_Name = 'Palau' WHERE Code = 'PW'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PW' , 'Palau' , 'Palau' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PS') 
BEGIN 
UPDATE Countries SET EN_Name = 'Palestina', DE_Name = 'Palestina' WHERE Code = 'PS'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PS' , 'Palestina' , 'Palestina' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Panama', DE_Name = 'Panama' WHERE Code = 'PA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PA' , 'Panama' , 'Panama' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Papua New Guinea', DE_Name = 'Papua-Neuguinea' WHERE Code = 'PG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PG' , 'Papua New Guinea' , 'Papua-Neuguinea' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PY') 
BEGIN 
UPDATE Countries SET EN_Name = 'Paraguay', DE_Name = 'Paraguay' WHERE Code = 'PY'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PY' , 'Paraguay' , 'Paraguay' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Peru', DE_Name = 'Peru' WHERE Code = 'PE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PE' , 'Peru' , 'Peru' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PH') 
BEGIN 
UPDATE Countries SET EN_Name = 'Philippines', DE_Name = 'Philippinen' WHERE Code = 'PH'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PH' , 'Philippines' , 'Philippinen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Pitcairn', DE_Name = 'Pitcairninseln' WHERE Code = 'PN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PN' , 'Pitcairn' , 'Pitcairninseln' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PL') 
BEGIN 
UPDATE Countries SET EN_Name = 'Poland', DE_Name = 'Polen' WHERE Code = 'PL'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PL' , 'Poland' , 'Polen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Portugal', DE_Name = 'Portugal' WHERE Code = 'PT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PT' , 'Portugal' , 'Portugal' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Puerto Rico', DE_Name = 'Puerto Rico' WHERE Code = 'PR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PR' , 'Puerto Rico' , 'Puerto Rico' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'QA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Qatar', DE_Name = 'Qatar' WHERE Code = 'QA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('QA' , 'Qatar' , 'Qatar' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'RE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Reunion', DE_Name = 'Réunion' WHERE Code = 'RE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('RE' , 'Reunion' , 'Réunion' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'RO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Romania', DE_Name = 'Rumänien' WHERE Code = 'RO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('RO' , 'Romania' , 'Rumänien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'RU') 
BEGIN 
UPDATE Countries SET EN_Name = 'Russian Federation', DE_Name = 'Russland' WHERE Code = 'RU'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('RU' , 'Russian Federation' , 'Russland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'RW') 
BEGIN 
UPDATE Countries SET EN_Name = 'Rwanda', DE_Name = 'Ruanda' WHERE Code = 'RW'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('RW' , 'Rwanda' , 'Ruanda' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'KN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Saint K Itts And Nevis', DE_Name = 'St. Kitts/Nevis' WHERE Code = 'KN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('KN' , 'Saint K Itts And Nevis' , 'St. Kitts/Nevis' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LC') 
BEGIN 
UPDATE Countries SET EN_Name = 'Saint Lucia', DE_Name = 'St. Lucia' WHERE Code = 'LC'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LC' , 'Saint Lucia' , 'St. Lucia' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'VC') 
BEGIN 
UPDATE Countries SET EN_Name = 'Saint Vincent, The Grenadines', DE_Name = 'St. Vincent/Die Grenadinen' WHERE Code = 'VC'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('VC' , 'Saint Vincent, The Grenadines' , 'St. Vincent/Die Grenadinen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'WS') 
BEGIN 
UPDATE Countries SET EN_Name = 'Samoa', DE_Name = 'Samoa' WHERE Code = 'WS'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('WS' , 'Samoa' , 'Samoa' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SM') 
BEGIN 
UPDATE Countries SET EN_Name = 'San Marino', DE_Name = 'San Marino' WHERE Code = 'SM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SM' , 'San Marino' , 'San Marino' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ST') 
BEGIN 
UPDATE Countries SET EN_Name = 'Sao Tome And Principe', DE_Name = 'São Tomé/Príncipe' WHERE Code = 'ST'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ST' , 'Sao Tome And Principe' , 'São Tomé/Príncipe' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Saudi Arabia', DE_Name = 'Saudi-Arabien' WHERE Code = 'SA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SA' , 'Saudi Arabia' , 'Saudi-Arabien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Senegal', DE_Name = 'Senegal' WHERE Code = 'SN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SN' , 'Senegal' , 'Senegal' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'RS') 
BEGIN 
UPDATE Countries SET EN_Name = 'Serbien', DE_Name = 'Serbien' WHERE Code = 'RS'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('RS' , 'Serbien' , 'Serbien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SC') 
BEGIN 
UPDATE Countries SET EN_Name = 'Seychelles', DE_Name = 'Seychellen' WHERE Code = 'SC'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SC' , 'Seychelles' , 'Seychellen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SL') 
BEGIN 
UPDATE Countries SET EN_Name = 'Sierra Leone', DE_Name = 'Sierra Leone' WHERE Code = 'SL'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SL' , 'Sierra Leone' , 'Sierra Leone' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Singapore', DE_Name = 'Singapur' WHERE Code = 'SG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SG' , 'Singapore' , 'Singapur' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SK') 
BEGIN 
UPDATE Countries SET EN_Name = 'Slovakia (Slovak Republic)', DE_Name = 'Slowakische Republik' WHERE Code = 'SK'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SK' , 'Slovakia (Slovak Republic)' , 'Slowakische Republik' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Slovenia', DE_Name = 'Slowenien' WHERE Code = 'SI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SI' , 'Slovenia' , 'Slowenien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SB') 
BEGIN 
UPDATE Countries SET EN_Name = 'Solomon Islands', DE_Name = 'Salomonen' WHERE Code = 'SB'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SB' , 'Solomon Islands' , 'Salomonen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Somalia', DE_Name = 'Somalia' WHERE Code = 'SO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SO' , 'Somalia' , 'Somalia' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ZA') 
BEGIN 
UPDATE Countries SET EN_Name = 'South Africa', DE_Name = 'Südafrika' WHERE Code = 'ZA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ZA' , 'South Africa' , 'Südafrika' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GS') 
BEGIN 
UPDATE Countries SET EN_Name = 'South Georgia , S Sandwich Is.', DE_Name = 'Südgeorgien/Südlichen Sandwichinseln' WHERE Code = 'GS'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GS' , 'South Georgia , S Sandwich Is.' , 'Südgeorgien/Südlichen Sandwichinseln' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ES') 
BEGIN 
UPDATE Countries SET EN_Name = 'Spain', DE_Name = 'Spanien' WHERE Code = 'ES'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ES' , 'Spain' , 'Spanien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'LK') 
BEGIN 
UPDATE Countries SET EN_Name = 'Sri Lanka', DE_Name = 'Sri Lanka' WHERE Code = 'LK'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('LK' , 'Sri Lanka' , 'Sri Lanka' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'BL') 
BEGIN 
UPDATE Countries SET EN_Name = 'St. Barthelemy', DE_Name = 'St. Barthélemy' WHERE Code = 'BL'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('BL' , 'St. Barthelemy' , 'St. Barthélemy' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SH') 
BEGIN 
UPDATE Countries SET EN_Name = 'St. Helena', DE_Name = 'St. Helena' WHERE Code = 'SH'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SH' , 'St. Helena' , 'St. Helena' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'MF') 
BEGIN 
UPDATE Countries SET EN_Name = 'St. Martin', DE_Name = 'St. Martin' WHERE Code = 'MF'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('MF' , 'St. Martin' , 'St. Martin' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'PM') 
BEGIN 
UPDATE Countries SET EN_Name = 'St. Pierre And Miquelon', DE_Name = 'St. Pierre/Miquelon' WHERE Code = 'PM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('PM' , 'St. Pierre And Miquelon' , 'St. Pierre/Miquelon' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SD') 
BEGIN 
UPDATE Countries SET EN_Name = 'Sudan', DE_Name = 'Sudan' WHERE Code = 'SD'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SD' , 'Sudan' , 'Sudan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Suriname', DE_Name = 'Surinam' WHERE Code = 'SR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SR' , 'Suriname' , 'Surinam' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SJ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Svalbard, Jan Mayen Islands', DE_Name = 'Svalbard/Jan Mayen' WHERE Code = 'SJ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SJ' , 'Svalbard, Jan Mayen Islands' , 'Svalbard/Jan Mayen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Sw Aziland', DE_Name = 'Swasiland' WHERE Code = 'SZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SZ' , 'Sw Aziland' , 'Swasiland' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Sweden', DE_Name = 'Schweden' WHERE Code = 'SE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SE' , 'Sweden' , 'Schweden' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'CH') 
BEGIN 
UPDATE Countries SET EN_Name = 'Switzerland', DE_Name = 'Schweiz' WHERE Code = 'CH'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('CH' , 'Switzerland' , 'Schweiz' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'SY') 
BEGIN 
UPDATE Countries SET EN_Name = 'Syrian Arab Republic', DE_Name = 'Syrien' WHERE Code = 'SY'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('SY' , 'Syrian Arab Republic' , 'Syrien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TW') 
BEGIN 
UPDATE Countries SET EN_Name = 'Taiwan', DE_Name = 'Taiwan' WHERE Code = 'TW'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TW' , 'Taiwan' , 'Taiwan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TJ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Tajikistan', DE_Name = 'Tadschikistan' WHERE Code = 'TJ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TJ' , 'Tajikistan' , 'Tadschikistan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Tanzania, United Republic Of', DE_Name = 'Tansania' WHERE Code = 'TZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TZ' , 'Tanzania, United Republic Of' , 'Tansania' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TH') 
BEGIN 
UPDATE Countries SET EN_Name = 'Thailand', DE_Name = 'Thailand' WHERE Code = 'TH'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TH' , 'Thailand' , 'Thailand' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TL') 
BEGIN 
UPDATE Countries SET EN_Name = 'Timor-Leste', DE_Name = 'Timor-Leste' WHERE Code = 'TL'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TL' , 'Timor-Leste' , 'Timor-Leste' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Togo', DE_Name = 'Togo' WHERE Code = 'TG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TG' , 'Togo' , 'Togo' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TK') 
BEGIN 
UPDATE Countries SET EN_Name = 'Tokelau', DE_Name = 'Tokelau' WHERE Code = 'TK'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TK' , 'Tokelau' , 'Tokelau' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TO') 
BEGIN 
UPDATE Countries SET EN_Name = 'Tonga', DE_Name = 'Tonga' WHERE Code = 'TO'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TO' , 'Tonga' , 'Tonga' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TT') 
BEGIN 
UPDATE Countries SET EN_Name = 'Trinidad And Tobago', DE_Name = 'Trinidad und Tobago' WHERE Code = 'TT'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TT' , 'Trinidad And Tobago' , 'Trinidad und Tobago' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Tunisia', DE_Name = 'Tunisien' WHERE Code = 'TN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TN' , 'Tunisia' , 'Tunisien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Turkey', DE_Name = 'Türkei' WHERE Code = 'TR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TR' , 'Turkey' , 'Türkei' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Turkmenistan', DE_Name = 'Turkmenistan' WHERE Code = 'TM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TM' , 'Turkmenistan' , 'Turkmenistan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TC') 
BEGIN 
UPDATE Countries SET EN_Name = 'Turks And Caicos Islands', DE_Name = 'Turks- und Caicosinseln' WHERE Code = 'TC'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TC' , 'Turks And Caicos Islands' , 'Turks- und Caicosinseln' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'TV') 
BEGIN 
UPDATE Countries SET EN_Name = 'Tuvalu', DE_Name = 'Tuvalu' WHERE Code = 'TV'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('TV' , 'Tuvalu' , 'Tuvalu' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'UG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Uganda', DE_Name = 'Uganda' WHERE Code = 'UG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('UG' , 'Uganda' , 'Uganda' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'UA') 
BEGIN 
UPDATE Countries SET EN_Name = 'Ukraine', DE_Name = 'Ukraine' WHERE Code = 'UA'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('UA' , 'Ukraine' , 'Ukraine' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'AE') 
BEGIN 
UPDATE Countries SET EN_Name = 'United Arab Emirates', DE_Name = 'Vereinigte Arabische Emirate' WHERE Code = 'AE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('AE' , 'United Arab Emirates' , 'Vereinigte Arabische Emirate' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'GB') 
BEGIN 
UPDATE Countries SET EN_Name = 'United Kingdom', DE_Name = 'Großbritannien' WHERE Code = 'GB'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('GB' , 'United Kingdom' , 'Großbritannien' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'US') 
BEGIN 
UPDATE Countries SET EN_Name = 'United States', DE_Name = 'USA' WHERE Code = 'US'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('US' , 'United States' , 'USA' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'UM') 
BEGIN 
UPDATE Countries SET EN_Name = 'United States Minor Is.', DE_Name = 'United States Minor Islands' WHERE Code = 'UM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('UM' , 'United States Minor Is.' , 'United States Minor Islands' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'UY') 
BEGIN 
UPDATE Countries SET EN_Name = 'Uruguay', DE_Name = 'Uruguay' WHERE Code = 'UY'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('UY' , 'Uruguay' , 'Uruguay' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'UZ') 
BEGIN 
UPDATE Countries SET EN_Name = 'Uzbekistan', DE_Name = 'Usbekistan' WHERE Code = 'UZ'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('UZ' , 'Uzbekistan' , 'Usbekistan' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'VU') 
BEGIN 
UPDATE Countries SET EN_Name = 'Vanuatu', DE_Name = 'Vanuatu' WHERE Code = 'VU'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('VU' , 'Vanuatu' , 'Vanuatu' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'VE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Venezuela', DE_Name = 'Venezuela' WHERE Code = 'VE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('VE' , 'Venezuela' , 'Venezuela' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'VN') 
BEGIN 
UPDATE Countries SET EN_Name = 'Viet Nam', DE_Name = 'Vietnam' WHERE Code = 'VN'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('VN' , 'Viet Nam' , 'Vietnam' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'VG') 
BEGIN 
UPDATE Countries SET EN_Name = 'Virgin Islands (British)', DE_Name = 'Jungferninseln, Britische' WHERE Code = 'VG'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('VG' , 'Virgin Islands (British)' , 'Jungferninseln, Britische' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'VI') 
BEGIN 
UPDATE Countries SET EN_Name = 'Virgin Islands (U.S.)', DE_Name = 'Jungferninseln, Amerikanische' WHERE Code = 'VI'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('VI' , 'Virgin Islands (U.S.)' , 'Jungferninseln, Amerikanische' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'WF') 
BEGIN 
UPDATE Countries SET EN_Name = 'Wallis And Futuna Islands', DE_Name = 'Wallis/Futuna' WHERE Code = 'WF'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('WF' , 'Wallis And Futuna Islands' , 'Wallis/Futuna' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'EH') 
BEGIN 
UPDATE Countries SET EN_Name = 'Western Sahara', DE_Name = 'Westsahara' WHERE Code = 'EH'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('EH' , 'Western Sahara' , 'Westsahara' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'YE') 
BEGIN 
UPDATE Countries SET EN_Name = 'Yemen', DE_Name = 'Jemen' WHERE Code = 'YE'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('YE' , 'Yemen' , 'Jemen' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ZR') 
BEGIN 
UPDATE Countries SET EN_Name = 'Zaire', DE_Name = 'Zaire' WHERE Code = 'ZR'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ZR' , 'Zaire' , 'Zaire' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ZM') 
BEGIN 
UPDATE Countries SET EN_Name = 'Zambia', DE_Name  = 'Sambia' WHERE Code = 'ZM'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ZM' , 'Zambia' , 'Sambia' ) 
END 
GO 

IF EXISTS(SELECT * FROM Countries WHERE Code = 'ZW') 
BEGIN 
UPDATE Countries SET EN_Name = 'Zimbabwe', DE_Name = 'Simbabwe' WHERE Code = 'ZW'
END 
ELSE 
BEGIN 
INSERT INTO Countries (Code , EN_Name , DE_Name ) VALUES('ZW' , 'Zimbabwe' , 'Simbabwe' ) 
END 
GO 


