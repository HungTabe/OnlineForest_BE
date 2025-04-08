using Microsoft.AspNetCore.Mvc;
using OnlineForestAPI.Interfaces;

namespace OnlineForestAPI.Controllers
{
    [Route("api/tree")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _treeService;

        public TreeController(ITreeService treeService)
        {
            _treeService = treeService;
        }
    }
}
