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



    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData){
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            keepData.CreatorId = userInfo.Id;
            Keep keep = _keepsService.CreateKeep(keepData);
            return Ok(keep);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Keep>> GetAllKeeps(){
        try
        {
            List<Keep> keep = _keepsService.GetAllKeeps();
            return Ok(keep);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
}