using System.Data.SqlClient;

namespace EtutOtomasyon
{
    class Database
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\sqlexpress; Initial Catalog=EtutOtomasyon;Integrated Security=True");

    }
}
