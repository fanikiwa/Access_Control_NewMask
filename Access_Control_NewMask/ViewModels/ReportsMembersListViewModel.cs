using Access_Control_NewMask.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Access_Control_NewMask.ViewModels
{
    public class ReportsMembersListViewModel
    {
        public List<ReportsMembersListDto> GroupList(List<ReportsMembersListDto> members, string param)
        {
            switch (param)
            {
                case "A":
                    members = members.OrderBy(x => x.GroupName).ToList();
                    string currentGroupKey = string.Empty;
                    string currentKey = string.Empty;

                    foreach (var member in members)
                    {
                        currentKey = member.GroupName;

                        if (currentKey != currentGroupKey)
                        {
                            currentGroupKey = currentKey;

                        }
                        else
                        {
                            member.GroupName = string.Empty;
                        }
                    }

                    break;
                case "B":
                    members = members.OrderBy(x => x.MemberName).ToList();
                    //string currentNameKey = string.Empty;
                    //string currentKeyB = string.Empty;

                    //foreach (var member in members)
                    //{
                    //    currentKeyB = member.GroupName;

                    //    if (currentKeyB != currentNameKey)
                    //    {
                    //        currentNameKey = currentKeyB;

                    //    }
                    //    else
                    //    {
                    //        member.MemberName = string.Empty;
                    //    }
                    //}
                    break;
                case "C":
                    members = members.OrderBy(x => x.Place).ToList();
                    string currentPlaceKey = string.Empty;
                    string currentKeyC = string.Empty;

                    foreach (var member in members)
                    {
                        currentKeyC = member.GroupName;

                        if (currentKeyC != currentPlaceKey)
                        {
                            currentPlaceKey = currentKeyC;

                        }
                        else
                        {
                            member.Place = string.Empty;
                        }
                    }
                    break;
                case "D":
                    members = members.OrderBy(x => x.PostalCode).ToList();
                    string currentPostalCodeKey = string.Empty;
                    string currentKeyD = string.Empty;

                    foreach (var member in members)
                    {
                        currentKeyD = member.GroupName;

                        if (currentKeyD != currentPostalCodeKey)
                        {
                            currentPostalCodeKey = currentKeyD;

                        }
                        else
                        {
                            member.PostalCode = string.Empty;
                        }
                    }
                    break;
            }

            return members;
        }
        public List<ReportsMembersListDto> FilterMemberByPlace(List<ReportsMembersListDto> members, string From, string To)
        {
            List<ReportsMembersListDto> memberList = new List<ReportsMembersListDto>();
            var characters = CharactersBetween(From, To);
            foreach(var character in characters)
            {
                var currentList = members.Where(x => x.Place.StartsWith(character.ToString())).ToList();
                if(currentList.Count > 0)
                {
                    memberList.AddRange(currentList);
                }
                
            }

            return memberList;
        }
        public List<char> CharactersBetween(string stringFrom, string stringTo)
        {
           
            return Enumerable.Range(stringFrom[0], stringTo[0] - stringFrom[0] + 1).Select(c => (char)c).ToList();
        }
    }
}