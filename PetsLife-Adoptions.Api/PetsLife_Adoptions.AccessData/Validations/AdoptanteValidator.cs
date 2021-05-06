using Domain.DTO_s;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Validations
{
    public class AdoptanteValidator : AbstractValidator<AdoptanteDto>
    {
        public AdoptanteValidator() 
        {
            RuleFor(x => x.Nombre).NotEmpty().NotNull().WithMessage("El campo Nombre no puede estar vacio");
            RuleFor(x => x.Apellido).NotEmpty().NotNull().WithMessage("El campo Apellido no puede estar vacio");
            RuleFor(x => x.Dni).NotEmpty().NotNull().WithMessage("El campo Dni no puede estar vacio");
            RuleFor(x => x.Email).NotEmpty().WithMessage("El campo Email no puede estar vacio");
            RuleFor(x => x.Telefono).NotEmpty().WithMessage("El campo Telefono no puede estar vacio");
            RuleFor(x => x.Direccion).NotEmpty().WithMessage("El campo Direccion no puede estar vacio");
        }
    }
}
