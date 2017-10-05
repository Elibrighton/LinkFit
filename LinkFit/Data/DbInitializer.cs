using LinkFit.Authorization;
using LinkFit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = serviceProvider.GetRequiredService<CoachContext>())
            {
                context.Database.EnsureCreated();

                var userID = await EnsureUser(serviceProvider, testUserPw, "test@example.com");
                await EnsureAthlete(context, userID, "Test", "User");

                userID = await EnsureUser(serviceProvider, testUserPw, "eli.brighton@gmail.com");
                await EnsureRole(serviceProvider, userID, Constants.AthleteAdministratorsRole);
                var firstname = "Eli";
                var surname = "Brighton";
                await EnsureAthlete(context, userID, firstname, surname);
                await EnsureCoach(context, userID, firstname, surname);

                userID = await EnsureUser(serviceProvider, testUserPw, "kephren@linkfit.com.au");
                await EnsureRole(serviceProvider, userID, Constants.AthleteAdministratorsRole);
                firstname = "Kephren";
                surname = "Izzard";
                await EnsureAthlete(context, userID, firstname, surname);
                await EnsureCoach(context, userID, firstname, surname);

                SeedDb(context);
            }
        }

        private static void SeedDb(CoachContext context)
        {
            // Look for any students.
            //if (context.Athletes.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //var athletes = new Athlete[]
            //{
            //    new Athlete{FirstName="Rebecca",Surname="Jenner",EnrollmentDate=DateTime.Parse("2005-09-01")},
            //    new Athlete{FirstName="Kody",Surname="Barrett",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //    new Athlete{FirstName="Ian",Surname="Hurley",EnrollmentDate=DateTime.Parse("2003-09-01")},
            //    new Athlete{FirstName="Sherry",Surname="Ey",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //    new Athlete{FirstName="Kephren",Surname="Izzard",EnrollmentDate=DateTime.Parse("2002-09-01")},
            //    new Athlete{FirstName="Grant",Surname="Little",EnrollmentDate=DateTime.Parse("2001-09-01")},
            //    new Athlete{FirstName="Leslie",Surname="Sproule",EnrollmentDate=DateTime.Parse("2003-09-01")},
            //    new Athlete{FirstName="Troy",Surname="Austin",EnrollmentDate=DateTime.Parse("2005-09-01")}
            //};
            //foreach (Athlete a in athletes)
            //{
            //    context.Athletes.Add(a);
            //}
            //context.SaveChanges();

            //var trainingPrograms = new TrainingProgram[]
            //{
            //    new TrainingProgram{Title="5 km running"},
            //    new TrainingProgram{Title="Marathon"},
            //    new TrainingProgram{Title="Ultra-marathon"},
            //    new TrainingProgram{Title="Ironman triathlon"},
            //    new TrainingProgram{Title="70.3 Ironman triathlon"},
            //    new TrainingProgram{Title="Open water swimming"}
            //};
            //foreach (TrainingProgram tp in trainingPrograms)
            //{
            //    context.TrainingPrograms.Add(tp);
            //}
            //context.SaveChanges();

            //var programEnrollments = new ProgramEnrollment[]
            //{
            //    new ProgramEnrollment{AthleteID=1,TrainingProgramID=2},
            //    new ProgramEnrollment{AthleteID=1,TrainingProgramID=1},
            //    new ProgramEnrollment{AthleteID=1,TrainingProgramID=4},
            //    new ProgramEnrollment{AthleteID=2,TrainingProgramID=5},
            //    new ProgramEnrollment{AthleteID=2,TrainingProgramID=3},
            //    new ProgramEnrollment{AthleteID=2,TrainingProgramID=1},
            //    new ProgramEnrollment{AthleteID=3,TrainingProgramID=2},
            //    new ProgramEnrollment{AthleteID=4,TrainingProgramID=1},
            //    new ProgramEnrollment{AthleteID=4,TrainingProgramID=6},
            //    new ProgramEnrollment{AthleteID=5,TrainingProgramID=1},
            //    new ProgramEnrollment{AthleteID=6,TrainingProgramID=2},
            //    new ProgramEnrollment{AthleteID=7,TrainingProgramID=4},
            //};
            //foreach (ProgramEnrollment pe in programEnrollments)
            //{
            //    context.ProgramEnrollments.Add(pe);
            //}
            //context.SaveChanges();
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider, string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = UserName,
                    Email = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider, string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }

        private static async Task<int> EnsureAthlete(CoachContext context, string userID, string firstName, string surname)
        {
            var athlete = new Athlete { };

            athlete = (Athlete)context.Athletes.FirstOrDefault(a => a.OwnerID == userID);

            if (athlete == null)
            {
                athlete = new Athlete
                {
                    OwnerID = userID,
                    FirstName = firstName,
                    Surname = surname,
                    EnrollmentDate = DateTime.Now,
                    RecordStatus = (int)RecordStatus.Active
                };

                await context.Athletes.AddAsync(athlete);
                context.SaveChanges();
            }

            return athlete.ID;
        }

        private static async Task<int> EnsureCoach(CoachContext context, string userID, string firstName, string surname)
        {
            var coach = new Coach { };

            coach = (Coach)context.Coaches.FirstOrDefault(c => c.OwnerID == userID);

            if (coach == null)
            {
                coach = new Coach
                {
                    OwnerID = userID,
                    FirstName = firstName,
                    Surname = surname,
                    HireDate = DateTime.Now,
                    RecordStatus = (int)RecordStatus.Active
                };

                await context.Coaches.AddAsync(coach);
                context.SaveChanges();
            }

            return coach.ID;
        }
    }
}
