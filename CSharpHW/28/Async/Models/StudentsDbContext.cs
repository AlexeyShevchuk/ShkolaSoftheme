using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Async.Models
{
    public class StudentsDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Curator> Curators { get; set; }

        public DbSet<Group> Groups { get; set; }
    }

    public class StudentsDb : DropCreateDatabaseAlways<StudentsDbContext>
    {
        protected override void Seed(StudentsDbContext db)
        {
            var curator = new Curator {FullName = "CuratorFullName1", CuratorId = 1};
            db.Curators.Add(curator);
            var group = new Group {Name = "GroupFullName1", GroupId = 1, Curator = curator};
            db.Groups.Add(group);

            db.Students.Add(new Student { FullName = "StudentFullName1", Group = group, Course = 4 });
            db.Students.Add(new Student { FullName = "StudentFullName2", Group = group, Course = 4 });
            db.Students.Add(new Student { FullName = "StudentFullName3", Group = group, Course = 4 });
            db.Students.Add(new Student { FullName = "StudentFullName4", Group = group, Course = 4 });

            base.Seed(db);
        }
    }
}