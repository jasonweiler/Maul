﻿using System;
using System.Collections.Generic;
using Maul.Attributes;

namespace Maul.Commands
{
    [CommandGroup]
    public class HelloCommands
    {
        [Command(Description = "Prints a greeting to the console")]
        static void World(
            [NamedParameter(Description="Optional name to print")]
            string name="World")
        {
            Console.Out.WriteLine($"Hello, {name}!");
        }
    }

    [CommandGroup(Description = "Sample test commands")]
    public class TestCommands
    {
        [Command(Description = "Prints \"Hello World\" to the console")]
        public static void HelloWorld()
        {
            Console.Out.WriteLine("Hello World!");
        }
    }

    [CommandGroup(Description = "Simple commands", AltName = "Simple")]
    public class TestCommands2
    {
        [Command(Description = "Prints \"Fare thee well\" to the console", AltName = "Sayounara")]
        public static void SoLong()
        {
            Console.Out.WriteLine("Hasta la Vista, Baby-san!");
        }

        [Command(Description = "Prints what you tell it", AltName = "Echo")]
        static void ThanksForAllTheFish(
            [NamedParameter(AltName="Text", Description = "Text to echo back to you")]
            string fooBar)
        {
            Console.Out.WriteLine(fooBar);
        }

        [Command(Description = "Prints strings")]
        static void ListStrings(
            [NamedParameter(Description = "Added to front of items")]
            string prefix,
            [TargetParameter()]
            IEnumerable<string> Arguments)
        {
            foreach (var arg in Arguments)
            {
                Console.Out.WriteLine($"{prefix} - ${arg}");
            }
        }

        enum Severity
        {
            Info,
            Warning,
            Error,
            Critical,
            OhDearGod,
        }

        [Command(Description = "Prints what you tell it with a default", AltName = "EchoDefault")]
        static void TestDefaultArgs(
            [NamedParameter(AltName="Text", Description = "Text to echo back to you", Default = "This is default!")]
            string thingthingthing,
            [NamedParameter(Default = 42, Description = "Never you mind!")]
            int value,
            [NamedParameter(Optional = true)]
            string optionalString,
            Severity severity = Severity.OhDearGod)
        {
            Console.Out.WriteLine($"{severity}! {thingthingthing}");
        }
    }
}
