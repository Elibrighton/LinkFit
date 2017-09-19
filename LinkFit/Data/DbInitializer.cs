using LinkFit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkFit.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CoachContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Athletes.Any())
            {
                return;   // DB has been seeded
            }

            var athletes = new Athlete[]
            {
            new Athlete{FirstName="Rebecca",LastName="Jenner",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Athlete{FirstName="Kody",LastName="Barrett",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Athlete{FirstName="Ian",LastName="Hurley",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Athlete{FirstName="Sherry",LastName="Ey",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Athlete{FirstName="Kephren",LastName="Izzard",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Athlete{FirstName="Grant",LastName="Little",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Athlete{FirstName="Leslie",LastName="Sproule",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Athlete{FirstName="Troy",LastName="Austin",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };
            foreach (Athlete a in athletes)
            {
                context.Athletes.Add(a);
            }
            context.SaveChanges();

            var trainingPrograms = new TrainingProgram[]
            {
            new TrainingProgram{Title="5 km running"},
            new TrainingProgram{Title="Marathon"},
            new TrainingProgram{Title="Ultra-marathon"},
            new TrainingProgram{Title="Ironman triathlon"},
            new TrainingProgram{Title="70.3 Ironman triathlon"},
            new TrainingProgram{Title="Open water swimming"}
            };
            foreach (TrainingProgram tp in trainingPrograms)
            {
                context.TrainingPrograms.Add(tp);
            }
            context.SaveChanges();

            var programEnrollments = new ProgramEnrollment[]
            {
            new ProgramEnrollment{AthleteID=1,TrainingProgramID=2},
            new ProgramEnrollment{AthleteID=1,TrainingProgramID=1},
            new ProgramEnrollment{AthleteID=1,TrainingProgramID=4},
            new ProgramEnrollment{AthleteID=2,TrainingProgramID=5},
            new ProgramEnrollment{AthleteID=2,TrainingProgramID=3},
            new ProgramEnrollment{AthleteID=2,TrainingProgramID=1},
            new ProgramEnrollment{AthleteID=3,TrainingProgramID=2},
            new ProgramEnrollment{AthleteID=4,TrainingProgramID=1},
            new ProgramEnrollment{AthleteID=4,TrainingProgramID=6},
            new ProgramEnrollment{AthleteID=5,TrainingProgramID=1},
            new ProgramEnrollment{AthleteID=6,TrainingProgramID=2},
            new ProgramEnrollment{AthleteID=7,TrainingProgramID=4},
            };
            foreach (ProgramEnrollment pe in programEnrollments)
            {
                context.ProgramEnrollments.Add(pe);
            }
            context.SaveChanges();
        }
    }
}
