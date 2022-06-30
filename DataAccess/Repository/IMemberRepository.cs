using BusinessObject;
using System.Collections;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMemByID(int memID);
        void InsertMem(MemberObject mem);
        void DeleteMem(int memID);
        void UpdateMem(MemberObject mem);
    }
}
