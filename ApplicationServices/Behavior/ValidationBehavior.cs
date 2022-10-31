using FluentValidation;
using MediatR;

namespace ApplicationServices.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //Verifica si validator esta implementado en algun lado para un request
            //si es así verifica si hay errores, los cuenta , y larga una excepcion de los mismos
            //WhenAll : dice que la tarea termina cuando hayan terminado las tareas que tiene dentro de los parentesis
           if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request); //crea un contexto para una validacion de un request
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context,cancellationToken)));

                var failures = validationResults.SelectMany(x => x.Errors).Where(f => f != null).ToList();
                // se buscan y se guardan errores si los hay.


                if (failures.Count() != 0)// si hay errores larga una excepción, sino pasa a la siguiente acción
                    throw new Exeptions.ValidationExeptions(failures);
                    
            }

            return await next();
        }
    }
}
