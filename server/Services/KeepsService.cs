


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

    internal Keep UpdateKeep(Keep keepData, string userId, int keepId)
    {
        Keep keep = GetKeepById(keepId);

        if(keep.CreatorId != userId) throw new Exception ("YOU CANNOT UPDATE ANOTHER PERSON'S KEEP");

        keep.Name = keepData.Name ?? keep.Name;
        keep.Description = keepData.Description ?? keep.Description;

        _repository.UpdateKeep(keep);

        return keep;

    }

    internal string DeleteKeep(int keepId, string userId)
    {
        Keep keep = GetKeepById(keepId);

        if(keep.CreatorId != userId) throw new Exception ("YOU CANNOT DELETE ANOTHER PERSON'S KEEP");

        _repository.DeleteKeep(keepId);

        return $"Deleted Keep name: {keep.Name}";

    }
}