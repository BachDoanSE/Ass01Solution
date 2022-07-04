using BusinessObject;
using DataAccess;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public MemberObject GetMemByID(int memID) => MemberDAO.Instance.GetMemByID(memID);
        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetMemList();
        public void InsertMem(MemberObject mem) => MemberDAO.Instance.AddNew(mem);
        public void DeleteMem(int memID) => MemberDAO.Instance.Remove(memID);
        public void UpdateMem(MemberObject mem) => MemberDAO.Instance.Update(mem);
    }
}
