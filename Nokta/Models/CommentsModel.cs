using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nokta.Models
{
    public class CommentsModel
    {
        NoktaContext context=new NoktaContext();
        public void AddCommnet(string post, int userId, int NoktaID)
        {
            Comments C = new Comments();
            C.CommentPost = post;
            C.UserId = userId;
            C.NoktaId = NoktaID;
            context.Commentses.Add(C);
            context.SaveChanges();
        }
        public List<Comments> SelectCommnet(int NoktaID)
        {
            return context.Commentses.Where(x => x.NoktaId == NoktaID).ToList();

        }
    }
}