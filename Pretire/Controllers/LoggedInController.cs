using Pretire.Logic.Models;
using Pretire.Logic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pretire.Controllers
{
    public abstract class LoggedInController : Controller
    {
        public User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    _currentUser = _userLogic.LoadCurrentUser();
                }
                return _currentUser;
            }
        }

        public LoggedInController()
        {
            _userLogic = new UserLogic();
        }

        private User _currentUser;
        private UserLogic _userLogic;
    }
}