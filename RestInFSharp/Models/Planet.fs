namespace RestInFSharp

open System
open MongoDB.Bson

type Planet = {
    mutable _id:ObjectId;
    mutable Name:String;
    mutable planetId:int32;}