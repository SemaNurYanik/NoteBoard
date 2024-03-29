﻿using NoteBoard.DAL.Repositories;
using NoteBoard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBoard.BLL
{
    public class UserController
    {
        UserDAL _userDAL;
        public UserController()
        {
            _userDAL = new UserDAL();

        }

        public bool Add(User user)
        {
            //Kullanıcı kayıt olduktan sonra kullanıcı hesabı admin onayından geçmeden kullanıcı giriş yapamasın 
            try
            {
                if (user.Passwords.Count > 0)
                {
                    user.IsActive = false;
                    user.CreatedDate = DateTime.Now;
                    user.Passwords.First().IsActive = true;
                    user.Passwords.First().CreatedDate = DateTime.Now;
                    //admin onayıyla beraber

                    _userDAL.Add(user);
                    return true;
                }
                else
                {
                    throw new Exception("Şifre yok!");
                }
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        public bool Update(User user)
        {
            try
            {
                user.ModifiedDate = DateTime.Now;
                _userDAL.Update(user);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(User user)
        {
            user.IsActive = false;
            return Update(user);
            //hesap 30 günden fazla pasif kalırsa veritabanından silinsin?
        }

        public User GetByID(int userID)
        {
            return _userDAL.GetByID(userID);
        }

        public User GetByLogin(string username,string password)
        {
            List<User> users = _userDAL.GetAll();
            User user = users.Where(a => a.IsActive && a.UserName == username).SingleOrDefault();
            //burası single olabilir mi?
            if(user != null)
            {
                Password pass = user.Passwords.Where(a => a.IsActive && a.PasswordText == password).FirstOrDefault();
                if (pass == null)
                {
                    return null;
                }
            }
            return user;
        }

        public List<User> GetAll()
        {
            return _userDAL.GetAll();
        }


    }
}
