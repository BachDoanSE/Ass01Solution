using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject;

public interface IMemberServices
{
    public MemberObject Login(String email, String password);
    public void CreateMember(MemberObject member);
    public void UpdateMember(MemberObject member);
    public void DeleteMember(int memberId);
    public MemberObject SearchMemberById(int memberId);
    public IEnumerable<MemberObject> SearchMemberByName(String name);
    public IEnumerable<MemberObject> FilterMemberByCity(String City);
    public IEnumerable<MemberObject> FilterMemberByCountry(String Country);
}
