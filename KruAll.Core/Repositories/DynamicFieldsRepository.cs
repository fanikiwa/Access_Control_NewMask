using KruAll.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class DynamicFieldsRepository
    {
        PZE_Entities databaseConnection = null;

        public DynamicFieldsRepository()
        {
            databaseConnection = new PZE_Entities();
        }
        public void UpdateDynamicField(DynamicField dynamicField)
        {
            var existing = databaseConnection.DynamicFields.Where(x => x.FieldIndex == dynamicField.FieldIndex).FirstOrDefault();

            if (existing != null)
            {
                existing.FieldText = dynamicField.FieldText;
            }
            else
            {
                databaseConnection.DynamicFields.Add(dynamicField);
            }

            databaseConnection.SaveChanges();
        }

        public void UpdatepersonalDynamicField(Pers_DynamicFields personalDynamic)
        {
            var existing = databaseConnection.Pers_DynamicFields.Where(x => x.Pers_Nr == personalDynamic.Pers_Nr && x.FieldIndex == personalDynamic.FieldIndex).FirstOrDefault();

            if (existing != null)
            {
                existing.FieldValue = personalDynamic.FieldValue;
            }
            else
            {
                databaseConnection.Pers_DynamicFields.Add(personalDynamic);
            }

            databaseConnection.SaveChanges();
        }

        public List<DynamicField> GetDynamicFields()
        {
            return databaseConnection.DynamicFields.ToList();
        }

        public List<Pers_DynamicFields> PersonalDynamicFields(long personalNumber)
        {
            return databaseConnection.Pers_DynamicFields.Where(x => x.Pers_Nr == personalNumber).ToList();
        }
    }
}
