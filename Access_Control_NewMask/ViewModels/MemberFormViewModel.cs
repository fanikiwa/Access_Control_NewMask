using Access_Control_NewMask.Dtos;
using KruAll.Core.Models;
using KruAll.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class MemberFormViewModel
    {
        public void UpdateMemberDynamicFields(List<MemberDynamicFieldDto> memberDynamicFields)
        {
            DynamicFieldsMemberRepository dynamicFieldRepo = new DynamicFieldsMemberRepository();
            DynamicFieldsMember dynamicField = null;
            MemberDynamicField persDynamicField = null;

            foreach (MemberDynamicFieldDto memberDynamicField in memberDynamicFields)
            {
                dynamicField = new DynamicFieldsMember();
                dynamicField.FieldIndex = memberDynamicField.FieldIndex;
                dynamicField.FieldText = memberDynamicField.FieldText;
                dynamicFieldRepo.UpdateDynamicField(dynamicField);

                persDynamicField = new MemberDynamicField();
                persDynamicField.FieldIndex = memberDynamicField.FieldIndex;
                persDynamicField.MemberID = memberDynamicField.MemberID;
                persDynamicField.FieldValue = memberDynamicField.FieldValue;
                dynamicFieldRepo.UpdateMemberDynamicField(persDynamicField);
            }
        }
        public List<MemberDynamicFieldDto> GetMemberDynamicFields(long memberId)
        {
            List<MemberDynamicFieldDto> memberDynamicFields = new List<MemberDynamicFieldDto>();
            MemberDynamicFieldDto memberDynamicField = null;
            DynamicFieldsMemberRepository dynamicFieldRepo = new DynamicFieldsMemberRepository();

            var mebDynamicFields = dynamicFieldRepo.MemberDynamicFields(memberId);


            if (mebDynamicFields.Count == 0)
            {
                var dynamicFields = dynamicFieldRepo.GetDynamicFields().ToList();

                foreach (DynamicFieldsMember dynamicField in dynamicFields)
                {
                    memberDynamicField = new MemberDynamicFieldDto();
                    memberDynamicField.FieldIndex = Convert.ToInt32(dynamicField.FieldIndex);
                    memberDynamicField.MemberID = memberId;
                    memberDynamicField.FieldValue = "";
                    memberDynamicField.FieldText = dynamicField.FieldText;
                    memberDynamicFields.Add(memberDynamicField);
                }
            }
            foreach (var mebDynamicField in mebDynamicFields)
            {
                memberDynamicField = new MemberDynamicFieldDto();
                memberDynamicField.FieldIndex = Convert.ToInt32(mebDynamicField.FieldIndex);
                memberDynamicField.MemberID = Convert.ToInt64(mebDynamicField.MemberID);
                memberDynamicField.FieldValue = mebDynamicField.FieldValue;

                var dynamicField = dynamicFieldRepo.GetDynamicFields().Where(x => x.FieldIndex == memberDynamicField.FieldIndex).FirstOrDefault();

                if (dynamicField != null)
                {
                    memberDynamicField.FieldText = dynamicField.FieldText;
                }

                memberDynamicFields.Add(memberDynamicField);
            }


            return memberDynamicFields;
        }
    }
}