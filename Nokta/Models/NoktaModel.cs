using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Raven;

namespace Nokta.Models
{
    public class NoktaModel
    {
        NoktaContext context=new NoktaContext();
        public void AddNokta(string post, int userId)
        {
            Nokat N = context.Nokats.Create();
            N.NoktaPost = post;
            N.NoktaOwner = context.Users.FirstOrDefault(x => x.FBId == userId);
            N.UserId = userId;

            context.Nokats.Add(N);
            context.SaveChanges();
        }
        //select kol l noktas el fl 3alm 
        public List<Nokat> SelectNokats()
        {
            return context.Nokats.ToList();


        }
        //select kol l nokats bta3t user mo3yn
        public List<Nokat> SelectUserNokats(int userId)
        {
            return context.Nokats.Where(x => x.NoktaOwner.Id == userId).ToList();

        }
        //select nokta wa7da bssssss
        public Nokat SelectNokta(int noktaId)
        {
            return context.Nokats.Find(noktaId);

        }  
        

        /// <summary>
        /// to Add Vote to a Nokta
        /// </summary>
        /// <param name="noktaId"></param>
        /// <param name="userId"></param>
        /// <param name="UDV"></param>
        //public bool AddVote(int noktaId,int userId,bool UDV)
        //{
        //    Votes v = new Votes();
        //    v.NoktaId = noktaId;
        //    v.UserId = userId;
        //    v.VoteValue = UDV;
        //    if (context.Voteses.FirstOrDefault(x => x.NoktaId == v.NoktaId && x.UserId == v.UserId) == null)
        //    {
        //        context.Voteses.Add(v);
        //        context.SaveChanges();
        //        return true;

        //    }
           
        //    return false;
        //}

    }
}