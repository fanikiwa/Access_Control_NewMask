using KruAll.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class DynamicFieldsMemberRepository
    {
        PZE_Entities databaseConnection = null;

        public DynamicFieldsMemberRepository()
        {
            databaseConnection = new PZE_Entities();
        }
        public void UpdateDynamicField(DynamicFieldsMember dynamicField)
        {
            var existing = databaseConnection.DynamicFieldsMembers.Where(x => x.FieldIndex == dynamicField.FieldIndex).FirstOrDefault();

            if (existing != null)
            {
                existing.FieldText = dynamicField.FieldText;
            }
            else
            {
                databaseConnection.DynamicFieldsMembers.Add(dynamicField);
            }

            databaseConnection.SaveChanges();
        }

        public void UpdateMemberDynamicField(MemberDynamicField memberDynamic)
        {
            var existing = databaseConnection.MemberDynamicFields.Where(x => x.MemberID == memberDynamic.MemberID && x.FieldIndex == memberDynamic.FieldIndex).FirstOrDefault();

            if (existing != null)
            {
                existing.FieldValue = memberDynamic.FieldValue;
            }
            else
            {
                databaseConnection.MemberDynamicFields.Add(memberDynamic);
            }

            databaseConnection.SaveChanges();
        }

        public List<DynamicFieldsMember> GetDynamicFields()
        {
            return databaseConnection.DynamicFieldsMembers.ToList();
        }

        public List<MemberDynamicField> MemberDynamicFields(long memberNumber)
        {
            return databaseConnection.MemberDynamicFields.Where(x => x.MemberID == memberNumber).ToList();
        }
        
    }
}
