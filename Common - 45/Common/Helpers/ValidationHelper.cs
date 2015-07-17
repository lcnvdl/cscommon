using Common.Validators;

namespace Common.Helpers
{
    public class ValidationHelper
    {
        public static void Validate(params IValidator[] validators)
        {
            foreach (var v in validators)
            {
                v.Validate();
            }
        }
    }
}
