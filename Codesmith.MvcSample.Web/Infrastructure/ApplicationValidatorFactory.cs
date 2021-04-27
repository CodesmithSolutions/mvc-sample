using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Codesmith.MvcSample.BusinessObjects;
using Codesmith.MvcSample.Web.Models;
using FluentValidation;
using SimpleInjector;

namespace Codesmith.MvcSample.Web.Infrastructure
{
    public class ApplicationValidatorFactory : IValidatorFactory
    {
        private readonly Container _container;

        /// <summary>The constructor of the factory.</summary>
        /// <param name="container">The Simple Injector Container</param>
        public ApplicationValidatorFactory(Container container)
        {
            _container = container;
        }

        /// <summary>Gets the validator for the specified type.</summary>
        public IValidator<T> GetValidator<T>()
        {
            return _container.GetInstance<IValidator<T>>();
        }

        /// <summary>Gets the validator for the specified type.</summary>
        public IValidator GetValidator(Type type)
        {
            var validator = typeof(IValidator<>).MakeGenericType(type);
            return (IValidator)_container.GetInstance(validator);
        }
    }
}