using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using IBatisNet.DataMapper;

namespace FMY.WEB.IbatisDao
{
    public class Mapper
    {

        public static string MapperDomain = "FMY.WEB.IbatisDao";

        private static volatile ISqlMapper _mapper;

        public static ISqlMapper GetInstance()
        {
            if (_mapper == null)
            {
                lock (typeof(ISqlMapper))
                {
                    if (_mapper == null)
                        _mapper = InitMapper();
                }
            }
            return _mapper;
        }

        private static ISqlMapper InitMapper()
        {
            //SqlMapSession sesstion= 
            IBatisNet.DataMapper.Configuration.DomSqlMapBuilder builder = new IBatisNet.DataMapper.Configuration.DomSqlMapBuilder();
            Assembly assembly = Assembly.GetAssembly(typeof(Mapper));
            string resouce = string.Format("{0}.{1}", MapperDomain, "SqlMap.config");
            using (Stream stream = assembly.GetManifestResourceStream(resouce))
            {
                try
                {
                    return builder.Configure(stream);
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }


        /// <summary>
        /// 得到运行时的IbatisNet动态生成的SQL语句
        /// </summary>
        /// <param name="sqlMapper">获取关联SqlMapper对象</param>
        /// <param name="statementName">xml中节点名称</param>
        /// <param name="paramObject">xml中节点的参数</param>
        /// <returns>生成的Sql语句或者错误</returns>
        public static string GetSql(string statementName, object paramObject)
        {
            try
            {
                IBatisNet.DataMapper.MappedStatements.IMappedStatement statement = Mapper.GetInstance().GetMappedStatement(statementName);
                if (!Mapper.GetInstance().IsSessionStarted)
                {
                    Mapper.GetInstance().OpenConnection();
                }
                IBatisNet.DataMapper.Scope.RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, Mapper.GetInstance().LocalSession);
                statement.PreparedCommand.Create(scope, Mapper.GetInstance().LocalSession, statement.Statement, paramObject);
                System.Text.StringBuilder sbSql = new System.Text.StringBuilder();

                System.Func<string, string> fn = (type) =>
                {
                    switch (type)
                    {
                        case "Int32":
                            return "Int";
                        case "String":
                        default:
                            return "Varchar(100)";
                    }
                };

                foreach (System.Data.IDataParameter pa in scope.IDbCommand.Parameters)
                {
                    if (pa.DbType == System.Data.DbType.Int32)
                    {
                        sbSql.AppendFormat("DECLARE {0} {1}  SET {0}={2} ", pa.ParameterName, fn(pa.DbType.ToString()), pa.Value);
                    }
                    else
                    {
                        sbSql.AppendFormat("DECLARE {0} {1}  SET {0}='{2}' ", pa.ParameterName, fn(pa.DbType.ToString()), pa.Value);
                    }
                }
                sbSql.Append(scope.PreparedStatement.PreparedSql);
                return sbSql.ToString();
            }
            catch (System.Exception ex)
            {
                return "获取SQL语句出现异常：" + ex.Message;
            }
        }
    }
}
