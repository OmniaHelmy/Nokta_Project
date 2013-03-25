using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nokta.Models
{
    public class UserModel
    {
        private NoktaContext context = new NoktaContext();

        public void AddUser(int FbuserId, string UserName,string ImagePath, string ProfilePath)
        {
            User u = new User();
            u.FBId = FbuserId;
            u.Name = UserName;
            u.ProfPic = ImagePath;
            u.Profile = ProfilePath;
            
            context.Users.Add(u);
            context.SaveChanges();
        }
        public User SelectUser(int UserID)
        {
            return context.Users.FirstOrDefault(x => x.FBId == UserID);
        }
    }



}