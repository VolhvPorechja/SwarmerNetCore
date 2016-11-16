using System;
using Newtonsoft.Json.Linq;
using Swarmer.Common.Models;

namespace Swarmer.TM.Contracts.Domain
{
	/// <summary>
	/// Model for tournament player.
	/// </summary>
	public class TournamentPlayer : SysObject
	{
		/// <summary>
		/// Id of tournament in which user participate.
		/// </summary>
		public Guid TournamentId { get; set; }

		/// <summary>
		/// Id of party in which user participate.
		/// </summary>
		public Guid? PartyId { get; set; }

		/// <summary>
		/// Id of player.
		/// </summary>
		public Guid PlayerId { get; set; }

		/// <summary>
		/// Id of team from which player participates.
		/// </summary>
		public Guid? TeamId { get; set; }

		/// <summary>
		/// Stats of player during tournament.
		/// </summary>
		public JObject Stats { get; set; }
	}
}