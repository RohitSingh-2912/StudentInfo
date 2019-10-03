using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentInfo.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string IId { get; set; }

        
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public int Age { get; set; }

        
        public string Gender { get; set; }






    }
}
