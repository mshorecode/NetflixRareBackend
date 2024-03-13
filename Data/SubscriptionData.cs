using NetflixRareBackend.Models;

namespace NetflixRareBackend.Data
{
    public class SubscriptionData
    {
        public static List<Subscription> Subscriptions = new List<Subscription>()
        {
            new Subscription {Id = 1, Author_Id = 1, Follower_Id = 2, Created_On = new DateTime(2024, 2, 10)},
            new Subscription {Id = 2, Author_Id = 2, Follower_Id = 3, Created_On = new DateTime(2024, 1, 20), Ended_On = new DateTime(2024, 2, 28)},
            new Subscription {Id = 3, Author_Id = 3, Follower_Id = 1, Created_On = new DateTime(2023, 11, 15)}
        };
    }
}
