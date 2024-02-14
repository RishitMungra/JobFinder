using JobFinder.Areas.SEC_User.Models;
using JobFinder.DAL.SEC_User;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JobFinder.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[controller]/[action]")]
    public class SEC_UserController : Controller
    {
        SEC_UserDAL sEC_UserDAL = new SEC_UserDAL();
        #region SEC_UserSignIn
        public IActionResult SEC_UserSignIn()
        {
            return View();
        }
        #endregion

        #region SEC_UserSignUp
        public IActionResult SEC_UserSignUp()
        {
            return View();
        }
        #endregion

        #region Login
        [HttpPost]
        public IActionResult Login(SEC_UserModel sEC_UserModel)
        {
            if (sEC_UserModel.UserName == null)
            {
                TempData["UserNameError"] = "User Name is Required!";
            }
            if (sEC_UserModel.Password == null)
            {
                TempData["PasswordError"] = "Password is Required!";
            }

            if (TempData["UserNameError"] != null || TempData["PasswordError"] != null)
            {
                return RedirectToAction("SEC_UserSignIn", "SEC_User");
            }
            else
            {
                DataTable dataTable = sEC_UserDAL.SEC_User_SelectByUserNamePassword(sEC_UserModel.UserName, sEC_UserModel.Password);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        HttpContext.Session.SetString("UserID", dataRow["UserID"].ToString());
                        HttpContext.Session.SetString("UserName", dataRow["UserName"].ToString());
                        HttpContext.Session.SetString("Password", dataRow["Password"].ToString());
                        HttpContext.Session.SetString("FirstName", dataRow["FirstName"].ToString());
                        HttpContext.Session.SetString("LastName", dataRow["LastName"].ToString());
                        HttpContext.Session.SetString("EmailAddress", dataRow["EmailAddress"].ToString());
                        HttpContext.Session.SetString("isAdmin", dataRow["isAdmin"].ToString());
                        //HttpContext.Session.SetString("isActive", dataRow["isActive"].ToString());
                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "UserName or Password is invalid!";
                    return RedirectToAction("SEC_UserSignIn");
                }
                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null && HttpContext.Session.GetString("isAdmin") == "True")
                {
                    Console.WriteLine(HttpContext.Session.GetString("UserName"));
                    return RedirectToAction("SEC_AdminDashboard", "SEC_Admin", new { area = "SEC_Admin" });
                }
                else if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Register
        public IActionResult Register(SEC_UserModel sEC_UserModel)
        {

            if (sEC_UserModel.UserName == null)
            {
                TempData["UserNameError"] = "User Name is Required!";
            }
            if (sEC_UserModel.Password == null)
            {
                TempData["PasswordError"] = "Password is Required!";
            }
            if (sEC_UserModel.FirstName == null)
            {
                TempData["FirstNameError"] = "First  Name is Required!";
            }
            if (sEC_UserModel.LastName == null)
            {
                TempData["LastNameError"] = "Last Name is Required!";
            }
            if (sEC_UserModel.EmailAddress == null)
            {
                TempData["EmailAddressError"] = "Email Address is Required!";
            }

            if (TempData["UserNameError"] != null || TempData["PasswordError"] != null || TempData["FirstNameError"] != null || TempData["LastNameError"] != null || TempData["EmailAddressError"] != null)
            {
                return RedirectToAction("SEC_UserSignUp", "SEC_User");
            }
            else
            {
                bool IsSuccess = sEC_UserDAL.SEC_User_Register(sEC_UserModel.UserName, sEC_UserModel.Password, sEC_UserModel.FirstName, sEC_UserModel.LastName, sEC_UserModel.EmailAddress);
                if (IsSuccess)
                {
                    return RedirectToAction("SEC_UserSignIn");
                }
                else
                {
                    return RedirectToAction("SEC_UserSignUp");
                }
            }
        }
        #endregion
    }
}
