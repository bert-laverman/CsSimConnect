﻿/*
 * Copyright (c) 2021. Bert Laverman
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace CsSimConnect.Reactive
{

    public interface IMessageObserver
    {
        public bool IsStreamable();
        public bool IsCompleted { get; }
        public void OnNext(object msg);
        public void OnCompleted();
        public void OnError(Exception error);
    }

    public interface IMessageVoidObserver : IMessageObserver, IDisposable
    {
        public void Subscribe(Action callback, Action<Exception> onError = null, Action onComplete = null);
    }

    public interface IMessageObserver<T> : IMessageObserver, IObserver<T>, IEnumerable<T>, IDisposable
        where T : class
    {
        public void Subscribe(Action<T> callback, Action<Exception> onError = null, Action onComplete = null);
    }

}
