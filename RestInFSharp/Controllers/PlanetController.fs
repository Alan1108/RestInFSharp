namespace RestInFSharp.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open MongoDB.Bson
open RestInFSharp
open MongoDB.Driver
open MongoDB.Driver.Builders
open MongoDB.FSharp
open System.Net



[<ApiController>]
[<Route("[controller]")>]
type PlanetController (logger : ILogger<PlanetController>) =
    inherit ControllerBase()
    [<Literal>]
    let ConnectionString = "<YOUR CONNECTION STRING>"

    [<Literal>]
    let DbName = "<YOUR DB NAME>"

    [<Literal>]
    let CollectionName = "<YOUR COLLECTION NAME>"
      
    let client         = MongoClient(ConnectionString)
    let db             = client.GetDatabase(DbName)
    let testCollection = db.GetCollection<Planet>(CollectionName)

    [<HttpGet>]
    member _.Get() = 
        testCollection.Find(Builders.Filter.Empty).ToEnumerable()

    [<HttpGet("{id}")>]
    member _.Get(id : int32) =
        testCollection.Find(fun x -> x.planetId=id).ToEnumerable()
    
    [<HttpPost>]
    member _.Post(data: Planet) =
        data._id <- ObjectId.GenerateNewId()
        let returns = testCollection.InsertOne( data )
        HttpStatusCode.OK

    [<HttpPut("{id}")>]
    member _.Put(id:int32, data:Planet) = 
        if testCollection.Find(fun x -> x.planetId=id).ToEnumerable().Count() = 0
        then
            HttpStatusCode.NotFound
        else
            let dataInBD = testCollection.Find(fun x -> x.planetId=id).ToEnumerable().ElementAt(0)
            data._id <- dataInBD._id
            data.planetId <- dataInBD.planetId
            let returns = testCollection.ReplaceOne((fun x->x.planetId=id),data)
            HttpStatusCode.OK
            

    [<HttpDelete("{id}")>]
    member _.Delete(id: int32)=
        if testCollection.Find(fun x -> x.planetId=id).ToEnumerable().Count() = 0
        then HttpStatusCode.NotFound
        else 
            let returns = testCollection.DeleteOne(fun x->x.planetId=id)
            HttpStatusCode.OK

        

    
       
