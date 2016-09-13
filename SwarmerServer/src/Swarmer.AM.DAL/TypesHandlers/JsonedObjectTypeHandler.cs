using System.Data;
using Dapper;
using Newtonsoft.Json;

namespace Swarmer.AM.DAL.TypesHandlers
{
    public class JsonedObjectTypeHandler<TType> : SqlMapper.TypeHandler<TType>
    {
        public override void SetValue(IDbDataParameter parameter, TType value)
        {
            parameter.Value = JsonConvert.SerializeObject(value);
            parameter.DbType = DbType.String;
        }

        public override TType Parse(object value)
        {
            return JsonConvert.DeserializeObject<TType>(value.ToString());
        }
    }
}