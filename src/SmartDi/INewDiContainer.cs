﻿using System;
using System.Linq.Expressions;

namespace SmartDi
{
    public interface INewDiContainer
    {
        //Register
        RegisterOptions Register<ConcreteType>()
            where ConcreteType : notnull;

        RegisterOptions Register<ConcreteType, ResolvedType>()
            where ConcreteType : notnull, ResolvedType;

        RegisterOptions Register<ConcreteType>(string key)
            where ConcreteType : notnull;

        RegisterOptions Register<ConcreteType, ResolvedType>(string key)
            where ConcreteType : notnull, ResolvedType;

        //... with Ctor
        RegisterOptions Register<ConcreteType>(params Type[] constructorParameters)
            where ConcreteType : notnull;

        RegisterOptions Register<ConcreteType, ResolvedType>(params Type[] constructorParameters)
            where ConcreteType : notnull, ResolvedType;

        RegisterOptions Register<ConcreteType>(string key, params Type[] constructorParameters)
            where ConcreteType : notnull;

        RegisterOptions Register<ConcreteType, ResolvedType>(string key, params Type[] constructorParameters)
            where ConcreteType : notnull, ResolvedType;


        // RegisterExpression

        RegisterOptions RegisterExpression<ResolvedType>(Expression<Func<INewDiContainer, ResolvedType>> instanceDelegate)
            where ResolvedType : notnull;

        //RegisterOptions RegisterExpression<ConcreteType, ResolvedType>(Expression<Func<INewDiContainer, ConcreteType>> instanceDelegate)
        //    where ConcreteType : notnull, ResolvedType;

        RegisterOptions RegisterExpression<ResolvedType>(Expression<Func<INewDiContainer, ResolvedType>> instanceDelegate, string key)
            where ResolvedType : notnull;

        //RegisterOptions RegisterExpression<ConcreteType, ResolvedType>(Expression<Func<INewDiContainer, ConcreteType>> instanceDelegate, string key)
        //    where ConcreteType : notnull, ResolvedType;

        // RegisterInstance

        void RegisterInstance(object instance);

        void RegisterInstance<ResolvedType>(object instance)
            where ResolvedType : notnull;

        void RegisterInstance(object instance, string key);

        void RegisterInstance<ResolvedType>(object instance, string key)
            where ResolvedType : notnull;

        //todo No need UseCtor
        //todo documentation
        //todo list registrations
        //todo autoregister (with flags like bindingflags) and exclusion like Tiny
        //todo .Static() / Global() overload to move to Static container from local container?
        //todo consolidate to one file
        //todo pass settings to instance version



        T Resolve<T>() where T : notnull;
        T Resolve<T>(string key) where T : notnull;

        void Unregister<T>()
            where T : notnull;

        void Unregister<T>(string key)
            where T : notnull;

        void UnregisterAll();
    }
}