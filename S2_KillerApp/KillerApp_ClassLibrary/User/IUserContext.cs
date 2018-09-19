using System;
using System.Collections.Generic;
using System.Text;

namespace KillerApp_ClassLibrary.User
{
    interface IUserContext
    {
        void SelectUser();
        void AddUser();
        void DeleteUser();
        void UpdateStatus();
    }
}
