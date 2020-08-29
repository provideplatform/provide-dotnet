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

start-attached:
	docker-compose up --remove-orphans

stop:
	docker-compose down --remove-orphans

test: restart dotnet-test stop
