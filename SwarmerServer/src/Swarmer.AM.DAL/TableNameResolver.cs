using System;
using System.Collections.Generic;
using Dommel;
using Swarmer.AM.Contracts.Domain;

namespace Swarmer.AM.DAL
{
    public class TableNameResolver : DommelMapper.ITableNameResolver
    {
        private static readonly Dictionary<Type,string> Map = new Dictionary<Type, string>
        {
            { typeof(User), "User" },
            { typeof(Team), "Teams" },
            { typeof(TeamMembership), "TeamsMembership" }
        };

        public string ResolveTableName(Type type)
        {
            return Map[type];
        }
    }
}