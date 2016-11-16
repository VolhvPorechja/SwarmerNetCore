namespace Swarmer.TM.Contracts.Providers
{
	/// <summary>
	/// Contract for user data provider.
	/// </summary>
	public interface UserDataProviderContract
	{
		/// <summary>
		/// Get user data by path.
		/// </summary>
		/// <param name="path">Path to data.</param>
		/// <typeparam name="TData">Type of data.</typeparam>
		/// <returns></returns>
		TData GetUserData<TData>(string path);
	}
}