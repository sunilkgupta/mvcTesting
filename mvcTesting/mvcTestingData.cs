using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Reflection;

namespace mvcTesting
{
    partial class mvcTestingDataDataContext : System.Data.Linq.DataContext
    {
        [Function(Name = "dbo.GetDropDownListInfoBook")]
        [ResultType(typeof(InfoBook))]
        [ResultType(typeof(UserRegistration))]
        public IMultipleResults GetDropDownListInfoBook([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Action", DbType = "Int")] System.Nullable<int> action)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), action);
            return (IMultipleResults)(result.ReturnValue);
        }
        [Function(Name = "dbo.GetUserDetailsInAdminPopup")]
        ////[ResultType(typeof(UserRegistration))]
        [ResultType(typeof(UserRegistration))]
        public IMultipleResults GetUserDetailsInAdminPopup([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "RegUserName", DbType = "VarChar(50)")] string regUserName)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), regUserName);
            return (IMultipleResults)(result.ReturnValue);
        }

        [Function(Name = "dbo.AllInfoBook")]
        [ResultType(typeof(InfoBook))]
        public IMultipleResults AllInfoBook([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "BookID", DbType = "VarChar(50)")] string bookID)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), bookID);
            return (IMultipleResults)(result.ReturnValue);
        }
    
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.AdminNameList")]
        [ResultType(typeof(NewAdmin))]
        public IMultipleResults AdminNameList([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AdminName", DbType = "VarChar(50)")] string adminName)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), adminName);
            return (IMultipleResults)(result.ReturnValue);
        }
    }
}