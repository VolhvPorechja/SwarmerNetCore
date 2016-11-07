using Dapper;
using Swarmer.TM.DAL.DTO;

namespace Swarmer.TM.DAL
{
    public class TournamentsDAL
    {
        public static void Init()
        {
            SqlMapper.AddTypeHandler(new TournamentDataHandler());
        }
    }
}