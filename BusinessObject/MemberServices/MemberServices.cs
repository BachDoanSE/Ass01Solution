using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Extensions.Configuration;
using DataAccess.Repository;

namespace BusinessObject;

public class MemberServices : IMemberServices
{
    MemberRepository memberRepository = new MemberRepository();

    private bool checkAdminLogin(String email, String password)
    {
        bool checkAdminLogin = false;

        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("AppSettings.json", true, true)
            .Build();

        string adminEmail = config["DefaultAccounts:Email"];
        string adminPassword = config["DefaultAccounts:Password"];
        checkAdminLogin = (email == adminEmail) && (password == adminPassword);

        return checkAdminLogin;
    }

    public void CreateMember(MemberObject member)
    {
       
        memberRepository.InsertMem(member);
    }

    public void DeleteMember(int memberId)
    {
        
        memberRepository.DeleteMem(memberId);
    }

    public IEnumerable<MemberObject> FilterMemberByCity(String City)
    {
      
        IEnumerable<MemberObject> list = memberRepository.GetMembers();
        IEnumerable<MemberObject> result = from member in list
                                     where member.City.Contains(City)
                                     select member;
        return result;
    }

    public IEnumerable<MemberObject> FilterMemberByCountry(String Country)
    {
      
        IEnumerable<MemberObject> list = memberRepository.GetMembers();
        IEnumerable<MemberObject> result = from member in list
                                     where member.Country.Contains(Country)
                                     select member;
        return result;
    }

    public MemberObject Login(String email, String password)
    {
        
        MemberObject loginMember = null;
        if (checkAdminLogin(email, password) == false)
        {
            try
            {
                IEnumerable<MemberObject> list = memberRepository.GetMembers();
                loginMember = (from member in list
                               where (member.Email == email)
                               && (member.Password == password)
                               select member).First();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("no elements"))
                {
                    throw new Exception("Incorrect Username or Password!");
                }
            }

        }
        else
        {
            loginMember = new MemberObject
            {
                MemberID = 0,
                MemberName = "Admin",
                Email = email,
                Password = password,
                City = String.Empty,
                Country = String.Empty,
            };
        }
        return loginMember;
    }

    public MemberObject SearchMemberById(int memberId)
    {
        
        return memberRepository.GetMemByID(memberId);
    }

    public IEnumerable<MemberObject> SearchMemberByName(String name)
    {
        // CODE HERE
        IEnumerable<MemberObject> list = memberRepository.GetMembers();
        IEnumerable<MemberObject> result = from member in list
                                     where member.MemberName.Contains(name)
                                     select member;
        return result;
    }

    public void UpdateMember(MemberObject member)
    {
        // CODE HERE
        memberRepository.UpdateMem(member);
    }

    public IEnumerable<MemberObject> GetMemberList()
    {
        return memberRepository.GetMembers();
    }
}
