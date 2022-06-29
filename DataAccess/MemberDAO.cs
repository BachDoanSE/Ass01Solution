using System.Data;
using BusinessObject;
using Microsoft.Data.SqlClient;

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