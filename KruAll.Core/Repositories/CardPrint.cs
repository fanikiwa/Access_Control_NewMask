using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity.Infrastructure.Design;
using System.Collections.Specialized;
using System.Data;
using KruAll.Core.Models;

namespace KruAll.Core.Repositories
{
    public class CardPrint
    {
        public long PersNr { get; set; }
        public string Client { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExpireDate { get; set; }
        public string PersType { get; set; }
        public string PicturePath { get; set; }

        public CardPrint getCardPrint(long PersNr, ref DataTable ds, string imagePath, int Passtype)
        {


            StringBuilder sb = new StringBuilder();
            //Langzeitausweis
            //if (Passtype == 1)
            //{
            sb.Append("select \n");
            sb.Append("Pers_Nr as PersNr\n");
            sb.Append(",ISNULL((SELECT C.Name FROM Clients C INNER JOIN Pers_Client PC ON C.Id = PC.ClientID WHERE Pers_Nr = Personal.Pers_Nr),'') as Client \n");
            sb.Append(",FirstName\n");
            sb.Append(",LastName\n");
            sb.Append(",ISNULL(CONVERT(VARCHAR(10),ExitDate,104),'') as ExpireDate \n");
            sb.Append(",PersType as PersType ");
            sb.Append(",'");
            sb.Append(imagePath);
            sb.Append(@"\' + FirstName + CONVERT(Varchar(500),Pers_Nr) + '.png' as ImagePath ");
            sb.Append("FROM Personal \n");
            sb.Append("Where Pers_Nr = " + PersNr);
            //}
            //Tagesausweis
            //else if (Passtype == 2)
            //{
            //    sb.Append("select \n");
            //    sb.Append("Pers_Nr as PersNr\n");
            //    sb.Append(",ISNULL((SELECT C.Name FROM Clients C INNER JOIN Pers_Client PC ON C.Client_Nr = PC.Client_Nr WHERE Pers_Nr = 1),'') as Client \n");
            //    sb.Append(",FirstName\n");
            //    sb.Append(",LastName\n");
            //    sb.Append(",ISNULL(CONVERT(VARCHAR(10),ExitDate,104),'') as ExpireDate \n");
            //    sb.Append(",'red' as Type\n");
            //    sb.Append(",'");
            //    sb.Append(imagePath);
            //    sb.Append(@"\' + FirstName + CONVERT(Varchar(500),Pers_Nr) + '.png' as ImagePath ");
            //    sb.Append("FROM Personal \n");
            //    sb.Append("Where Pers_Nr = " + PersNr);
            //}


            var conString = new PZE_Entities().Database.Connection.ConnectionString;
            var cp = new CardPrint();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
                {
                    ds.Load(command.ExecuteReader());
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            cp = new CardPrint()
                            {
                                PersNr = Convert.ToInt32(reader["PersNr"]),
                                Client = Convert.ToString(reader["Client"]),
                                FirstName = Convert.ToString(reader["FirstName"]),
                                LastName = Convert.ToString(reader["LastName"]),
                                ExpireDate = Convert.ToString(reader["ExpireDate"]),
                                PersType = Convert.ToString(reader["PersType"]),
                                PicturePath = Convert.ToString(reader["ImagePath"]),
                            };
                            //Client = Convert.ToString(reader["Client"]),



                        }
                    }
                }
            }
            return cp;
        }

        public List<CardPrint> Dataset()
        {
            return new List<CardPrint>();
        }
    }
}
