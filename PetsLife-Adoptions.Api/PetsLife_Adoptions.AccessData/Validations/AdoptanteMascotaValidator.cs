using Domain.DTO_s;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Validations
{
    public class AdoptanteMascotaValidator :AbstractValidator<AdoptanteMascotaDto>
    {
        public AdoptanteMascotaValidator() 
        {
            RuleFor(x => x.AdoptanteId).NotEmpty().NotNull().WithMessage("El campo AdoptanteId no puede estar vacio");
            RuleFor(x => x.MascotaId).NotEmpty().NotNull().WithMessage("El campo MascotaId no puede estar vacio");
        }
    }
}
