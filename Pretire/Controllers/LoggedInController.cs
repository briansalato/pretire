using Pretire.Logic.Models;
using Pretire.Logic.Users;
using Pretire.Logic.Users.Managers;
using Pretire.Logic.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Pretire.Controllers
{
    public abstract class LoggedInController : Controller
    {
        private int? _userId;
        private int UserId
        {
            get
            {
                if (!_userId.HasValue)
                {
                    var idClaim = (User.Identity as ClaimsIdentity).Claims.FirstOrDefault(claim => claim.Type == "userId");
                    if (idClaim != null)
                    {
                        _userId = int.Parse(idClaim.Value);
                    }
                }
                return _userId.Value;
            }
        }

        private int? _currentSimulationId;
        public int CurrentSimulationId
        {
            get
            {
                if (!_currentSimulationId.HasValue)
                {
                    var idClaim = (User.Identity as ClaimsIdentity).Claims.FirstOrDefault(claim => claim.Type == "simulationId");
                    if (idClaim != null)
                    {
                        _currentSimulationId = int.Parse(idClaim.Value);
                    }
                }
                return  _currentSimulationId.Value;
            }
        }

        public LoggedInController()
        {
            _simulationManager = new SimulationManager();
        }

        private User _currentUser;
        private SimulationManager _simulationManager;
    }
}