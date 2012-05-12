namespace SMO.Core
{
    public interface IQueuingSystem
    {
        long CountRequestInSystem { get; }

        ISystemConfiguration Configuration { get; }

        int CountHandledRequest { get; }

        int Time { get; }

        bool AreRequests { get; }

        ISystemStatistics Statistics { get; }

        int CountRejectedRequests { get; }
        void OnRequestHandled(object sender, RequestEventArg e);

        void Reset();
    }
}