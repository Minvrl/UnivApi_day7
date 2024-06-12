using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univ.Service.Dtos
{
    public class StudentGetDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int GroupId { get; set; }
        public byte Age { get; set; }
        public string ImageUrl { get; set; }
    }
}
