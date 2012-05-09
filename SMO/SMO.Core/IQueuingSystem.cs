namespace SMO.Core
{
    public interface IQueuingSystem
    {
        long CountRequestInSystem { get; }

        ISystemDevices Devices { get; }

        int CountHandledRequest { get; }

        int Time { get; }

        bool AreRequests { get; }

        ISystemGenerator Generator { get; }

        ISystemStatistics Statistics { get; }

        IDisciplineQueuingSystem Discipline { get; }

        int CountRejectedRequests { get; }
        void OnRequestHandled(object sender, RequestEventArg e);

        void Reset();
    }
}