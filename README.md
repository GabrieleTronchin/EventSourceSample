# Sample project Include Marten Db (Postgres), CQRS, WebAPI

> Marten is a .NET library that allows developers to use the Postgresql database as both a document database and a fully-featured event store -- with the document features serving as the out-of-the-box mechanism for projected "read side" views of your events.

- https://martendb.io

## Overview

 - Minimal API
 - CQRS
 - EventSource
 - PostgressDB
 - DDD

TODO:
Fluent Validation
Use MediatoR Pipeline


## MartenSamples

OrderEndpoint don't use EventSource, it use marten just to save and get datas.


//TODO Extract a template for DDD from this proj
//TODO Extract a template for DDD + EventSource
//Extract Primitives in Shared prj

### Usefull links

[Rancher Desktop](https://rancherdesktop.io/): a free and comercial use for docker and/or Kubernates in local
