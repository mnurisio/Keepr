using System.ComponentModel.DataAnnotations;

namespace keepr.Models;

public class Keeps : RepoItem<int>
{
public string Name { get; set; }
[MaxLength(1000)] public string Description { get; set; }
[Url, MaxLength(1000)] public string Img { get; set; }
public int Views { get; set; }
public string CreatorId { get; set; }
public Profile Creator { get; set; }
}