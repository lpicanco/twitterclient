using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToTwitter;

namespace TwitterNet.Services
{
    public class TwitterFacade
    {
        private TwitterContext context;

        public bool Login(string login, string password)
        {
            bool result = true;

            context = new TwitterContext(login, password);
            
            return result;
        }

        public IList<Status> ListUserTwitters()
        {
            var twitters = (from twitter in context.Status
                           where twitter.Type == StatusType.User
                           select twitter).ToList();

            return twitters;
        }

        public IList<Status> ListTwitters()
        {
            var twitters = (from twitter in context.Status
                            where twitter.Type == StatusType.Friends
                            select twitter).ToList();

            return twitters;
        }


        public IList<Status> ListReplies()
        {
            var twitters = (from twitter in context.Status
                            where twitter.Type == StatusType.Replies
                            select twitter).ToList();

            return twitters;
        }

        public void UpdateStatus(string status)
        {
            context = new TwitterContext(context.UserName, context.Password);
            context.UpdateStatus(status);
        }
    }
}
