﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Team_Git_JooleMay_Service.Interface_Service;
using MVC_Team_Git_JooleMay_Repository.Class_Repository;
using MVC_Team_Git_JooleMay_Repository.Interface_Repository;
using MVC_Team_Git_JooleMay_DAL;


namespace MVC_Team_Git_JooleMay_Service.Class_Service
{
    class UserLogin
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new JooleMayEntities());



        //public User GetByUsernameAndPassword(User user)
        //{

        //    return unitOfWork.Users.Where(u => u.Username == user.Username & u.Password == user.Password).FirstOrDefault();
        //}
    }
}
