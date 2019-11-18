using NoteBoard.DAL.Repositories;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{
    class UserController
    {
        UserDAL _userDAL;
        public UserController()
        {
            _userDAL = new UserDAL();

        }

        public bool Add(User user)
        {
            //Kullanıcı kayıt olduktan sonra kullanıcı hesabı admin onayından geçmeden kullanıcı giriş yapamasın 
        }


    }
}
