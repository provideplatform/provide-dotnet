// Copyright 2017-2022 Provide Technologies Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace provide.Models.NatsClient
{
    public class ErrorEventArguments
    {
        public string Error { get; set; }
        public string ConnectedUrl { get; set; }
        public string Subject { get; set; }

        public static ErrorEventArguments FromNatsEntity(NATS.Client.ErrEventArgs args)
        {
            return new ErrorEventArguments()
            {
                ConnectedUrl = args.Conn.ConnectedUrl,
                Error = args.Error,
                Subject = args.Subscription.Subject
            };
        }
    }
}
