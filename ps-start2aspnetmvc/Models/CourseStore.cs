using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ps_start2aspnetmvc.Models
{
    public class CourseStore
    {
        DocumentClient documentClient;
        Uri courseLink;
        public CourseStore()
        {
            documentClient = new DocumentClient(new Uri(ConfigurationManager.AppSettings["DocumentDBUrl"]),
                ConfigurationManager.AppSettings["DocumentDBKey"]);
            courseLink = UriFactory.CreateDocumentCollectionUri("coursedb", "courses");
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return documentClient.CreateDocumentQuery<Course>(courseLink);
        }

        public async Task InsertCourses(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                await documentClient.CreateDocumentAsync(courseLink, course);
            }
        }
    }
}