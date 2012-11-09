using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcTesting.Models;
using System.Data.Entity;
using System.Web.SessionState;
using Telerik.Web.Mvc;
using System.Threading;
using System.Net.Mail;



namespace mvcTesting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Display()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult About(mvcTestingModel mvcModel)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcModel.Result = mvcDB.validateUser(mvcModel.UserName, mvcModel.Password);
            if (mvcModel.Result == 1)
            {
                ViewData["Result"] = "true";
                Session["Adminlogin"] = "";
                Session["login"] = mvcModel.UserName;
                return View(mvcModel);
            }
            else
            {
                ViewData["Result"] = "false";
                Session["login"] = "";
                return View(mvcModel);
            }
        }
        public ActionResult About()
        {
            Session["Adminlogin"] = "";
            Session.Remove("login");
            return View();
        }
        public ActionResult Search()
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcTestingModel mvcModel = new mvcTestingModel();
            mvcModel.Category = mvcDB.getDropDownForSearch();
            return View(mvcModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult Search(string Search, mvcTestingModel mvcModel, string Category)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            if (Search == "Search1")
            {
                mvcModel.Category = mvcDB.getDropDownForSearch();
                mvcModel.SearchBooksList = mvcDB.SearchAllBooks(mvcModel.SearchBooks.BookNameInput, mvcModel.SearchBooks.BookISBNInput, mvcModel.SearchBooks.AuthorNameInput, Category);
            }
            else
            {
                ViewData["SearchLoginFailed"] = "false";
            }
            return View(mvcModel);
        }
        public ActionResult Register(string unknown)
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(mvcTestingModel mvcModel)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcModel.RegResult = mvcDB.InsertNewUser(mvcModel.RegName, mvcModel.RegUserName, mvcModel.RegPassword, mvcModel.RegConfirmPassword, mvcModel.RegEMail, mvcModel.RegAddress, mvcModel.RegPhone, mvcModel.RegCompany);
            if (mvcModel.RegResult == 0)
            {
                Thread.Sleep(10000);
                ViewData["RegResponse"] = "true";
            }
            else
            {
                ViewData["RegResponse"] = "false";
            }
            return View(mvcModel);
        }
        [HttpGet]
        public ActionResult Admin()
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcTestingModel mvcModel = new mvcTestingModel();
            //Session["login"] = "";
            Session.Remove("login");
            Session.Remove("Adminlogin");
            mvcModel.adminDropDown = mvcDB.getAdminDropDownList();
            return View(mvcModel);
        }
        static int count = 0;
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Admin(mvcTestingModel mvcModel, string adminDropDown)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcModel.AdminResult = mvcDB.ValidateAdmin(mvcModel.AdminName, mvcModel.AdminPassword, mvcModel.AdminCode, adminDropDown);
            if (mvcModel.AdminResult == 0)
            {
                //Session["login"] = "";
                Session["adminDropDown"] = adminDropDown;
                Session["Adminlogin"] = mvcModel.AdminName;
                ViewData["admin"] = "true";
            }
            else
            {
                count = count + 1;
                if (count >= 3)
                {
                    ViewData["Locked"] = count;
                }
                Session["Adminlogin"] = " ";
                ViewData["admin"] = "false";
            }
            return View(mvcModel);
        }
        public ActionResult AddNewAdmin()
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcTestingModel mvcModel = new mvcTestingModel();
            string AdminLogin = Session["Adminlogin"].ToString();
            if (AdminLogin != "")
            {
                mvcModel.NewAdCategory = mvcDB.getAdminDropDownList();
            }
            else
            {
                return RedirectToAction("ErrorPage");
            }
            return View(mvcModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddNewAdmin(mvcTestingModel mvcModel, string NewAdCategory)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            string AdminLogin = Session["Adminlogin"].ToString();
            if (AdminLogin != "")
            {
                string AdminDropdown = Session["adminDropDown"].ToString();
                if ((AdminDropdown != "Support") && (AdminDropdown != "Admin"))
                {
                    mvcModel.NewAdResult = mvcDB.InsertNewAdmin(mvcModel.NewAdName, mvcModel.NewAdPass, mvcModel.NewAdPhone, mvcModel.NewAdAddress, mvcModel.NewAdDesign, NewAdCategory);
                    if (mvcModel.NewAdResult != -1)
                    {
                        ViewBag.Value = mvcModel.NewAdResult;
                        ViewData["newadmin"] = "true";
                    }
                    else
                    {
                        ViewData["newadmin"] = "false";
                    }
                }
                else
                {
                    ViewData["newadmin"] = "false1";
                }
            }
            else
            {
                return RedirectToAction("ErrorPage");
            }
            return View(mvcModel);
        }
        public ActionResult AdminWork()
        {
            if (Session["Adminlogin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("ErrorPage");
            }
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult UpdateDeleteUserInAdmin(mvcTestingModel mvcModel)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            if (Session["Adminlogin"] != null)
            {
                mvcModel.userInAdminList = mvcDB.getDropDownForAdminWork();
            }
            else
            {
                return RedirectToAction("ErrorPage");
            }
            return View(mvcModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateDeleteUserInAdmin(string adwork, mvcTestingModel mvcModel, string submit)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            string AdminLogin = Session["Adminlogin"].ToString();
            mvcModel.userInAdminList = mvcDB.getDropDownForAdminWork();
            if (AdminLogin != "")
            {
                //var str = Request["submit"];
                if (submit == "submit2")
                {
                    int result = 100;
                    string AdminDropdown = Session["adminDropDown"].ToString();
                    if ((AdminDropdown != "Support") && (AdminDropdown != "Admin"))
                    {
                        result = mvcDB.deleteUserAcFromAdmin(adwork);
                        if (result == 0)
                        {
                            ViewData["delete"] = "true";
                        }
                        else if (result == -1)
                        {
                            ViewData["delete"] = "false1";
                        }
                    }
                    else
                    {
                        ViewData["delete"] = "false2";
                    }
                }
                else if (submit == "submit1")
                {
                    if (adwork == "")
                    {
                        return RedirectToAction("ErrorPage");
                    }
                    else
                    {
                        int res = 100;
                        res = mvcDB.CheckUserDetailsInAdmin(adwork);
                        if (res == 1)
                        {
                            return RedirectToAction("AdminWorkPopUp", "Home", new { Name = adwork });
                        }
                        else
                        {
                            ViewData["Userfalse"] = "false";
                        }
                    }
                }
            }
            else
            {
                return RedirectToAction("ErrorPage");
            }
            return View(mvcModel);
        }
        public ActionResult AdminWorkPopUp(mvcTestingModel mvcModel)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            AdminWorkPopUp adminModel = new AdminWorkPopUp();
            //string AdminLogin = Session["Adminlogin"].ToString();
            if (Session["Adminlogin"] != null)
            {
                string AdminLogin = Session["Adminlogin"].ToString();
                string UserName = Request.QueryString["Name"];
                mvcModel.AdminWorkPopUp = mvcDB.UpdateUserDetailsInPopup(UserName);
                if (mvcModel.AdminWorkPopUp.AdminName != null)
                {
                    ViewBag.Value = "Last Updated By: " + mvcModel.AdminWorkPopUp.AdminName + " Date: " + mvcModel.AdminWorkPopUp.LastUpdate.ToString();
                }
                else
                {
                    ViewBag.Value = "Updates not available yet";
                }
            }
            else
            {
                return RedirectToAction("ErrorPage");
            }
            return View(mvcModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminWorkPopUp(mvcTestingModel mvcModel, AdminWorkPopUp adminModel)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            try
            {
                string AdminLogin = Session["Adminlogin"].ToString();
                string AdminDropdown = Session["adminDropDown"].ToString();
                if (AdminLogin != "")
                {
                    if ((AdminDropdown != "Support") && (AdminDropdown != "Admin"))
                    {
                        int result = mvcDB.UpdateUserDetailsInDatabase(mvcModel.AdminWorkPopUp.RegName, mvcModel.AdminWorkPopUp.RegUserName, mvcModel.AdminWorkPopUp.RegEMail, mvcModel.AdminWorkPopUp.RegAddress, mvcModel.AdminWorkPopUp.RegPhone, mvcModel.AdminWorkPopUp.RegCompany, AdminLogin);
                        if (result == 0)
                        {
                            ViewData["result"] = "true";
                        }
                        else
                        {
                            ViewData["result"] = "false";
                        }
                    }
                    else
                    {
                        ViewData["delete"] = "false2";
                    }
                }
                else
                {
                    return RedirectToAction("ErrorPage");
                }
            }
            catch
            {
                return RedirectToAction("About", "Home");
            }
            return View();
        }
        [GridAction]
        public ActionResult ReserveBook()
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcTestingModel mvcModel = new mvcTestingModel();
            mvcModel.TotalBookResult = mvcDB.allBooksList();
            Session["gridlist"] = mvcModel.TotalBookResult;
            return View(mvcModel);
        }
        //[GridAction]
        //public ActionResult _ReserveBook()
        //{
        //    return View(new GridModel<ReserveBooks> { Data = Session["gridlist"] });

        //}
        public ActionResult ErrorPage()
        {
            return View();
        }
        public ActionResult AboutUs(mvcTestingModel mvcModel)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            Session["Adminlogin"] = "";
            try
            {
                mvcModel.CommentList = mvcDB.AllComments();
                return View(mvcModel);
            }
            catch
            {
                return RedirectToAction("About", "Home");
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AboutUs(mvcTestingModel mvcModel, string str)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            try
            {
                string login = Session["login"].ToString();
                if (login != "")
                {
                    int result = 100;
                    result = mvcDB.InsertCommnetsAboutUs(login, mvcModel.Comments.ComName, mvcModel.Comments.ComEMail, mvcModel.Comments.ComLocation, mvcModel.Comments.ComComments);
                    if (result == 0)
                    {
                        ViewData["ValidInsert"] = "true";

                        //MailMessage mail = new MailMessage();
                        //mail.From = new MailAddress(mvcModel.Comments.ComEMail);
                        //mail.To.Add("coolsk86@gmail.com");
                        //mail.Subject = "Message from Online Book Library!!";
                        //mail.Body = mvcModel.Comments.ComComments;
                        //mail.IsBodyHtml = false;

                        //SmtpClient smtp = new SmtpClient();
                        //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //smtp.Host = "smtp.gmail.com";
                        //smtp.Port = 587;
                        //smtp.Credentials = new System.Net.NetworkCredential("coolsk86@gmail.com", "saurav1987");
                        //smtp.EnableSsl = true;
                        //smtp.Send(mail);                      
                        try
                        {
                            mvcModel.CommentList = mvcDB.AllComments();
                        }
                        catch
                        {
                            ViewData["LoadComments"] = "false";
                        }
                    }
                    else
                    {
                        ViewData["ValidInsert"] = "false";
                    }
                }
                else
                {
                    ViewData["login"] = "false";
                }
            }
            catch
            {
                return RedirectToAction("About", "Home");
            }
            return View(mvcModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult forgotpassword(mvcTestingModel mvcModel)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            int result = 100;
            try
            {
                result = mvcDB.forgetPass(mvcModel.forgotPassword.UserName, mvcModel.forgotPassword.EMail, mvcModel.forgotPassword.NewPass, mvcModel.forgotPassword.ConfirmPass);
                if (result == 1)
                {
                    ViewData["Success"] = "true";
                }
                else
                {
                    ViewData["Success"] = "false";
                }
            }
            catch
            {
                return RedirectToAction("ErrorPage");
            }
            return View();
        }
        public ActionResult forgotpassword()
        {
            return View();
        }
        public ActionResult AdminSelf()
        {
            ViewData["Query"] = "load";
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcTestingModel mvcModel = new mvcTestingModel();
            mvcModel.AdminselfList = mvcDB.AllAdminList();
            return View(mvcModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AdminSelf(mvcTestingModel mvcModel, string Search, string AdminName, int adminSelection)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcModel.AdminselfList = mvcDB.AllAdminList();
            if ((Search == "adminselfbutton1") && (adminSelection == 0))
            {
                RedirectToAction("AdminSelfDetails", "Home", new { name = AdminName });
                //ViewData["Query0"] = "Zero";
            }
            if ((Search == "adminselfbutton1") && (adminSelection == 1))
            {
                RedirectToAction("AdminSelfDetails", "Home", new { name = AdminName });
                //ViewData["Query1"] = "One";
            }
            return View (mvcModel);
        }
        //public ActionResult AdminSelfList(mvcTestingModel mvcModel)
        //{
        //    mvcTestingDB mvcDB = new mvcTestingDB();
        //    ViewData["Query1"] = Request.QueryString["name"];
        //    //mvcModel.AdminSelfList2.QName = Request.QueryString["name"].ToString();
        //    //mvcModel.AdminSelfList2.QId = Convert.ToInt32(Request.QueryString["id"]);
        //    ViewData["Query2"] = Convert.ToInt32(Request.QueryString["id"]);
        //    mvcModel.AdminSelfList2 = mvcDB.AllAdminListRow(ViewData["Query1"].ToString());
        //    return View(mvcModel);
        //}
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult AdminSelfList(mvcTestingModel mvcModel, AdminSelfList AdminSelfList1)
        //{
        //    return View();
        //}

        public ActionResult AdminSelfDetails(mvcTestingModel mvcModel)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            ViewData["Query"] = Request.QueryString["name"];
            mvcModel.AdminSelfList2 = mvcDB.AllAdminListRow(ViewData["Query"].ToString());
            return PartialView(mvcModel);
        }

        public JsonResult ViewBookDetails(string bookID)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            mvcTestingModel mvcModel = new mvcTestingModel();
            mvcModel.ViewDetails = mvcDB.allBooksDetailsList(bookID);
            return Json(mvcModel);
        }
        public ActionResult NewBook()
        {
            if (Session["Adminlogin"] != null)
            {
                mvcTestingDB mvcDB = new mvcTestingDB();
                mvcTestingModel mvcModel = new mvcTestingModel();
                mvcModel.Category = mvcDB.getDropDownForSearch();
                return View(mvcModel);
            }
            else
            {
                return RedirectToAction("ErrorPage");
            }
        }
        [HttpPost]
        public ActionResult NewBook(mvcTestingModel mvcModel, CreateBook crt, string Category)
        {
            mvcTestingDB mvcDB = new mvcTestingDB();
            int result = 100;
            result = mvcDB.InsertSingleBookDetails(mvcModel.CreateBook.BookName, mvcModel.CreateBook.AuthorName, mvcModel.CreateBook.Publisher, Category, mvcModel.CreateBook.ISBN, mvcModel.CreateBook.PublishYear);
            mvcModel.Category = mvcDB.getDropDownForSearch();
            if (result == 0)
            {
                ViewData["success"] = "true";
                mvcModel.CreateBook.result = "Successfully, Book Deatails have been updated to the database.";
            }
            else
            {
                ViewData["success"] = "false";
            }
            return View(mvcModel);
        }
        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("About", "Home");
        }
    }
}
