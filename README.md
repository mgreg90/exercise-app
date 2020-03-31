Exercise App
====
* [Introduction](#introduction)
* [Client](#client)
* [Server](#server)
* [MongoDB](#mongodb)

## Introduction

The purpose of this simple workout app is for me to learn and familiarize myself
with the tech stack that I'll be using at my new job. Eventually I may build it
out to be something more complete.  I'm trying to learn C#/.Net, NUnit,
Knockout.js, and MongoDB.

## Setup

TODO
For local development, symlink the built client application to the server's
wwwroot folder:
`ln -s /path/to/projects/exercise-app/client/public/ /Users/mikegregory/dev-projects/exercise-app/server/wwwroot`

## Client

Run `npm run start` to run the client application.

## Server

Run `dotnet run` to run the server.

## MongoDB

Run (in background) with `brew services start mongodb-community`.

Kill with `brew services stop mongodb-community`.