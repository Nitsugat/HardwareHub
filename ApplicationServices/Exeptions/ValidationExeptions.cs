
using FluentValidation.Results;



namespace ApplicationServices.Exeptions
{
    public class ValidationExeptions: Exception
    {
        public List<string> Errors { get; }
        public ValidationExeptions():base("Hay uno o mas errores para realizar esta tarea.")
        {
            Errors = new List<string>();
        }

       

        public ValidationExeptions(IEnumerable<ValidationFailure> failures):this()
        {
            foreach(var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
