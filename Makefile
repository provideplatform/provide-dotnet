# Copyright 2017-2022 Provide Technologies Inc.
# 
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# 
#     http://www.apache.org/licenses/LICENSE-2.0
# 
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

.PHONY: clean dotnet-test reset restart start start-attached stop test

clean:
	docker-compose down --rmi all --volumes --remove-orphans

dotnet-test:
	IDENT_API_HOST=localhost:8081 IDENT_API_SCHEME=http NCHAIN_API_HOST=localhost:8080 NCHAIN_API_SCHEME=http VAULT_API_HOST=localhost:8082 VAULT_API_SCHEME=http dotnet test

logs:
	docker-compose logs -f

reset: stop clean
	docker-compose up -d --build --force-recreate --remove-orphans

restart: stop start

start:
	docker-compose up -d --remove-orphans
	@sleep 3

start-attached:
	docker-compose up --remove-orphans

stop:
	docker-compose down --remove-orphans

test: restart dotnet-test stop
