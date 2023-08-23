﻿namespace Fsdk.Tests

open NUnit.Framework

open Fsdk

[<TestFixture>]
type ArgsParsing() =

    [<Test>]
    member __.``simplest flags usage``() =
        let commandLine = "someProgram --someLongFlag1 -f2".Split(' ')
        let res: Misc.ArgsParsed = Misc.ParseArgs commandLine

        match res with
        | Misc.ArgsParsed.OnlyFlags flags ->
            Assert.That(Seq.length flags, Is.EqualTo 2)
            Assert.That(Seq.item 0 flags, Is.EqualTo "--someLongFlag1")
            Assert.That(Seq.item 1 flags, Is.EqualTo "-f2")
        | _ -> Assert.Fail "res was not ArgsParsing.OnlyFlags subtype"
