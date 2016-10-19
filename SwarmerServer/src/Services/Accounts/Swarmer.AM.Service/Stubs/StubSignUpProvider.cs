using System;
using System.Collections.Generic;
using Swarmer.AM.Contracts.Providers;
using Swarmer.AM.Contracts.Providers.Contracts;

namespace Swarmer.AM.Service.Stubs
{
    /// <summary>
    /// Stub realization of SignUpActivationProviderContract.
    /// </summary>
    public class StubSignUpProvider : SignUpActivationProviderContract
    {
        private readonly Dictionary<string, SignUpData> mStorage = new Dictionary<string, SignUpData>();

        public string StoreSignUpData(SignUpData data)
        {
            var newKey = Guid.NewGuid().ToString("n");
            mStorage.Add(newKey, data);
            return newKey;
        }

        public SignUpData GetSignUpData(string key)
        {
            return mStorage.ContainsKey(key) ? mStorage[key] : null;
        }
    }
}