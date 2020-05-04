using EventCatalogApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Data
{
    public static class CatalogSeed
    {
        //Populate data in the DB
        public static void Seed(CatalogContext context)
        {
            context.Database.Migrate();
            /*if (!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(GetPreConfiguredEventLocations());
                context.SaveChanges();
            }*/
            if (!context.EventTopics.Any())
            {
                context.EventTopics.AddRange(GetPreConfiguredEventTopics());
                context.SaveChanges();
            }
            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetPreConfiguredEventTypes());
                context.SaveChanges();
            }
            if (!context.EventNames.Any())
            {
                context.EventNames.AddRange(GetPreConfiguredEventNames());
                context.SaveChanges();
            }
        }

        private static IEnumerable<EventType> GetPreConfiguredEventTypes()
        {
            return new List<EventType>
            {
                new EventType { Type = "Dinner or Gala" },
                new EventType { Type = "Concert or Performance" },
                new EventType { Type = "Game or Competition" },
                new EventType { Type = "Party or Social Gathering" },
                new EventType { Type = "Festival or Fair" },
                new EventType { Type = "Class, Training or Workshop" },
                new EventType { Type = "Meeting or Networking Event" },
                new EventType { Type = "Convention or Confernce" },
                new EventType { Type = "Seminar or Talk" },
                new EventType { Type = "Other" },
            };
        }

        private static IEnumerable<EventTopic> GetPreConfiguredEventTopics()
        {
            return new List<EventTopic>
            {
                new EventTopic { Topic = "Food & Drink" },
                new EventTopic { Topic = "Performing & Visual Arts" },
                new EventTopic { Topic = "Hobbies & Special Interest" },
                new EventTopic { Topic = "Religion & Spirituality" },
                new EventTopic { Topic = "Seasonal & Holiday" },
                new EventTopic { Topic = "Home & Lifestyle" },
                new EventTopic { Topic = "Film, Media & Entertainment" },
                new EventTopic { Topic = "Health & Wellness" },
                new EventTopic { Topic = "Science & Technology" },
                new EventTopic { Topic = "Other" },
            };
        }

        private static IEnumerable<EventName> GetPreConfiguredEventNames()
        {
            return new List<EventName>
            {
                new EventName { EventTypeId = 10, EventTopicId = 10, Title = "Hobbies", Description = "Photography Meeting",  Price=25.00M, Location="Redmond", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventName { EventTypeId = 1, EventTopicId = 1, Title = "Social Event", Description = "Neighbourhood Fair",  Price=0.00M, Location="Bothell", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventName { EventTypeId = 1, EventTopicId = 1, Title = "Social Event", Description = "Welcome Party",  Price=0.00M, Location="Bellevue", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/26" },
                new EventName { EventTypeId = 1, EventTopicId = 1, Title = "Social Event", Description = "College alumini meeting",  Price=125.00M, Location="Sammamish", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/36" },
                new EventName { EventTypeId = 1, EventTopicId = 1, Title = "Gala Event", Description = "Friends Party Convention",  Price=250.00M, Location="Issaquah", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/40" },
                new EventName { EventTypeId = 7, EventTopicId = 9, Title = "Dinner Event", Description = "Graduation Party",  Price=250.00M, Location="Seattle", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/19" },
                new EventName { EventTypeId = 8, EventTopicId = 9, Title = "Dinner Event", Description = "Graduation Party",  Price=1250.00M, Location="Seattle", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/28" },
                new EventName { EventTypeId = 8, EventTopicId = 9, Title = "Dinner Event", Description = "Graduation Party",  Price=250.00M, Location="Seattle", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/35" },
                new EventName { EventTypeId = 4, EventTopicId = 6, Title = "Social Event", Description = "Neighbourhood Fair",  Price=0.00M, Location="Bothell", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventName { EventTypeId = 4, EventTopicId = 6, Title = "Social Event", Description = "Welcome Party",  Price=0.00M, Location="Bellevue", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new EventName { EventTypeId = 4, EventTopicId = 6, Title = "Social Event", Description = "College alumini meeting",  Price=125.00M, Location="Sammamish", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" },
                new EventName { EventTypeId = 4, EventTopicId = 6, Title = "Gala Event", Description = "Friends Party Convention",  Price=1250.00M, Location="Issaquah", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventName { EventTypeId = 6, EventTopicId = 8, Title = "Yoga", Description = "Networking",  Price=50.00M, Location="Seattle", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new EventName { EventTypeId = 6, EventTopicId = 8, Title = "Fitness", Description = "Neighbourhood Meet",  Price=0.00M, Location="Redmond", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventName { EventTypeId = 6, EventTopicId = 8, Title = "Fitness Event", Description = "Welcome Party",  Price=0.00M, Location="Bellevue", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new EventName { EventTypeId = 7, EventTopicId = 8, Title = "Fitness Event", Description = "Local fitness",  Price=125.00M, Location="Sammamish", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new EventName { EventTypeId = 7, EventTopicId = 8, Title = "Fitness Event", Description = "Friends fitness",  Price=20.00M, Location="Issaquah", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new EventName { EventTypeId = 8, EventTopicId = 9, Title = "Science & Technology", Description = "AI Symposium",  Price=1250.00M, Location="Issaquah", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/16" },
                new EventName { EventTypeId = 8, EventTopicId = 9, Title = "Technology", Description = "Next Trends in AI",  Price=50.00M, Location="Seattle", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/17" },
                new EventName { EventTypeId = 8, EventTopicId = 9, Title = "Science", Description = "Going to Space",  Price=0.00M, Location="Redmond", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/18" },
                new EventName { EventTypeId = 6, EventTopicId = 7, Title = "Workshop", Description = "Hands On Coding Python",  Price=0.00M, Location="Bellevue", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/20" },
                new EventName { EventTypeId = 6, EventTopicId = 7, Title = "Training", Description = "Android Mobile App Development",  Price=125.00M, Location="Sammamish", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/24" },
                new EventName { EventTypeId = 6, EventTopicId = 7, Title = "Education", Description = "Analytics Workshop",  Price=20.00M, Location="Issaquah", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/31" },
                new EventName { EventTypeId = 1, EventTopicId = 1, Title = "Gala Event", Description = "Friends Party Convention",  Price=1250.00M, Location="Issaquah", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new EventName { EventTypeId = 9, EventTopicId = 9, Title = "Conference", Description = "Networking",  Price=50.00M, Location="Seattle", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/30" },
                new EventName { EventTypeId = 9, EventTopicId = 9, Title = "Conference", Description = "Neighbourhood Meet",  Price=0.00M, Location="Redmond", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/35" },
                new EventName { EventTypeId = 9, EventTopicId = 2, Title = "Conference", Description = "SDE Skills Meetup",  Price=0.00M, Location="Bellevue", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/27" },
                new EventName { EventTypeId = 9, EventTopicId = 2, Title = "Conference", Description = "Info Academy Annual Conference",  Price=125.00M, Location="Sammamish", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/29" },
                new EventName { EventTypeId = 9, EventTopicId = 2, Title = "Conference", Description = "Coding Meetup",  Price=20.00M, Location="Issaquah", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/32" },
                new EventName { EventTypeId = 9, EventTopicId = 2, Title = "Conference", Description = "Python Conference",  Price=20.00M, Location="Issaquah", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/39" },
                new EventName { EventTypeId = 4, EventTopicId = 6, Title = "Hobbies", Description = "Home Improvment",  Price=25.00M, Location="Redmond", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new EventName { EventTypeId = 4, EventTopicId = 6, Title = "Entertainment", Description = "Media & Music",  Price=0.00M, Location="Bothell", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new EventName { EventTypeId = 7, EventTopicId = 9, Title = "Networking", Description = "Women who can Code",  Price=0.00M, Location="Bellevue", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/38" },
                new EventName { EventTypeId = 7, EventTopicId = 3, Title = "Networking", Description = "Women in Technology",  Price=0.00M, Location="Sammamish", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/37" },
                new EventName { EventTypeId = 5, EventTopicId = 4, Title = "Gala Event", Description = "Friends Party Convention",  Price=250.00M, Location="Issaquah", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/21" },
                new EventName { EventTypeId = 5, EventTopicId = 4, Title = "Cultural", Description = "Graduation Party",  Price=250.00M, Location="Seattle", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/22" },
                new EventName { EventTypeId = 5, EventTopicId = 4, Title = "Cultural", Description = "Neighbourhood Fair",  Price=1250.00M, Location="Seattle", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/23" },
                new EventName { EventTypeId = 5, EventTopicId = 4, Title = "Dinner Event", Description = "Welcome Party",  Price=250.00M, Location="Seattle", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/25" },
                new EventName { EventTypeId = 5, EventTopicId = 4, Title = "Social Event", Description = "Neighbourhood Fair",  Price=0.00M, Location="Bothell", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" },
                new EventName { EventTypeId = 5, EventTopicId = 4, Title = "Social Event", Description = "Welcome Party",  Price=0.00M, Location="Bellevue", Listing="Free", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/33" },
                new EventName { EventTypeId = 5, EventTopicId = 4, Title = "Social Event", Description = "College alumini meeting",  Price=125.00M, Location="Sammamish", Listing="Paid", StartDate=new DateTime(2020, 5, 1, 8, 30, 00), EndDate=new DateTime(2020, 5, 1, 15, 30, 00), ImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/34" },
            };
        }

        /*private static IEnumerable<EventLocation> GetPreConfiguredEventLocations()
        {
            return new List<EventLocation>
            {
                new EventLocation { Location = "Redmond" },
                new EventLocation { Location = "Bellevue" },
                new EventLocation { Location = "Bothell" },
                new EventLocation { Location = "Sammamish" },
                new EventLocation { Location = "Seattle" },
                new EventLocation { Location = "Issaquah" },
                new EventLocation { Location = "Renton" },
                new EventLocation { Location = "Kirkland" },
                new EventLocation { Location = "Woodenville" },
                new EventLocation { Location = "Duval" },
                new EventLocation { Location = "Outside the Puget Sound Area" },
            };
        }*/
    }
}
