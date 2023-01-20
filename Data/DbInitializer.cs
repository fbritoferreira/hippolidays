using System;
using System.Diagnostics;
using hippolidays.Models;
using hippolidays.Areas.Identity.Pages.Account;

namespace hippolidays.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            var applicationUsers = context.Users.ToArray();

            if (context.RequestType.Any())
            {
                return;
            }
            var requestTypes = new RequestType[]
            {
                new RequestType{Type="annual",Reason="Want to go on holiday"},
                new RequestType{Type="special",Reason="Time off"},
                new RequestType{Type="annual",Reason="Volunteering for charity"},
                new RequestType{Type="annual",Reason="Malia with friends"},
                new RequestType{Type="annual",Reason="Need time off"},
                new RequestType{Type="special",Reason="Giving back to the local community"},
            };
            context.RequestType.AddRange(requestTypes);

            if (context.RequestStatus.Any())
            {
                return;
            }
            var requestStatuses = new RequestStatus[]
            {
                new RequestStatus{ApplicationUser=applicationUsers[0],Status="approved",Reason=":thumbs-up:",ActionDate=DateTime.Parse("2023-01-07")},
                new RequestStatus{ApplicationUser=applicationUsers[1],Status="rejected",Reason="too busy at work",ActionDate=DateTime.Parse("2023-01-07")},
                new RequestStatus{ApplicationUser=applicationUsers[2],Status="pending",Reason="",ActionDate=DateTime.Parse("2023-01-07")},
                new RequestStatus{ApplicationUser=applicationUsers[3],Status="approved",Reason="enjoy!",ActionDate=DateTime.Parse("2023-01-07")},
                new RequestStatus{ApplicationUser=applicationUsers[4],Status="rejected",Reason="",ActionDate=DateTime.Parse("2023-01-07")},
                new RequestStatus{ApplicationUser=applicationUsers[5],Status="pending",Reason="we need you in",ActionDate=DateTime.Parse("2023-01-07")},
            };
            context.RequestStatus.AddRange(requestStatuses);


            if (context.Request.Any())
            {
                return;
            }
            var requests = new Request[]
            {
                new Request{ApplicationUser=applicationUsers[0],RequestType=requestTypes[0],RequestStatus=requestStatuses[0],Start_Date=DateTime.Parse("2022-12-25"),End_Date=DateTime.Parse("2023-01-07"),Repeat=true},
                new Request{ApplicationUser=applicationUsers[0],RequestType=requestTypes[1],RequestStatus=requestStatuses[1],Start_Date=DateTime.Parse("2022-12-30"),End_Date=DateTime.Parse("2023-01-10"),Repeat=true},
                new Request{ApplicationUser=applicationUsers[1],RequestType=requestTypes[2],RequestStatus=requestStatuses[2],Start_Date=DateTime.Parse("2023-01-03"),End_Date=DateTime.Parse("2023-01-14"),Repeat=false},
                new Request{ApplicationUser=applicationUsers[1],RequestType=requestTypes[3],RequestStatus=requestStatuses[3],Start_Date=DateTime.Parse("2023-01-09"),End_Date=DateTime.Parse("2023-01-16"),Repeat=false},
                new Request{ApplicationUser=applicationUsers[2],RequestType=requestTypes[4],RequestStatus=requestStatuses[4], Start_Date=DateTime.Parse("2023-01-17"),End_Date=DateTime.Parse("2023-01-26"),Repeat=false},
                new Request{ApplicationUser=applicationUsers[2],RequestType=requestTypes[5],RequestStatus=requestStatuses[5],Start_Date=DateTime.Parse("2023-01-26"),End_Date=DateTime.Parse("2023-02-03"),Repeat=true},
            };
            context.Request.AddRange(requests);

            context.SaveChanges();
        }
    }
}
