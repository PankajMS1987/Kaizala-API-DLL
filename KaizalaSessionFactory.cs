namespace Microsoft.Kaizala
{
    using System;
    using System.Collections.Concurrent;

    /// <summary>
    /// Kaizala Session factory to get Kaizala Session
    /// </summary>
    public class KaizalaSessionFactory
    {
        private static ConcurrentDictionary<String, KaizalaSession> KaizalaSessionMap = new ConcurrentDictionary<string, KaizalaSession>();

        public static KaizalaSession GetKaizalaSession(string applicationId, string applicationSecret, string refreshToken) 
        {
            KaizalaSession session = null;
            if (!KaizalaSessionMap.TryGetValue(applicationId + applicationSecret, out session))
            { 
                session = new KaizalaSession(applicationId, applicationSecret, refreshToken);
                KaizalaSessionMap.TryAdd(applicationId + applicationSecret, session);
            }
            return session;
        }
    }
}
