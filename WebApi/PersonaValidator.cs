using FluentValidation;
using WebApi.Models;

namespace WebApi
{
    public class PersonaValidator : AbstractValidator<Persona>
    {
        public PersonaValidator() 
        {
            RuleFor(x => x._Id).Null();
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Nombre).NotNull();
            RuleFor(x => x.Apellido).NotNull();
            RuleFor(x => x.Empleo).NotNull();
            RuleFor(x => x.DepFab).NotNull();
            RuleFor(x => x.Edad).NotNull().WithMessage("Debe contener un numero entre 1 y 110");
        }
    }
}
