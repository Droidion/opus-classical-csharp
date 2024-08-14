# Opus Classical

Now in C#.

## Requirements

- [.NET 8](https://dotnet.microsoft.com/en-us/download) or later.
- [Task](https://taskfile.dev/) for task running.
- [Tailwind](https://tailwindcss.com/docs/installation) globally available

## Run in dev mode

- Work with `OpusClassical` project.
- Create `OpusClassical/.env` file with variables:
  - DATABASE_CONNECTION_STRING=Your_postgres_connection_string
  - SUPABASE_URL=secret
  - SUPABASE_KEY=secret
- `$ task dev` for running dev server.