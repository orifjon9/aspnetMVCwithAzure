using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ps_start2aspnetmvc.Models
{
    public class Course
    {
        public string id { get; set; }
        public string Title { get; set; }
        public ICollection<Module> Modules { get; set; }
    }

    public class Module
    {
        public string Title { get; set; }
        public ICollection<Clip> Clips { get; set; }
    }

    public class Clip
    {
        public string Name { get; set; }
        public int Length { get; set; }
    }


    public class SimpleData
    {
        public IEnumerable<Course> GetCourses()
        {
            yield return new Course
            {
                Title = "Azure for .Net Developer",
                Modules = new List<Module>()
                {
                    new Module()
                    {
                        Title = "Introduction Azure Document DB schema",
                        Clips = new List<Clip>
                        {
                            new Clip(){ Length = 25, Name = "Overview" },
                            new Clip() { Length = 30, Name = "Azure Portal" },
                            new Clip() { Length = 35, Name = "More Azure"}
                        }
                    },
                    new Module()
                    {
                        Title = "Web Application in Azure",
                        Clips = new List<Clip>
                        {
                            new Clip() { Length = 25, Name ="Hello World!" },
                            new Clip() { Length = 30, Name ="App Services" },
                            new Clip() { Length = 35, Name ="Scaling"}
                        }
                    }
                }
            };
        }
    }
}