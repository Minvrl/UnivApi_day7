using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Univ.Service.Dtos
{
    public class GroupCreateDto
    {
        public string No { get; set; }
        public byte Limit { get; set; }
    }

    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(x => x.No).NotEmpty().MinimumLength(4).MaximumLength(5);
        }
    }
}
