using System.Data;
using BusinessObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using DataAccess.Repository;
namespace DataAccess
{
    public class MemberDAO : BaseDAL
    {
        //--------------------------------------------------------
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        //--------------------------------------------------------
        MemberRepository memberRepository = new MemberRepository();

        private bool checkAdminLogin(string email, string password)
        {
            bool checkAdminLogin = false;

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", true, true)
                .Build();

            String adminEmail = config["DefaultAccounts:Email"];
            String adminPassword = config["DefaultAccounts:Password"];
            checkAdminLogin = (email == adminEmail) && (password == adminPassword);

            return checkAdminLogin;
        }
        public MemberObject Login(string email, string password)
        {
            // CODE HERE
            MemberObject loginMember = null;
            if (checkAdminLogin(email, password) == false)
            {
                try
                {
                    IEnumerable<MemberObject> list = memberRepository.GetMemList();
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
                    City = string.Empty,
                    Country = string.Empty,
                };
            }
            return loginMember;
        }
        //--------------------------------------------------------
        public IEnumerable<MemberObject> GetMemList()
        {
            IDataReader dataReader = null;
            string SQLSelect = "Select MemberID, MemberName, Email, Password, City, Country form tblMember";
            var Mems = new List<MemberObject>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    Mems.Add(new MemberObject
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5),
                    });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return Mems;
        }
        //--------------------------------------------------------
        public MemberObject GetMemByID(int memID)
        {
            MemberObject mem = null;
            IDataReader dataReader = null;
            string SQLSelect = "Select MemberID, MemeberName, Email, Password, City, Country from tblMember where MemberID = @MemberID";
            try
            {
                var param = dataProvider.CreateParameter("@MemberID", 4, memID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    mem = new MemberObject
                    {
                        MemberID = dataReader.GetInt32(0),
                        MemberName = dataReader.GetString(1),
                        Email= dataReader.GetString(2),
                        Password= dataReader.GetString(3),
                        City= dataReader.GetString(4),
                        Country= dataReader.GetString(5)
                    };
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return mem;
        }
        //--------------------------------------------------------
        public void AddNew(MemberObject mem)
        {
            try
            {
                MemberObject pro = GetMemByID(mem.MemberID);
                if(pro == null)
                {
                    string SQLInsert = "Insert tblMember values(@MemberID, @MemberName, @Email, @Password, @City, @Country)";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MemberID", 4, mem.MemberID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberName", 50, mem.MemberName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@EMail", 50, mem.Email, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Password", 50, mem.Password, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@City", 50, mem.City, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Country", 50, mem.Country, DbType.String));
                }
                else
                {
                    throw new Exception("Member is already exist.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //--------------------------------------------------------
        public void Update(MemberObject mem)
        {
            try
            {
                MemberObject pro = GetMemByID(mem.MemberID);
                if (pro == null)
                {
                    string SQLUpdate = "Update tblMember set MemberName = @MemberName, Email = @Email, Password = @Password, City = @City, Country = @Country";
                    var parameters = new List<SqlParameter>();
                    parameters.Add(dataProvider.CreateParameter("@MemberID", 4, mem.MemberID, DbType.Int32));
                    parameters.Add(dataProvider.CreateParameter("@MemberName", 50, mem.MemberName, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@EMail", 50, mem.Email, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Password", 50, mem.Password, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@City", 50, mem.City, DbType.String));
                    parameters.Add(dataProvider.CreateParameter("@Country", 50, mem.Country, DbType.String));
                }
                else
                {
                    throw new Exception("Member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //--------------------------------------------------------
        public void Remove(int memID)
        {
            try
            {
                MemberObject mem = GetMemByID(memID);
                if(mem != null)
                {
                    string SQLDelete = "Delete Cars where MemberID = @MemberID";
                    var param = dataProvider.CreateParameter("@MemberID", 4, memID, DbType.Int32);
                    dataProvider.Delete(SQLDelete, CommandType.Text, param);
                }
                else
                {
                    throw new Exception("Member does not already exist.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }//end class
}//end namespace