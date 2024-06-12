using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univ.Core.Entities
{
    public class Student:AuditEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int GroupId { get; set; }
        public string FileName { get; set; }
        public Group Group { get; set; }
    }
}
