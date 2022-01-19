using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliKemal
{
    public class Baglanti : IDisposable
    {
        public SqlConnection sqlBaglanti { get; set; }
        public SqlCommand SqlKomut { get; set; }

        private Dictionary<string, object> parametreler;
        public Dictionary<string, object> Parametreler
        {
            get { return parametreler; }
            set { parametreler = value; }
        }

        public Baglanti()
        {
            string ConString = "Server=(LocalDB)\\MSSQLLocalDB;Database=Test;Trusted_Connection=False;Connection Timeout=30;";
            sqlBaglanti = new SqlConnection { ConnectionString = ConString };
            parametreler = new Dictionary<string, object>();
            sqlBaglanti.Open();
            SqlKomut = new SqlCommand();
            SqlKomut.Connection = sqlBaglanti;
        }

        public void ParametreEkle(string ad, object ob)
        {
            if (parametreler.ContainsKey(ad)) // zaten varsa
            {
                parametreler[ad] = ob;
            }
            else
            {
                parametreler.Add(ad, ob);
            }
        }


        private SqlParameter[] GetirParametreDizisi()
        {
            SqlParameter[] sqlpd = new SqlParameter[parametreler.Count];

            int i = 0;
            foreach (KeyValuePair<string, object> nv in parametreler)
            {
                if (nv.Key.Contains("OO@"))
                {
                    SqlParameter sp = new SqlParameter(nv.Key.Replace("OO@", "@"), nv.Value);
                    sp.Direction = ParameterDirection.Output;
                    sqlpd[i] = sp;
                }
                else if (nv.Key.Contains("OU@"))
                {
                    SqlParameter sp = new SqlParameter(nv.Key.Replace("OU@", "@"), nv.Value);
                    sp.Direction = ParameterDirection.InputOutput;
                    sqlpd[i] = sp;
                }
                else if (nv.Key.Contains("RT@"))
                {
                    SqlParameter sp = new SqlParameter(nv.Key.Replace("RT@", "@"), nv.Value);
                    sp.Direction = ParameterDirection.ReturnValue;
                    sqlpd[i] = sp;
                }
                else
                {
                    sqlpd[i] = new SqlParameter(nv.Key, nv.Value);
                }
                i++;
            }

            return sqlpd;
        }

        public DataSet SorguGetir(string spName)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlDataAdapter da = new SqlDataAdapter(spName, sqlBaglanti))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.CommandTimeout = 9999;
                    da.SelectCommand.Parameters.AddRange(GetirParametreDizisi());
                    da.Fill(ds);
                }
                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataSet SorguGetir(string command, CommandType typ)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlDataAdapter da = new SqlDataAdapter(command, sqlBaglanti))
                {
                    da.SelectCommand.CommandType = typ;
                    da.SelectCommand.CommandTimeout = 9999;
                    da.SelectCommand.Parameters.AddRange(GetirParametreDizisi());
                    da.Fill(ds);
                }
                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public object TekSonucGetir(string spName)
        {
            object ob = new object();
            SqlKomut = new SqlCommand(spName, sqlBaglanti);
            SqlKomut.CommandType = CommandType.StoredProcedure;
            SqlKomut.Parameters.AddRange(GetirParametreDizisi());
            ob = SqlKomut.ExecuteScalar();
            return ob;
        }

        public void Dispose()
        {
            sqlBaglanti.Close();
            if (sqlBaglanti != null)
            {
                sqlBaglanti.Dispose();
                sqlBaglanti = null;
            }

            if (SqlKomut != null)
            {
                SqlKomut.Dispose();
                SqlKomut = null;
            }
        }
    }
}
