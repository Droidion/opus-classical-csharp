# Opus Classical

Now in C#.

[![CI](https://github.com/Droidion/opus-classical-csharp/actions/workflows/ci.yml/badge.svg)](https://github.com/Droidion/opus-classical-csharp/actions/workflows/ci.yml)

## Requirements

- [.NET 9](https://dotnet.microsoft.com/en-us/download) (because of better support for Websockets in Blazor.
- [Task](https://taskfile.dev/) for task running. Optionally, can run tasks from `Taskfile.yml` manually.
- [Tailwind](https://tailwindcss.com/docs/installation) globally available.

## Run in dev mode

- Work with `OpusClassical` project.
- Create `OpusClassical/.env` file with variables:
  - DATABASE_CONNECTION_STRING=Your_postgres_connection_string
  - SUPABASE_URL=secret
  - SUPABASE_KEY=secret
- `$ task dev` for running dev server.