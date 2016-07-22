namespace NancyFileUpload.Infrastructure.Validation.Nancy
{
    using Errors.Specification.Exceptions;
    using global::Nancy;
    using global::Nancy.ModelBinding;
    using global::Nancy.Validation;

    public static class ModuleExtensions
    {
        public static TModel CustomBindAndValidate<TModel>(this NancyModule module)
        {
            var model = module.Bind<TModel>();

            InternalValidate(module, model);

            return model;
        }

        private static void InternalValidate<TModel>(NancyModule module, TModel model)
        {
            if (model != null)
            {
                var modelValidationResult = module.Validate(model);
                if (!modelValidationResult.IsValid)
                {
                    throw new ValidationServiceErrorException(modelValidationResult);
                }
            }
        }
    }
}