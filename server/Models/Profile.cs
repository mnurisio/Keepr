using System.ComponentModel.DataAnnotations;

namespace keepr.Models;

public class Profile : RepoItem<string>
{
    public string Name { get; set; }
    [Url] public string Picture { get; set; }
    [Url, MaxLength(1000)] public string CoverImg { get; set; }
}