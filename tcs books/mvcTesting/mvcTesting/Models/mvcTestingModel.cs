using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using mvcTesting.Models;
using mvcTesting.Controllers;

namespace mvcTesting.Models
{
    public class mvcTestingModel
    {
        public string FriendName { get; set; }
        public int FriendID { get; set; }
        public List<string> Name { get; set; }
        public List<string> NameCo { get; set; }
        public string CompanyName { get; set; }
        
        //About login page
        public string UserName { get; set; }        
        public string Password { get; set; }
        public int? Result { get; set; }

        //Book details search..        
        public string CategorySingle { get; set; }
        [Required(ErrorMessage="{0} can not be empty")]
        public List<string> Category;
        
        //Register Details
        [StringLength(50, ErrorMessage="Name can not be empty",MinimumLength=6)]
        public string RegName { get; set; }

        [StringLength(50, ErrorMessage="Max only 50 char allowed", MinimumLength=6)]
        public string RegUserName { get; set; }

        [StringLength(15,ErrorMessage="Max only 15 char allowed", MinimumLength=6)]
        [DataType(DataType.Password)]
        [Display(Name="Reg Password")]
        public string RegPassword { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "RegConfirmPassword")]
        //[Compare("Reg Password", ErrorMessage = "Password and confirm password not matching.")]
        public string RegConfirmPassword { get; set; }

        public string RegEMail { get; set; }
        public string RegAddress { get; set; }
        public string RegPhone { get; set; }
        public string RegCompany { get; set; }
        public int RegResult { get; set; }
        public string RegMSG { get; set; }

        //Admin details..
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public string AdminSingle { get; set; }
        public List<string> adminDropDown { get; set; }
        public string adminSingledropdown { get; set; }
        public string AdminCategory { get; set; }
        public int AdminCode { get; set; }
        public int AdminResult { get; set; }

        //Add new admin...
        public string NewAdName { get; set; }
        public string NewAdPass { get; set; }
        public string NewAdPhone { get; set; }
        public string NewAdAddress { get; set; }
        public string NewAdDesign { get; set; }
        public List<string> NewAdCategory { get; set; }
        public string NewAdCategorySingle { get; set; }
        public int NewAdResult { get; set; }       

        //admin work..
        public List<string> Adwork { get; set; }
        public string  AdworkSingle { get; set; }
        public string UserforAdmin { get; set; }
        public string AdminUpdateName { get; set; }

        public List<string> adminAutoComplete { get; set; }
        public List<Comments> CommentList { get; set; }        
        public Comments Comments { get; set; }

        public AdminWorkPopUp AdminWorkPopUp { get; set; }

        public List<ReserveBooks> TotalBookResult { get; set; }

        public SearchBooks SearchBooks { get; set; }
        public List<SearchBooks> SearchBooksList { get; set; }

        public forgotPassword forgotPassword { get; set; }

        public Adminself Adminself { get; set; }
        public List<Adminself> AdminselfList { get; set; }

        public AdminSelfList AdminSelfList2 { get; set; }
        public List<AdminSelfList> AdminSelfWholeList { get; set; }

        public ViewDetails ViewDetails { get; set; }
        public ViewDetails ViewDetailsList { get; set; }

        public AutoCompleteAttributes AutoCompleteAttributes
        {
            get;
            set;
        }

        public userInAdmin userInAdmin { get; set; }
        public List<userInAdmin> userInAdminList { get; set; }

        public CreateBook CreateBook { get; set; }

        public List<string> CategoryList { get; set; }
    }    
    public class AdminWorkPopUp
    {
        public string RegName { get; set; }
        public string RegUserName { get; set; }
        public string RegPassword { get; set; }
        public string RegEMail { get; set; }
        public string RegAddress { get; set; }
        public string RegPhone { get; set; }
        public string RegCompany { get; set; }

        public string AdminName { get; set; }
        public string LastUpdate { get; set; }
    }
    [Serializable]
    public class Comments
    {
        public string ComName { get; set; }
        public string ComEMail { get; set; }
        public string ComLocation { get; set; }
        public string ComComments { get; set; }
        public string Response { get; set; }

        //For comments
        public string ShowName { get; set; }
        public string ShowComments { get; set; }
        public string ShowDate { get; set; }
    }
    public class ReserveBooks
    {
        public string BookID { get; set; }
        public string BookISBN { get; set; }
        public string AuthorName { get; set; }
        public string publisher { get; set; }
        public string BookCategory { get; set; }
        public string Year { get; set; }
        public int ID { get; set; }
    }
    public class SearchBooks
    {
        public string BookNameInput { get; set; }
        public string BookISBNInput { get; set; }
        public string AuthorNameInput { get; set; }

        public string BookID { get; set; }
        public string BookISBN { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string publisher { get; set; }
        public string BookCategory { get; set; }
        public string Year { get; set; }
    }
    public class forgotPassword
    {
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string NewPass { get; set; }
        public string ConfirmPass { get; set; }
    }
    public class Adminself
    {
        public string adName { get; set; }
    }
    public class AutoCompleteAttributes
    {
        
    }
    public class userInAdmin
    {
        public string UsrName { get; set; }
    }
    public class ViewDetails
    {
        public string BookID { get; set; }
        public string BookISBN { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string publisher { get; set; }
        public string BookCategory { get; set; }
        public string Year { get; set; }
    }
    public class AdminSelfList
    {
        public string adminName { get; set; }
        public string adminPassword { get; set; }
        public string adminNewPassword { get; set; }
        public string adminOldPassword { get; set; }
        public string adminConfirmPassword { get; set; }
        public string AdminAddress { get; set; }
        public int AdminCode { get; set; }
        public string AdminPhone { get; set; }
        public string AdminCategory { get; set; }
        public string AdminDesignation { get; set; }
        public string QName { get; set; }
        public int QId { get; set; }
    }
    public class CreateBook
    {
        [Required(ErrorMessage = "{0} can not be empty")]
        [Display(Name = "Book Name")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "{0} can not be empty")]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "{0} can not be empty")]
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }

        [Required]
        [Display(Name = "Category")]
        public List<string> Category { get; set; }

        [Required(ErrorMessage = "{0} can not be empty")]
        [Display(Name = "ISBN No.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "{0} can not be empty")]
        [Display(Name = "PublishYear")]
        public int PublishYear { get; set; }

        public string result { get; set; }


    }

}