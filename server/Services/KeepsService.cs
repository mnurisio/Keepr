


namespace keepr.Services;


public class KeepsService
{

    public KeepsService(KeepsRepository repository)
    {
        _repository = repository;
    }
    private readonly KeepsRepository _repository;

    internal Keep CreateKeep(Keep keepData)
    {
        Keep keep = _repository.CreateKeep(keepData);
        return keep;
    }


    public List<Keep> GetAllKeeps()
    {
        List<Keep> keeps = _repository.GetAllKeeps();
        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        Keep keep = _repository.GetKeepById(keepId);

        if(keep == null) throw new Exception ($"invalid keep ID of {keepId}");

        return keep;
    }
}