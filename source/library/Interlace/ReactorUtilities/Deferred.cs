#region Using Directives and Copyright Notice

// Copyright (c) 2007-2010, Computer Consultancy Pty Ltd
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//       notice, this list of conditions and the following disclaimer in the
//       documentation and/or other materials provided with the distribution.
//     * Neither the name of the Computer Consultancy Pty Ltd nor the
//       names of its contributors may be used to endorse or promote products
//       derived from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL COMPUTER CONSULTANCY PTY LTD BE LIABLE 
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL 
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER 
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT 
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY 
// OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH
// DAMAGE.

using System;
using System.Collections.Generic;
using System.Text;

using Interlace.Utilities;

#endregion

namespace Interlace.ReactorUtilities
{
    public static class Deferred 
    {
        public static Deferred<T> Success<T>(T value)
        {
            Deferred<T> deferred = new Deferred<T>();
            deferred.SucceedObject(value);
            return deferred;
        }

        public static Deferred<T> Failure<T>(DeferredFailure failure)
        {
            Deferred<T> deferred = new Deferred<T>();
            deferred.Fail(failure);
            return deferred;
        }

        public static bool IsDeferred(Type type)
        {
            return typeof(DeferredObject).IsAssignableFrom(type);
        }

        public static bool IsTypedDeferred(Type type)
        {
            return
                type.Equals(typeof(VoidDeferred)) ||
                (!type.IsGenericTypeDefinition &&
                type.GetGenericTypeDefinition().Equals(typeof(Deferred<>)) &&
                type.GetGenericArguments().Length == 1);
        }

        public static Type DeferredResultType(Type type)
        {
            if (!IsTypedDeferred(type))
            {
                throw new InvalidOperationException(
                    "The type of a deferred is only available on a typed (generic or void) deferred.");
            }

            if (type.Equals(typeof(VoidDeferred)))
            {
                return typeof(void);
            }
            else
            {
                return type.GetGenericArguments()[0];
            }
        }

        public static DeferredObject CreateInstanceOfSameType(DeferredObject deferred)
        {
            Type type = deferred.GetType();

            return Activator.CreateInstance(type) as DeferredObject;
        }
    }

    public class Deferred<T> : DeferredObject
    {
        public delegate void Callback(T result);
        public delegate void CallbackWithState<TState>(T result, TState state);
        public delegate void Failback(DeferredFailure result);
        public delegate void FailbackWithState<TState>(DeferredFailure result, TState state);

        public delegate TReturn ConvertingCallback<TReturn>(T result);
        public delegate Deferred<TReturn> ChainingCallback<TReturn>(T result);
        public delegate void ConvertingCallback(T result);
        public delegate VoidDeferred ChainingCallback(T result);

        public void Completion(Callback callback, Failback failback)
        {
            ObjectCompletion(
                delegate(object result) { callback((T)result); return null; }, 
                delegate(DeferredFailure failure) { failback(failure); return null; },
                null);
        }

        public void Completion(Deferred<T> deferred)
        {
            ObjectCompletion(IdentityCallback, IdentityFailback, deferred);
        }

        public void Completion<TState>(CallbackWithState<TState> callback, Failback failback, TState state)
        {
            ObjectCompletion(
                delegate(object result) { callback((T)result, state); return null; }, 
                delegate(DeferredFailure failure) { failback(failure); return null; }, 
                null);
        }

        public void Completion<TState>(CallbackWithState<TState> callback, FailbackWithState<TState> failback, TState state)
        {
            ObjectCompletion(
                delegate(object result) { callback((T)result, state); return null; }, 
                delegate(DeferredFailure failure) { failback(failure, state); return null; }, 
                null);
        }

        public void Succeed(T value)
        {
            SucceedObject(value);
        }

        public Deferred<TReturn> Chained<TReturn>(ChainingCallback<TReturn> callback)
        {
            Deferred<TReturn> returnDeferred = new Deferred<TReturn>();

            ObjectCompletion(delegate(object result)
            {
                Deferred<TReturn> resultDeferred = callback((T)result);

                resultDeferred.Completion(returnDeferred);

                return null;
            },
            delegate(DeferredFailure failure)
            {
                returnDeferred.Fail(failure);

                return null;
            }, null);

            return returnDeferred;
        }

        public Deferred<TReturn> Converted<TReturn>(ConvertingCallback<TReturn> callback)
        {
            Deferred<TReturn> returnDeferred = new Deferred<TReturn>();

            ObjectCompletion(delegate(object result)
            {
                return callback((T)result);
            },
            IdentityFailback, returnDeferred);

            return returnDeferred;
        }

        public VoidDeferred Chained(ChainingCallback callback)
        {
            VoidDeferred returnDeferred = new VoidDeferred();

            ObjectCompletion(delegate(object result)
            {
                VoidDeferred resultDeferred = callback((T)result);

                resultDeferred.ObjectCompletion(IdentityCallback, IdentityFailback, returnDeferred);

                return null;
            },
            delegate(DeferredFailure failure)
            {
                returnDeferred.Fail(failure);

                return null;
            }, null);

            return returnDeferred;
        }

        public VoidDeferred Converted(ConvertingCallback callback)
        {
            VoidDeferred returnDeferred = new VoidDeferred();

            ObjectCompletion(delegate(object result)
            {
                callback((T)result);

                return null;
            },
            IdentityFailback, returnDeferred);

            return returnDeferred;
        }
    }
}
