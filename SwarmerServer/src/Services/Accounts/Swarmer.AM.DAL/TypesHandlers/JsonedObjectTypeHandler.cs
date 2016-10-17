using System.Data;
using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Swarmer.AM.DAL.TypesHandlers
{
    public class JsonedObjectTypeHandler<TType> : SqlMapper.TypeHandler<TType>
    {
        public override void SetValue(IDbDataParameter parameter, TType value)
        {
            parameter.Value = JObject.FromObject(value);
        }

        public override TType Parse(object value)
        {
            return JsonConvert.DeserializeObject<TType>(value.ToString());
        }
    }
}