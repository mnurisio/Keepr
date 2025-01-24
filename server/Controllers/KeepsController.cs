namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase{

    public KeepsController(KeepsService keepsService, Auth0Provider auth0Provider)
    {
        _keepsService = keepsService;
        _auth0Provider = auth0Provider;
    }
    private readonly KeepsService _keepsService;
    private readonly Auth0Provider _auth0Provider;
}