using InfoTrack.Core.Models;

namespace InfoTrack.Core.Interface
{
    public interface IProcessRequest
    {
        ProcessModelTrending Process(ProcessModel _params);
    }
}