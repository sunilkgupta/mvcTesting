using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace mvcTesting.Models
{
    public class mvcTestingDB : DbContext
    {
        mvcTestingDataDataContext dataDB = new mvcTestingDataDataContext();
        //mvcTestingModel dataModel = new mvcTestingModel();        
        public int? validateUser(string user, string pass)
        {
            int? result = 0;
            ISingleResult<validateUserNameResult> data = dataDB.validateUserName(user,pass);            
            foreach (var response in data)
            {
                result = response.Result;
            }
            return result;
        }
        public int InsertNewUser(string RegName,string RegUserName,string RegPassword,string RegConfirmPassword,string RegEMail,string RegAddress, string RegPhone, string RegCompany)
        {
            int result = 0;
            result = dataDB.InsertNewUser(RegName, RegUserName, RegPassword, RegConfirmPassword, RegEMail, RegAddress, RegPhone,RegCompany);
            return result;
        }
        public List<string> getDropDownForSearch()
        {
            mvcTestingModel dataModel = new mvcTestingModel();        
            IMultipleResults data = dataDB.GetDropDownListInfoBook(1);
            List<string> dropDownSearch = new List<string>();
            foreach (InfoBook info in data.GetResult<InfoBook>())
            {
                dataModel.CategorySingle = info.Category;
                dropDownSearch.Add(dataModel.CategorySingle);
            }

            return dropDownSearch;
        }
        public List<string> getAdminDropDownList()
        {
            mvcTestingModel dataModel = new mvcTestingModel();        
            ISingleResult<GetAdminDropDownResult> data = dataDB.GetAdminDropDown();
            List<string> dropDownAdmin = new List<string>();
            foreach (var resultAdmin in data)
            {
                dataModel.AdminSingle = resultAdmin.Values;
                dropDownAdmin.Add(dataModel.AdminSingle);
            }
            return dropDownAdmin;
        }
        public int ValidateAdmin(string ad,string pass,int code,string category)
        {
            int admin = 100;
            admin = dataDB.ValidateAdmin(ad,pass,code,category);
            return admin;
        }
        public int InsertNewAdmin(string name, string pass, string phone, string address, string design, string category)
        {
            int NewAdmin = 10;
            NewAdmin = dataDB.InsertNewAdmin(name, pass, phone, address, design, category);
            return NewAdmin;
        }               
        public int deleteUserAcFromAdmin(string name)
        {
            int res = 100;
            res = dataDB.DeleteUserAcInAdmin(name);
            return res;
        }
        public List<userInAdmin> getDropDownForAdminWork()
        {
            IMultipleResults data = dataDB.GetDropDownListInfoBook(2);
            List<userInAdmin> dropDownUserList = new List<userInAdmin>();
            foreach (UserRegistration user in data.GetResult<UserRegistration>())
            {
                userInAdmin usr = new userInAdmin();
                usr.UsrName  = user.RegUserName;
                dropDownUserList.Add(usr);
            }
            return dropDownUserList;
        }
        public AdminWorkPopUp UpdateUserDetailsInPopup(string UserName)
        {
            IMultipleResults data = dataDB.GetUserDetailsInAdminPopup(UserName);
            AdminWorkPopUp adPopup = new AdminWorkPopUp();
            foreach (UserRegistration res in data.GetResult<UserRegistration>())
            {
                adPopup.RegName = res.RegName;
                adPopup.RegUserName = res.RegUserName;
                adPopup.RegEMail = res.RegEMail;
                adPopup.RegAddress = res.RegAddress;
                adPopup.RegPhone = res.RegPhone;
                adPopup.RegCompany = res.RegCompany;
                adPopup.AdminName = res.AdminName;
                adPopup.LastUpdate = res.TimeStamp.ToString();
            }
            return adPopup;
        }
        public AdminWorkPopUp GetLastUpdatedDetails(string UsrName)
        {
            ISingleResult<LastUpdatedDetailsResult> data = dataDB.LastUpdatedDetails(UsrName);
            AdminWorkPopUp adPopup = new AdminWorkPopUp();
            foreach (var res in data)
            {
                adPopup.AdminName = res.AdminName;
                adPopup.LastUpdate = res.LastUpdated.ToString();
            }
            return adPopup;
        }
        public int UpdateUserDetailsInDatabase(string regName,string regUserName,string regEMail,string regAddress,string regPhone,string regCompany,string admName)
        {
            int result = 100;
            result = dataDB.UpdateUserFromAdmin(regName, regUserName, regEMail, regAddress, regPhone, regCompany, admName);
            return result;
        }
        public int InsertCommnetsAboutUs(string UserName, string ComName,string ComEMail, string Comlocation, string ComComments)
        {
            int result = 100;
            result = dataDB.InsertComments(UserName, ComName, ComEMail, Comlocation, ComComments);
            return result;
        }
        public List<Comments> AllComments()
        {
            List<Comments> comList = new List<Models.Comments>();
            ISingleResult<ShowAllCommentsResult> data = dataDB.ShowAllComments();            
            foreach (var res in data)
            {
                Comments Comments = new Models.Comments();
                Comments.ShowName = res.ComName;
                Comments.ShowDate = res.time.ToString();
                Comments.ShowComments = res.ComComments;
                comList.Add(Comments);
            }
            return comList;
        }
        public List<ReserveBooks> allBooksList()
        {
            List<ReserveBooks> allBook = new List<ReserveBooks>();
            IMultipleResults data = dataDB.AllInfoBook(null);
            foreach (InfoBook res in data.GetResult<InfoBook>())
            {
                ReserveBooks rsBooks = new ReserveBooks();
                rsBooks.BookID = res.Book_ID;
                rsBooks.BookISBN = res.ISBN;
                rsBooks.AuthorName = res.AuthorName;
                rsBooks.publisher = res.Publisher;
                rsBooks.BookCategory = res.Category;
                rsBooks.Year = res.PublishYear;
                allBook.Add(rsBooks);
            }
            return allBook;
        }
        public List<SearchBooks> SearchAllBooks(string BKN, string ISBNName, string AuthName, string Ctgry)
        {
            List<SearchBooks> book = new List<SearchBooks>();
            ISingleResult<GetOnlineBookSearchResult> data = dataDB.GetOnlineBookSearch(BKN, ISBNName, AuthName, Ctgry);
            foreach (var res in data)
            {
                SearchBooks srBook = new SearchBooks();
                srBook.BookID = res.Book_ID;
                srBook.BookISBN = res.ISBN;
                srBook.BookName = res.BookName;
                srBook.AuthorName = res.AuthorName;
                srBook.publisher = res.Publisher;
                srBook.BookCategory = res.Category;
                book.Add(srBook);
            }
            return book;
        }
        public int forgetPass(string userName, string email, string newPass, string confirmPass)
        {
            int res = 100;
            res = dataDB.ForgotPassword(userName, email, newPass, confirmPass);
            return res;
        }
        public List<Adminself> AllAdminList()
        {
            List<Adminself> admin = new List<Adminself>();
            IMultipleResults data = dataDB.AdminNameList(null);
            foreach (NewAdmin res in data.GetResult<NewAdmin>())
            {
                Adminself adSelf = new Adminself();
                adSelf.adName = res.adminName;
                admin.Add(adSelf);
            }
            return admin;
        }
        public AdminSelfList AllAdminListRow(string adminName)
        {
            AdminSelfList adSelf1 = new AdminSelfList();
            IMultipleResults data = dataDB.AdminNameList(adminName);
            foreach (NewAdmin res in data.GetResult<NewAdmin>())
            {
                adSelf1.adminName = res.adminName;
                adSelf1.adminPassword = res.adminPassword;
                adSelf1.AdminAddress = res.AdminAddress;
                adSelf1.AdminCode = res.AdminCode;
                adSelf1.AdminPhone = res.AdminPhone;
                adSelf1.AdminCategory = res.AdminCategory;
                adSelf1.AdminDesignation = res.AdminDesignation;
            }
            return adSelf1;
        }
        public int CheckUserDetailsInAdmin(string UsrName)
        {
            int res = 100;
            res = dataDB.CheckUserInAdmin(UsrName);
            return res;
        }
        public ViewDetails allBooksDetailsList(string bkID)
        {
            IMultipleResults data = dataDB.AllInfoBook(bkID);
            ViewDetails vwDetails = new ViewDetails();
            foreach (InfoBook res in data.GetResult<InfoBook>())
            {
                vwDetails.BookISBN = res.ISBN;
                vwDetails.AuthorName = res.AuthorName;
                vwDetails.publisher = res.Publisher;
                vwDetails.BookCategory = res.Category;
                vwDetails.Year = res.PublishYear;
            }
            return vwDetails;
        }
        public int InsertSingleBookDetails(string BookName, string AuthorName, string Publisher, string Category, string ISBN,int PublishYear)       
        {
            int result = 100;
            result = dataDB.InsertSingleBook(BookName, AuthorName, Publisher, Category, ISBN, PublishYear);
            return result;
        }        
        public SelectedBook GetImgaesBook(string BookId)
        {
            SelectedBook select = new SelectedBook();
            ISingleResult<GetImgaesResult> data = dataDB.GetImgaes(BookId);
            foreach (var res in data)
            {
                select.BookID = res.BookID;
                select.Des1 = res.Description1;
                select.Des2 = res.Description2;
                select.Des3 = res.Description3;
                select.Price = Convert.ToDecimal(res.Price);
            }
            return select;
        }
    }
}